using System.Globalization;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts.Shop.Spawners.ItemSpawners
{
    public class WarshipPowerPointsItemSpawner
    {
        private readonly ILog log = LogManager.CreateLogger(typeof(WarshipPowerPointsItemSpawner));
        
        public void Spawn(PurchaseModel purchaseModel, GameObject sectionGameObject,
            ProductClickHandlerScript productClickHandlerScript)
        {
            //Создать объект на сцене
            GameObject wppPrefab = Resources.Load<GameObject>("Prefabs/LobbyShop/Image_WarshipPowerPointsItem");
            GameObject wppGo = Object.Instantiate(wppPrefab, sectionGameObject.transform, false);
            
            //Установить название обьекта
            wppGo.name += " "+purchaseModel.ProductModel.WarshipPowerPointsProduct.PowerPointsIncrement;
            //Заполнить картинку
            Image itemPreview = wppGo.transform.Find("Image_WarshipPreview")
                .GetComponentInChildren<Image>();
            itemPreview.sprite = Resources.Load<Sprite>(purchaseModel.ProductModel.ImagePreviewPath);

            //Заполнить текущий показатель силы
            Text currentPowerValue = wppGo.transform.Find("Empty_PowerValueRoot/Text").GetComponent<Text>();
            currentPowerValue.text = purchaseModel.ProductModel.WarshipPowerPointsProduct.CurrentPowerPointsAmount + "/" +
                                     purchaseModel.ProductModel.WarshipPowerPointsProduct.CurrentMaxPowerPointsAmount;
            
            //Установить значение слайдера
            Slider slider = wppGo.transform.Find("Empty_PowerValueRoot/Slider").GetComponent<Slider>();
            slider.value = 1f * purchaseModel.ProductModel.WarshipPowerPointsProduct.CurrentPowerPointsAmount /
                           purchaseModel.ProductModel.WarshipPowerPointsProduct.CurrentMaxPowerPointsAmount;
            
            //Заполнить прибавку к очкам силы
            Text incrementText = wppGo.transform.Find("Text").GetComponent<Text>();
            int increment = purchaseModel.ProductModel.WarshipPowerPointsProduct.PowerPointsIncrement;
            // log.Debug($"increment = "+increment);
            incrementText.text = $"+{increment}";
            
            //Заполнить цену
            Text itemCost = wppGo.transform.Find("Image_Cost/Text_Amount").GetComponent<Text>();
            itemCost.text = purchaseModel.ProductModel.Cost.ToString(CultureInfo.InvariantCulture);
            
            //Установить обработчик нажатия
            Button itemButton = wppGo.GetComponent<Button>();
            itemButton.onClick.RemoveAllListeners();
            
            itemButton.onClick.AddListener(() =>
            {
                productClickHandlerScript.Product_OnClick(purchaseModel);
            });
        }
    }
}