using System;
using Code.Common;
using Code.Scenes.DebugScene;
using JetBrains.Annotations;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;

namespace Code.Scenes.LobbyScene.Scripts
{
    /// <summary>
    /// Реагирует на нажатие на товар в магазине.
    /// </summary>
    public class ProductClickHandlerScript : MonoBehaviour
    {
        // private PurchasingService purchasingService;
        private PurchaseConfirmationWindowController purchaseConfirmationWindowController;
        private readonly ILog log = LogManager.CreateLogger(typeof(ProductClickHandlerScript));

        private void Awake()
        {
            // purchasingService = FindObjectOfType<PurchasingService>()
            //     ?? throw new Exception(nameof(PurchasingService));
            purchaseConfirmationWindowController = FindObjectOfType<PurchaseConfirmationWindowController>()
                ?? throw new Exception(nameof(PurchaseConfirmationWindowController));;
        }

        public void Product_OnClick([NotNull] ProductModel productModel)
        {
            log.Debug($"{nameof(Product_OnClick)} {nameof(productModel.Id)} {productModel.Id}");
            log.Debug("Тип валюты "+productModel.CurrencyTypeEnum);
            //Если покупка за реальную валюту, то вызвать api платёжной системы
            if (productModel.CurrencyTypeEnum == CurrencyTypeEnum.RealCurrency)
            {
                log.Debug("Покупка за реальную валюту");
                string sku = productModel.ForeignServiceProduct.ProductGoogleId;
                log.Debug($"{nameof(sku)} {sku}");
                // purchasingService.BuyProductById(sku);
            }
            else
            {
                log.Debug("Показ окна подтверждения покупки");
                //Если покупка за внутриигровую валюту, то показать меню подтверждения покупки
                purchaseConfirmationWindowController.Show(productModel);    
            }
        }

        public void DailyPresent_OnClick(int id)
        {
            //TODO отправить запрос
            //TODO показать анимацию начисления
            //todo выключить подарок
        }
    }
}