using System;
using System.Net.Http;
using Code.Common;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.Scripts.ResourcesAccrual;
using Code.Scenes.LobbyScene.Scripts.UiStorages;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.SceneManagement;
using ZeroFormatter;

namespace Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow
{
    /// <summary>
    /// При покупке за игровую валюту отправляет запрос на сервер для проведения транзакции.
    /// </summary>
    [RequireComponent(typeof(InsufficientResourceErrorHandler))]
    public class InGameCurrencyPaymaster:MonoBehaviour
    {
        private LobbyEcsController lobbyEcsController;
        private ResourcesAccrualSceneManager resourcesAccrualSceneManager;
        private InsufficientResourceErrorHandler insufficientResourceErrorHandler;
        private readonly ILog log = LogManager.CreateLogger(typeof(InGameCurrencyPaymaster));

        private void Awake()
        {
            lobbyEcsController = FindObjectOfType<LobbyEcsController>();
            insufficientResourceErrorHandler = FindObjectOfType<InsufficientResourceErrorHandler>();
            resourcesAccrualSceneManager = FindObjectOfType<ResourcesAccrualSceneManager>();
        }

        public void StartBuying(PurchaseModel purchaseModel)
        {
            log.Debug("начало покупки");
            //если не хватает ресурсов 
            if (InsufficientResources(purchaseModel.productModel, out var insufficientResource))
            {
                //показать уведомление и переместить магазин на секцию с нужными ресурсами
                if (insufficientResource == null)
                {
                    throw new Exception("Ошибка при определении недостющего ресурса");
                }
                
                insufficientResourceErrorHandler.ShowError(insufficientResource.Value);
                return;
            }
            
            //отправить блокирующий запрос на сервер
            if(!PlayerIdStorage.TryGetServiceId(out string playerServiceId))
            {
                log.Error("Не удалось получить id игрока");
                return;
            }

            byte[] binaryProductModel = ZeroFormatterSerializer.Serialize(purchaseModel.productModel);
            string base64ProductModel = Convert.ToBase64String(binaryProductModel);
                    
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;
            using (MultipartFormDataContent formData = new MultipartFormDataContent())
            {
                formData.Add(new StringContent(playerServiceId), "playerId");   
                formData.Add(new StringContent(purchaseModel.productModel.Id.ToString()), "productId");   
                formData.Add(new StringContent(base64ProductModel), "base64ProductModel");   
                formData.Add(new StringContent(purchaseModel.shopModelId.ToString()), "shopModelId");   
                response = httpClient.PostAsync(NetworkGlobals.BuyProduct, formData).Result;
            }

            if (response == null)
            {
                log.Error("Пустой ответ от сервера");
                return;
            }

            if (!response.IsSuccessStatusCode)
            {
                log.Error("Статус ответа от сервера "+ response.StatusCode);
                return;
            }
            
            log.Debug("Операция покупки прошла успешно");
            //todo показать анимацию начисления приза
            resourcesAccrualSceneManager.ShowOneResource(purchaseModel);
        }

        private bool InsufficientResources(ProductModel productModel, out SectionTypeEnum? sectionTypeEnum)
        {
            switch (productModel.CurrencyTypeEnum)
            {
                case CurrencyTypeEnum.SoftCurrency:
                    if (lobbyEcsController.GetSoftCurrency() < productModel.Cost)
                    {
                        log.Error("Не хватает обычной валюты");
                        sectionTypeEnum = SectionTypeEnum.SoftCurrency;
                        return true;
                    }
                    else
                    {
                        sectionTypeEnum = null;
                        return false;
                    }
                case CurrencyTypeEnum.HardCurrency:
                    if (lobbyEcsController.GetHardCurrency() < productModel.Cost)
                    {
                        log.Error("Не хватает премиум валюты");
                        sectionTypeEnum = SectionTypeEnum.HardCurrency;
                        return true;
                    }
                    else
                    {
                        sectionTypeEnum = null;
                        return false;
                    }
                case CurrencyTypeEnum.RealCurrency:
                    log.Fatal("Покупка за реальную валюту не должна тут обрабатываться");
                    sectionTypeEnum = null;
                    return true;
                case CurrencyTypeEnum.Free:
                    sectionTypeEnum = null;
                    return false;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}