using System.Globalization;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts
{
    public class DiscountItemsSpawner
    {
        public float Spawn(ProductModel productModel, GameObject sectionGameObject, 
            Vector3 upperLeftCornerPosition, ProductClickHandlerScript productClickHandlerScript)
        {
            //Создать объект на сцене
            GameObject discountItemPrefab = Resources.Load<GameObject>("Prefabs/LobbyShop/Image_DiscountItem");
            GameObject discountItemGameObject = Object.Instantiate(discountItemPrefab, sectionGameObject.transform, false);
            
            //Установить положение левого верхнего угла
            discountItemGameObject.transform.localPosition = upperLeftCornerPosition;
            
            //Заполнить картинку
            Image itemPreview = discountItemGameObject.transform.Find("Image_ItemPreview")
                .GetComponentInChildren<Image>();
            itemPreview.sprite = Resources.Load<Sprite>(productModel.ImagePreviewPath);
            
            //Заполнить текущую цену
            Text currentCost = discountItemGameObject.transform.Find("Image_Cost/Text_Amount").GetComponent<Text>();
            currentCost.text = productModel.Cost.ToString(CultureInfo.InvariantCulture);
            
            //Заполнить старую цену
            Text oldCost = discountItemGameObject.transform.Find("Image_Cost/Text_OldAmount").GetComponent<Text>();
            oldCost.text = productModel.Cost.ToString(CultureInfo.InvariantCulture);
            
            //Заполнить название
            Text itemName = discountItemGameObject.transform.Find("Text_ItemName").GetComponent<Text>();
            itemName.text = productModel.Name;
            
            //Установить обработчик нажатия
            Button itemButton = discountItemGameObject.GetComponent<Button>();
            itemButton.onClick.RemoveAllListeners();
            itemButton.onClick.AddListener(() =>
            {
                productClickHandlerScript.Product_OnClick(productModel);
            });
            
            //Вернуть ширину
            RectTransform rectTransform = discountItemGameObject.GetComponent<RectTransform>();
            Rect rect = rectTransform.rect;
            Vector3 localScale = rectTransform.localScale;
            float width = rect.width*localScale.x;
            return width;
        }
    }
}