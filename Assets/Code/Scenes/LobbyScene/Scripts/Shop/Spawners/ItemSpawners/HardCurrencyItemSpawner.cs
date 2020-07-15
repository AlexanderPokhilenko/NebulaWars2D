using System.Globalization;
using Code.Scenes.LobbyScene.Scripts.Shop;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts
{
    public class HardCurrencyItemSpawner
    {
        public void Spawn(ProductModel productModel, GameObject sectionGameObject,
            ProductClickHandlerScript productClickHandlerScript)
        {
            //Создать объект на сцене
            GameObject premiumCurrencyItemPrefab = Resources
                .Load<GameObject>("Prefabs/LobbyShop/Image_PremiumCurrencyItem");
            GameObject premiumCurrencyItemGameObject = Object.Instantiate(premiumCurrencyItemPrefab, sectionGameObject.transform, false);
            
            //Заполнить картинку
            Image itemPreview = premiumCurrencyItemGameObject.transform.Find("Image_ItemPreview")
                .GetComponentInChildren<Image>();
            itemPreview.sprite = Resources.Load<Sprite>(productModel.ImagePreviewPath);
            
            //Заполнить цену
            Text itemCost = premiumCurrencyItemGameObject.transform.Find("Image_Cost/Text_Amount").GetComponent<Text>();
            itemCost.text = productModel.CostString;
            
            //Заполнить название
            Text itemName = premiumCurrencyItemGameObject.transform.Find("Image_ItemPreview/Text_ItemName").GetComponent<Text>();
            itemName.text = productModel.Name;
            
            //Установить обработчик нажатия
            Button itemButton = premiumCurrencyItemGameObject.GetComponent<Button>();
            itemButton.onClick.RemoveAllListeners();
            itemButton.onClick.AddListener(() =>
            {
                productClickHandlerScript.Product_OnClick(productModel);
            });
        }
    }
}