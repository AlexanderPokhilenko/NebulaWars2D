using Code.Scenes.LobbyScene.Scripts.Shop;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts
{
    public class DailyPresentItemSpawner
    {
        public void Spawn(ProductModel productModel, GameObject sectionGameObject,
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
            itemPreview.sprite = Resources.Load<Sprite>(productModel.ImagePreviewPath);
       
            //Заполнить название
            Text itemName = dailyPresentGameObject.transform.Find("Image_ItemPreview/Text_ItemName").GetComponent<Text>();
            itemName.text = productModel.Name;
            
            //Установить обработчик нажатия
            Button itemButton = dailyPresentGameObject.GetComponent<Button>();
            itemButton.onClick.RemoveAllListeners();
            itemButton.onClick.AddListener(() =>
            {
                productClickHandlerScript.DailyPresent_OnClick(productModel.Id);
            });
        }
    }
}