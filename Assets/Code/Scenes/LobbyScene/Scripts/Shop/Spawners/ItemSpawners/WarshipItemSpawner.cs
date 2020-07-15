using System.Globalization;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts.Shop.Spawners.ItemSpawners
{
    public class WarshipItemSpawner
    {
        private readonly ILog log = LogManager.CreateLogger(typeof(SkinItemSpawner));
        
        public void Spawn(PurchaseModel purchaseModel, GameObject sectionGameObject,
            ProductClickHandlerScript productClickHandlerScript)
        {
            //Создать объект на сцене
            GameObject skinItemPrefab = Resources.Load<GameObject>("Prefabs/LobbyShop/Empty_WarshipItem");
            GameObject skinItemGameObject = Object.Instantiate(skinItemPrefab,
                sectionGameObject.transform, false);
            
            //Заполнить картинку
            Image itemPreview = skinItemGameObject.transform.Find("Image_WarshipItem/Image_WarshipPreview")
                .GetComponentInChildren<Image>();
            itemPreview.sprite = Resources.Load<Sprite>(purchaseModel.ProductModel.ImagePreviewPath);
            
            //Заполнить название
            Text itemName = skinItemGameObject.transform.Find("Image_WarshipItem/Image_Name/Text_Name")
                .GetComponent<Text>();
            itemName.text = purchaseModel.ProductModel.Name;

            //Заполнить цену
            Text itemCost = skinItemGameObject.transform.Find("Image_WarshipItem/Image_Cost/Text_Amount")
                .GetComponent<Text>();
            itemCost.text = purchaseModel.ProductModel.Cost.ToString(CultureInfo.InvariantCulture);
            
            //Установить обработчик нажатия
            Button itemButton = skinItemGameObject.GetComponent<Button>();
            itemButton.onClick.RemoveAllListeners();
            itemButton.onClick.AddListener(() =>
            {
                productClickHandlerScript.Product_OnClick(purchaseModel);
            });
        }
    }
}