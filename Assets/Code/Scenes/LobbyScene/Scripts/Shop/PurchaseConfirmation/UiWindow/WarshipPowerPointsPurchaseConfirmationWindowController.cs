using System;
using Code.Common;
using Code.Common.Logger;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow
{
    public class WarshipPowerPointsPurchaseConfirmationWindowController
    {
        private readonly InGameCurrencyPaymaster inGameCurrencyPaymaster;

        private readonly ILog log =
            LogManager.CreateLogger(typeof(WarshipPowerPointsPurchaseConfirmationWindowController));

        public WarshipPowerPointsPurchaseConfirmationWindowController(InGameCurrencyPaymaster inGameCurrencyPaymaster)
        {
            this.inGameCurrencyPaymaster = inGameCurrencyPaymaster;
        }
        
        public void Spawn(PurchaseModel purchaseModel, Transform parent)
        {
            GameObject lootboxContentPrefab = Resources
                .Load<GameObject>("Prefabs/LobbyShop/PurchasesConfirmation/WarshipPowerPointsContent");
            GameObject wpp = Object.Instantiate(lootboxContentPrefab, parent, false);
            Button buttonBuy = wpp.transform.Find("Button_Buy").GetComponent<Button>();
            FillData(wpp, purchaseModel.productModel);
            AddListeners(buttonBuy, purchaseModel);
        }

        private void FillData(GameObject powerPointsContent, ProductModel productModel)
        {
            //установить картинку корабля
            Image image = powerPointsContent.transform.Find("Image_WarshipPowerPointsItem/Image_WarshipPreview")
                .GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>(productModel.ImagePreviewPath);
            //установить текущее кол-во очков силы корабля
            Text text = powerPointsContent.transform.Find("Image_WarshipPowerPointsItem/Empty_PowerValueRoot/Text")
                .GetComponent<Text>();
            string text1 = productModel.WarshipPowerPointsProduct.CurrentPowerPointsAmount + "/" +
                           productModel.WarshipPowerPointsProduct.CurrentMaxPowerPointsAmount;
            log.Debug("текущее кол-во очков силы корабля "+text1);
            text.text = text1;
            //установить значение слайдера
            Slider slider = powerPointsContent.transform
                .Find("Image_WarshipPowerPointsItem/Empty_PowerValueRoot/Slider").GetComponent<Slider>();
            slider.value = 1f * productModel.WarshipPowerPointsProduct.CurrentPowerPointsAmount /
                           productModel.WarshipPowerPointsProduct.CurrentMaxPowerPointsAmount;
            // log.Debug($"slider.value = {slider.value}");
            //установить прибавляемое кол-во очков силы
            Text wppIncrementText = powerPointsContent.transform
                .Find("Image_WarshipPowerPointsItem/Text_Increment").GetComponent<Text>();
            wppIncrementText.text = "+"+productModel.WarshipPowerPointsProduct.PowerPointsIncrement;
            //установить описание
            Text description = powerPointsContent.transform.Find("Text_WarshipDescription").GetComponent<Text>();
            description.text = $"Power points: {productModel.WarshipPowerPointsProduct.PowerPointsIncrement}. Collect power points to activate improvements for the spacecraft.";
            //установить цену
            Text cost = powerPointsContent.transform.Find("Button_Buy/Text_Cost").GetComponent<Text>();
            cost.text = productModel.CostString;
            //TODO сделать установку типа валюты
        }

        private void AddListeners(Button buttonBuy, PurchaseModel purchaseModel)
        {
            //установить слушатель на кнопку покупки
            buttonBuy.onClick.RemoveAllListeners();
            buttonBuy.onClick.AddListener(() =>
            {
                inGameCurrencyPaymaster.StartBuying(purchaseModel);
            });
        }
    }
}