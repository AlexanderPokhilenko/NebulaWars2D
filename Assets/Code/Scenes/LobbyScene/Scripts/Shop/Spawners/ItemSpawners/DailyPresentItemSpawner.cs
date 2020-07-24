using Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts.Shop.Spawners.ItemSpawners
{
    public class DailyPresentItemSpawner
    {
        public void Spawn(PurchaseModel purchaseModel, GameObject sectionGameObject,
            ProductClickHandlerScript productClickHandlerScript)
        {
            //Создать объект на сцене
            GameObject dailyPresentPrefab = Resources
                .Load<GameObject>("Prefabs/LobbyShop/Image_DailyPresentItem");
            GameObject dailyPresentGameObject = Object.Instantiate(dailyPresentPrefab, 
                sectionGameObject.transform, false);
            
            //Заполнить картинку
            Image itemPreview = dailyPresentGameObject.transform.Find("Image_ItemPreview")
                .GetComponentInChildren<Image>();
            itemPreview.sprite = Resources.Load<Sprite>(purchaseModel.productModel.ImagePreviewPath);
       
            //Заполнить название
            Text itemName = dailyPresentGameObject.transform.Find("Image_ItemPreview/Text_ItemName").GetComponent<Text>();
            itemName.text = purchaseModel.productModel.Name;
            
            //Установить обработчик нажатия
            Button itemButton = dailyPresentGameObject.GetComponent<Button>();
            itemButton.onClick.RemoveAllListeners();
            itemButton.onClick.AddListener(() =>
            {
                productClickHandlerScript.DailyPresent_OnClick(purchaseModel);
            });
        }
    }
}