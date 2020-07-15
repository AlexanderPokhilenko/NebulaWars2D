using Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts.Shop.Spawners.ItemSpawners
{
    public class HardCurrencyItemSpawner
    {
        public void Spawn(PurchaseModel purchaseModel, GameObject sectionGameObject,
            ProductClickHandlerScript productClickHandlerScript)
        {
            //Создать объект на сцене
            GameObject premiumCurrencyItemPrefab = Resources
                .Load<GameObject>("Prefabs/LobbyShop/Image_PremiumCurrencyItem");
            GameObject premiumCurrencyItemGameObject = Object.Instantiate(premiumCurrencyItemPrefab, sectionGameObject.transform, false);
            
            //Заполнить картинку
            Image itemPreview = premiumCurrencyItemGameObject.transform.Find("Image_ItemPreview")
                .GetComponentInChildren<Image>();
            itemPreview.sprite = Resources.Load<Sprite>(purchaseModel.ProductModel.ImagePreviewPath);
            
            //Заполнить цену
            Text itemCost = premiumCurrencyItemGameObject.transform.Find("Image_Cost/Text_Amount").GetComponent<Text>();
            itemCost.text = purchaseModel.ProductModel.CostString;
            
            //Заполнить название
            Text itemName = premiumCurrencyItemGameObject.transform.Find("Image_ItemPreview/Text_ItemName").GetComponent<Text>();
            itemName.text = purchaseModel.ProductModel.Name;
            
            //Установить обработчик нажатия
            Button itemButton = premiumCurrencyItemGameObject.GetComponent<Button>();
            itemButton.onClick.RemoveAllListeners();
            itemButton.onClick.AddListener(() =>
            {
                productClickHandlerScript.Product_OnClick(purchaseModel);
            });
        }
    }
}