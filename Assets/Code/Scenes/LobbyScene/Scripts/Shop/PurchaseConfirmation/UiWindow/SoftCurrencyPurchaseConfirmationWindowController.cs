using Code.Common;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts
{
    public class SoftCurrencyPurchaseConfirmationWindowController
    {
        private readonly ILog log =
            LogManager.CreateLogger(typeof(WarshipPowerPointsPurchaseConfirmationWindowController));
        
        public void Spawn(ProductModel productModel, Transform parent)
        {
            GameObject softCurrencyContentPrefab = Resources
                .Load<GameObject>("Prefabs/LobbyShop/PurchasesConfirmation/SoftCurrencyContent");
            GameObject softCurrencyContent = Object.Instantiate(softCurrencyContentPrefab, parent, false);
            FillData(softCurrencyContent, productModel);
            AddListeners(softCurrencyContent, productModel);
        }

        private void FillData(GameObject softCurrencyContent, ProductModel productModel)
        {
            //установить картинку
            Image image = softCurrencyContent.transform.Find("Image_ItemPreviewBg/Image_ItemPreview")
                .GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>(productModel.ImagePreviewPath);
            
            //установить прибавляемое кол-во товара
            Text textLabel = softCurrencyContent.transform.Find("Image_ItemPreviewBg/Image_ItemPreview/Text_Label")
                .GetComponent<Text>();
            textLabel.text = productModel.Name;
            
            //установить описание
            Text description = softCurrencyContent.transform.Find("Text_Description").GetComponent<Text>();
            description.text = $"Power points: {productModel.Name}. Collect power points to activate improvements for the spacecraft.";
            //установить цену
            Text cost = softCurrencyContent.transform.Find("Button_Buy/Text_Cost").GetComponent<Text>();
            cost.text = productModel.CostString;
            //TODO сделать установку типа валюты
        }

        private void AddListeners(GameObject lootboxContent, ProductModel productModel)
        {
            //устновить слушатель на кнопку покупки
        }
    }
}