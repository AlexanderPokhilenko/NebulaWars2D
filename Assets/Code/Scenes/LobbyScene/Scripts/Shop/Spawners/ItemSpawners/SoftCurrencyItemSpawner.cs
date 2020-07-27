using System.Globalization;
using Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.UI;
using ZeroFormatter;

namespace Code.Scenes.LobbyScene.Scripts.Shop.Spawners.ItemSpawners
{
    public class SoftCurrencyItemSpawner
    {
        public void Spawn(PurchaseModel purchaseModel, GameObject sectionGameObject,
            ProductClickHandlerScript productClickHandlerScript)
        {
            var costModel = ZeroFormatterSerializer
                .Deserialize<InGameCurrencyCostModel>(purchaseModel.productModel.CostModel.SerializedCostModel);
            SoftCurrencyProductModel model = purchaseModel.productModel;
            //Создать объект на сцене
            GameObject regularCurrencyItemPrefab = Resources
                .Load<GameObject>("Prefabs/LobbyShop/Image_RegularCurrencyItem");
            GameObject regularCurrencyItemGameObject = Object.Instantiate(regularCurrencyItemPrefab, 
                sectionGameObject.transform, false);
            
            //Заполнить картинку
            Image itemPreview = regularCurrencyItemGameObject.transform.Find("Image_ItemPreview")
                .GetComponentInChildren<Image>();
            itemPreview.sprite = Resources.Load<Sprite>(purchaseModel.productModel.PreviewImagePath);
            
            //Заполнить цену
            Text itemCost = regularCurrencyItemGameObject.transform.Find("Image_Cost/Text_Amount").GetComponent<Text>();
            itemCost.text = costModel.Cost.ToString(CultureInfo.InvariantCulture);
            
            //Заполнить название
            Text itemName = regularCurrencyItemGameObject.transform.Find("Image_ItemPreview/Text_ItemName").GetComponent<Text>();
            itemName.text = model.Amount.ToString();
            
            //Установить обработчик нажатия
            Button itemButton = regularCurrencyItemGameObject.GetComponent<Button>();
            itemButton.onClick.RemoveAllListeners();
            itemButton.onClick.AddListener(() =>
            {
                productClickHandlerScript.Product_OnClick(purchaseModel);
            });
        }
    }
}