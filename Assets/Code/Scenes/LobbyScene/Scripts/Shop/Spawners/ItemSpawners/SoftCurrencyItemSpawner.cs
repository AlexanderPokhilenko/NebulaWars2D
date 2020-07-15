using System.Globalization;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts
{
    public class SoftCurrencyItemSpawner
    {
        public void Spawn(ProductModel productModel, GameObject sectionGameObject,
            ProductClickHandlerScript productClickHandlerScript)
        {
            //Создать объект на сцене
            GameObject regularCurrencyItemPrefab = Resources
                .Load<GameObject>("Prefabs/LobbyShop/Image_RegularCurrencyItem");
            GameObject regularCurrencyItemGameObject = Object.Instantiate(regularCurrencyItemPrefab, 
                sectionGameObject.transform, false);
            
            //Заполнить картинку
            Image itemPreview = regularCurrencyItemGameObject.transform.Find("Image_ItemPreview")
                .GetComponentInChildren<Image>();
            itemPreview.sprite = Resources.Load<Sprite>(productModel.ImagePreviewPath);
            
            //Заполнить цену
            Text itemCost = regularCurrencyItemGameObject.transform.Find("Image_Cost/Text_Amount").GetComponent<Text>();
            itemCost.text = productModel.CostString;
            
            //Заполнить название
            Text itemName = regularCurrencyItemGameObject.transform.Find("Image_ItemPreview/Text_ItemName").GetComponent<Text>();
            itemName.text = productModel.Name;
            
            //Установить обработчик нажатия
            Button itemButton = regularCurrencyItemGameObject.GetComponent<Button>();
            itemButton.onClick.RemoveAllListeners();
            itemButton.onClick.AddListener(() =>
            {
                productClickHandlerScript.Product_OnClick(productModel);
            });
        }
    }
}