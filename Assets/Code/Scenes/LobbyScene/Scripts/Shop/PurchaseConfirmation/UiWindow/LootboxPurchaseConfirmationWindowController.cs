using System;
using Code.Common;
using Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Code.Scenes.LobbyScene.Scripts
{
    /// <summary>
    /// Наполняет содержимым меню подтверждения покупки для сундуков.
    /// </summary>
    public class LootboxPurchaseConfirmationWindowController
    {
        private readonly Paymaster paymaster;
        private readonly ILog log = LogManager.CreateLogger(typeof(LootboxPurchaseConfirmationWindowController));

        public LootboxPurchaseConfirmationWindowController(Paymaster paymaster)
        {
            this.paymaster = paymaster;
        }

        public void Spawn(PurchaseModel purchaseModel, Transform parent)
        {
            GameObject lootboxContentPrefab = Resources
                .Load<GameObject>("Prefabs/LobbyShop/PurchasesConfirmation/LooboxContent");
            GameObject lootboxContent = Object.Instantiate(lootboxContentPrefab, parent, false);
            FillData(lootboxContent, purchaseModel.ProductModel);
            AddListeners(lootboxContent, purchaseModel);
        }

        private void FillData(GameObject lootboxContent, ProductModel productModel)
        {
            //заполнить картинку
            Image image = lootboxContent.transform.Find("Image_Lootbox/Image_ItemPreview").GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>("BigLootbox");
            //заполнить описание лутбокса
            Text description = lootboxContent.transform.Find("Text_WarshipDescription").GetComponent<Text>();
            description.text = "There are 3 times as many items in a big box as in a normal box!";
            
            //заполнить цену
            Text cost = lootboxContent.transform.Find("Button_Buy/Text_Cost").GetComponent<Text>();
            cost.text = productModel.CostString;
            //заполнить название лутбокса
            Text lootboxName = lootboxContent.transform.Find("Image_Lootbox/Image_ItemPreview/Text_ItemName")
                .GetComponent<Text>();
            lootboxName.text = productModel.Name;
        }
        
        private void AddListeners(GameObject lootboxContent, PurchaseModel purchaseModel)
        {
            //повесить слушатель на кнопку покупки
            Button buttonBuy = lootboxContent.transform.Find("Button_Buy")
                .GetComponent<Button>();
            buttonBuy.onClick.RemoveAllListeners();
            buttonBuy.onClick.AddListener(() =>
            {
                log.Debug("Покупка лутбокса");
                paymaster.Buy(purchaseModel);
            });
            
            //todo повесить слушатель на кнопку подробной информации
        } 
    }
}