using System;
using System.Net.Http;
using Code.Common;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.Scripts.UiStorages;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using ZeroFormatter;

namespace Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow
{
    public class Paymaster:MonoBehaviour
    {
        private LobbyEcsController lobbyEcsController;
        private UiSoundsManager lobbySoundsManager;
        private readonly ILog log = LogManager.CreateLogger(typeof(Paymaster));

        private void Awake()
        {
            lobbyEcsController = FindObjectOfType<LobbyEcsController>();
            lobbySoundsManager = UiSoundsManager.Instance();
        }

        public void Buy(PurchaseModel purchaseModel)
        {
            //todo если не хватает показать уведомление и переместить магазин на секцию с нужными ресурсами
            if (!IsPurchaseContinue(purchaseModel.ProductModel))
            {
                return;
            }
            
            //отправить блокирующий запрос на сервер
            if(!PlayerIdStorage.TryGetServiceId(out var playerServiceId))
            {
                lobbySoundsManager.PlayError();
                log.Error("Не удалось получить id игрока");
                return;
            }

            byte[] binaryProductModel = ZeroFormatterSerializer.Serialize(purchaseModel.ProductModel);
            string base64ProductModel = Convert.ToBase64String(binaryProductModel);
                    
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;
            using (MultipartFormDataContent formData = new MultipartFormDataContent())
            {
                formData.Add(new StringContent(playerServiceId), "playerId");   
                formData.Add(new StringContent(purchaseModel.ProductModel.Id.ToString()), "productId");   
                formData.Add(new StringContent(base64ProductModel), "base64ProductModel");   
                formData.Add(new StringContent(purchaseModel.ShopModelId.ToString()), "shopModelId");   
                response = httpClient.PostAsync(NetworkGlobals.BuyProduct, formData).Result;
            }

            if (response == null)
            {
                lobbySoundsManager.PlayError();
                log.Error("Пустой ответ от сервера");
                return;
            }

            if (!response.IsSuccessStatusCode)
            {
                lobbySoundsManager.PlayError();
                log.Error("Статус ответа от сервера "+ response.StatusCode);
                return;
            }
            
            log.Debug("Операция покупки прошла успешно");
            lobbySoundsManager.PlayPurchase();
        }

        private bool IsPurchaseContinue(ProductModel productModel)
        {
            switch (productModel.CurrencyTypeEnum)
            {
                case CurrencyTypeEnum.SoftCurrency:
                    if (lobbyEcsController.GetSoftCurrency() < productModel.Cost)
                    {
                        lobbySoundsManager.PlayError();
                        log.Error("Не хватает обычной валюты");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case CurrencyTypeEnum.HardCurrency:
                    if (lobbyEcsController.GetHardCurrency() < productModel.Cost)
                    {
                        lobbySoundsManager.PlayError();
                        log.Error("Не хватает премиум валюты");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case CurrencyTypeEnum.RealCurrency:
                    log.Fatal("Покупка за реальную валюту не должна тут обрабатываться");
                    return false;
                case CurrencyTypeEnum.Free:
                    return true;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}