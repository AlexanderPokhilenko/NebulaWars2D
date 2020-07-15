using System.Globalization;
using Code.Scenes.LobbyScene.Scripts.Shop;
using Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts
{
    public class LootboxItemsSpawner
    {
        public void Spawn(PurchaseModel purchaseModel, GameObject sectionGameObject,
            ProductClickHandlerScript productClickHandlerScript)
        {
            //Создать объект на сцене
            GameObject lootboxItemPrefab = Resources.Load<GameObject>("Prefabs/LobbyShop/Image_Lootbox");
            GameObject lootboxGameObject = Object.Instantiate(lootboxItemPrefab, sectionGameObject.transform, false);
            
            //Заполнить картинку
            Image itemPreview = lootboxGameObject.transform.Find("Image_ItemPreview")
                .GetComponentInChildren<Image>();
            itemPreview.sprite = Resources.Load<Sprite>(purchaseModel.ProductModel.ImagePreviewPath);
            
            //Заполнить цену
            Text itemCost = lootboxGameObject.transform.Find("Image_Cost/Text_Amount").GetComponent<Text>();
            itemCost.text = purchaseModel.ProductModel.Cost.ToString(CultureInfo.InvariantCulture);
            
            //Заполнить название
            Text itemName = lootboxGameObject.transform.Find("Image_ItemPreview/Text_ItemName").GetComponent<Text>();
            itemName.text = purchaseModel.ProductModel.Name;
            
            //Установить обработчик нажатия
            Button itemButton = lootboxGameObject.GetComponent<Button>();
            itemButton.onClick.RemoveAllListeners();
            itemButton.onClick.AddListener(() =>
            {
                productClickHandlerScript.Product_OnClick(purchaseModel);
            });
        }
    }
}