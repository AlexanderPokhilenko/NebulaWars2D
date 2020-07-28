using System.Globalization;
using Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.UI;
using ZeroFormatter;

namespace Code.Scenes.LobbyScene.Scripts.Shop.Spawners.ItemSpawners
{
    public class HardCurrencyItemSpawner
    {
        public void Spawn(PurchaseModel purchaseModel, GameObject sectionGameObject,
            ProductClickHandlerScript productClickHandlerScript)
        {
            var costModel = ZeroFormatterSerializer.Deserialize<RealCurrencyCostModel>(purchaseModel.productModel.CostModel.SerializedCostModel);
            HardCurrencyProductModel hardCurrencyProductModel = purchaseModel.productModel;
            //Создать объект на сцене
            GameObject premiumCurrencyItemPrefab = Resources
                .Load<GameObject>("Prefabs/LobbyShop/Image_PremiumCurrencyItem");
            GameObject premiumCurrencyItemGameObject = Object.Instantiate(premiumCurrencyItemPrefab, sectionGameObject.transform, false);
            
            //Заполнить картинку
            Image itemPreview = premiumCurrencyItemGameObject.transform.Find("Image_ItemPreview")
                .GetComponentInChildren<Image>();
            itemPreview.sprite = Resources.Load<Sprite>(purchaseModel.productModel.PreviewImagePath);
            
            //Заполнить цену
            Text itemCost = premiumCurrencyItemGameObject.transform.Find("Image_Cost/Text_Amount").GetComponent<Text>();
            if (costModel.CostString != null)
            {
                itemCost.text = costModel.CostString.ToString(CultureInfo.InvariantCulture);    
            }
            else
            {
                itemCost.text = "undefined";
            }

            //Заполнить название
            Text itemName = premiumCurrencyItemGameObject.transform.Find("Image_ItemPreview/Text_ItemName").GetComponent<Text>();
            itemName.text = hardCurrencyProductModel.Amount.ToString();
            
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