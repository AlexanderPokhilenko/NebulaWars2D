using System.Globalization;
using Assets.Code.Scenes.BattleScene.Experimental;
using Code.Common;
using Entitas;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts
{
    public class WarshipPowerPointsItemSpawner
    {
        private readonly ILog log = LogManager.CreateLogger(typeof(WarshipPowerPointsItemSpawner));
        
        public void Spawn(ProductModel productModel, GameObject sectionGameObject,
            ProductClickHandlerScript productClickHandlerScript)
        {
            //Создать объект на сцене
            GameObject wppPrefab = Resources.Load<GameObject>("Prefabs/LobbyShop/Image_WarshipPowerPointsItem");
            GameObject wppGo = Object.Instantiate(wppPrefab, sectionGameObject.transform, false);
            
            //Установить название обьекта
            wppGo.name += " "+productModel.WarshipPowerPointsProduct.PowerPointsIncrement;
            //Заполнить картинку
            Image itemPreview = wppGo.transform.Find("Image_WarshipPreview")
                .GetComponentInChildren<Image>();
            itemPreview.sprite = Resources.Load<Sprite>(productModel.ImagePreviewPath);

            //Заполнить текущий показатель силы
            Text currentPowerValue = wppGo.transform.Find("Empty_PowerValueRoot/Text").GetComponent<Text>();
            currentPowerValue.text = productModel.WarshipPowerPointsProduct.CurrentPowerPointsAmount + "/" +
                                     productModel.WarshipPowerPointsProduct.CurrentMaxPowerPointsAmount;
            
            //Установить значение слайдера
            Slider slider = wppGo.transform.Find("Empty_PowerValueRoot/Slider").GetComponent<Slider>();
            slider.value = 1f * productModel.WarshipPowerPointsProduct.CurrentPowerPointsAmount /
                           productModel.WarshipPowerPointsProduct.CurrentMaxPowerPointsAmount;
            
            //Заполнить прибавку к очкам силы
            Text incrementText = wppGo.transform.Find("Text").GetComponent<Text>();
            int increment = productModel.WarshipPowerPointsProduct.PowerPointsIncrement;
            // log.Debug($"increment = "+increment);
            incrementText.text = $"+{increment}";
            
            //Заполнить цену
            Text itemCost = wppGo.transform.Find("Image_Cost/Text_Amount").GetComponent<Text>();
            itemCost.text = productModel.Cost.ToString(CultureInfo.InvariantCulture);
            
            //Установить обработчик нажатия
            Button itemButton = wppGo.GetComponent<Button>();
            itemButton.onClick.RemoveAllListeners();
            
            var test = productModel;
            itemButton.onClick.AddListener(() =>
            {
                productClickHandlerScript.Product_OnClick(test);
            });
        }
    }
}