using System.Globalization;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts.Shop.Spawners.ItemSpawners
{
    public class SkinItemSpawner
    {
        private readonly ILog log = LogManager.CreateLogger(typeof(SkinItemSpawner));
        
        public void Spawn(PurchaseModel purchaseModel, GameObject sectionGameObject,
            ProductClickHandlerScript productClickHandlerScript)
        {
            //Создать объект на сцене
            GameObject skinItemPrefab = Resources.Load<GameObject>("Prefabs/LobbyShop/Empty_SkinItem");
            GameObject skinItemGameObject = Object.Instantiate(skinItemPrefab,
                sectionGameObject.transform, false);
            
            //Заполнить картинку
            Image itemPreview = skinItemGameObject.transform.Find("Image_SkinItem/Image_WarshipSkinPreview")
                .GetComponentInChildren<Image>();

            itemPreview.sprite = Resources.Load<Sprite>(purchaseModel.productModel.ImagePreviewPath);
            
            //Заполнить название
            Text itemName = skinItemGameObject.transform.Find("Image_SkinItem/Image_SkinName/Text_SkinName").GetComponent<Text>();
            itemName.text = purchaseModel.productModel.Name;

            //Заполнить цену
            Text itemCost = skinItemGameObject.transform.Find("Image_SkinItem/Image_Cost/Text_Amount").GetComponent<Text>();
            itemCost.text = purchaseModel.productModel.Cost.ToString(CultureInfo.InvariantCulture);
            
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