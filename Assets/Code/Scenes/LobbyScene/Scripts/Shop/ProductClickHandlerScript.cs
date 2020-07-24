using System;
using Code.Common;
using Code.Common.Logger;
using Code.Scenes.DebugScene;
using Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation;
using Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow;
using JetBrains.Annotations;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;

namespace Code.Scenes.LobbyScene.Scripts.Shop
{
    /// <summary>
    /// Реагирует на нажатие на товар в магазине.
    /// </summary>
    public class ProductClickHandlerScript : MonoBehaviour
    {
        private PurchasingService purchasingService;
        private PurchaseConfirmationWindowController purchaseConfirmationWindowController;
        private readonly ILog log = LogManager.CreateLogger(typeof(ProductClickHandlerScript));

        private void Awake()
        {
            purchasingService = FindObjectOfType<PurchasingService>()
                ?? throw new Exception(nameof(PurchasingService));
            purchaseConfirmationWindowController = FindObjectOfType<PurchaseConfirmationWindowController>()
                ?? throw new Exception(nameof(PurchaseConfirmationWindowController));;
        }

        public void Product_OnClick([NotNull] PurchaseModel purchaseModel)
        {
            log.Debug($"{nameof(Product_OnClick)} {nameof(purchaseModel.productModel.Id)} {purchaseModel.productModel.Id}");
            log.Debug("Тип валюты "+purchaseModel.productModel.CurrencyTypeEnum);
            //Если покупка за реальную валюту, то вызвать api платёжной системы
            if (purchaseModel.productModel.CurrencyTypeEnum == CurrencyTypeEnum.RealCurrency)
            {
                log.Debug("Покупка за реальную валюту");
                purchasingService.BuyProduct(purchaseModel);
            }
            else
            {
                log.Debug("Показ окна подтверждения покупки");
                //Если покупка за внутриигровую валюту, то показать меню подтверждения покупки
                purchaseConfirmationWindowController.Show(purchaseModel);    
            }
        }

        public void DailyPresent_OnClick(PurchaseModel purchaseModel)
        {
            //TODO отправить запрос
            //TODO показать анимацию начисления
            //todo выключить подарок
        }
    }
}