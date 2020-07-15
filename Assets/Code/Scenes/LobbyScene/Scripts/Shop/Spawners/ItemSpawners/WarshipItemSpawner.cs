using System.Globalization;
using Assets.Code.Scenes.BattleScene.Experimental;
using Code.Common;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts
{
    public class WarshipItemSpawner
    {
        private readonly ILog log = LogManager.CreateLogger(typeof(SkinItemSpawner));
        
        public void Spawn(ProductModel productModel, GameObject sectionGameObject,
            ProductClickHandlerScript productClickHandlerScript)
        {
            //Создать объект на сцене
            GameObject skinItemPrefab = Resources.Load<GameObject>("Prefabs/LobbyShop/Empty_WarshipItem");
            GameObject skinItemGameObject = Object.Instantiate(skinItemPrefab,
                sectionGameObject.transform, false);
            
            //Заполнить картинку
            Image itemPreview = skinItemGameObject.transform.Find("Image_WarshipItem/Image_WarshipPreview")
                .GetComponentInChildren<Image>();
            itemPreview.sprite = Resources.Load<Sprite>(productModel.ImagePreviewPath);
            
            //Заполнить название
            Text itemName = skinItemGameObject.transform.Find("Image_WarshipItem/Image_Name/Text_Name")
                .GetComponent<Text>();
            itemName.text = productModel.Name;

            //Заполнить цену
            Text itemCost = skinItemGameObject.transform.Find("Image_WarshipItem/Image_Cost/Text_Amount")
                .GetComponent<Text>();
            itemCost.text = productModel.Cost.ToString(CultureInfo.InvariantCulture);
            
            //Установить обработчик нажатия
            Button itemButton = skinItemGameObject.GetComponent<Button>();
            itemButton.onClick.RemoveAllListeners();
            itemButton.onClick.AddListener(() =>
            {
                productClickHandlerScript.Product_OnClick(productModel);
            });
        }
    }
}