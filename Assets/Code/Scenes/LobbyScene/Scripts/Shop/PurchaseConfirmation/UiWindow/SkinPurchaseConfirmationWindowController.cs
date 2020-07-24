using Code.Common.Logger;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow
{
    public class SkinPurchaseConfirmationWindowController
    {
        private readonly InGameCurrencyPaymaster inGameCurrencyPaymaster;
        private readonly ILog log = LogManager.CreateLogger(typeof(SkinPurchaseConfirmationWindowController));

        public SkinPurchaseConfirmationWindowController(InGameCurrencyPaymaster inGameCurrencyPaymaster)
        {
            this.inGameCurrencyPaymaster = inGameCurrencyPaymaster;
        }

        public void Spawn(ProductModel productModel, Transform parent)
        {
            GameObject skinPrefab = Resources
                .Load<GameObject>("Prefabs/LobbyShop/PurchasesConfirmation/SkinContent");
            GameObject skinContent = Object.Instantiate(skinPrefab, parent, false);
            FillData(skinContent, productModel);
            AddListeners(skinContent, productModel);
        }

        private void FillData(GameObject skinContent, ProductModel productModel)
        {
            //заспавнить корабль
            GameObject warshipPrefab = Resources.Load<GameObject>(productModel.WarshipModel.PrefabPath);
            GameObject warship = Object.Instantiate(warshipPrefab, skinContent.transform, false);
            warship.transform.localPosition = new Vector3(-140,-25,-200);
            warship.transform.localScale = new Vector3(110,110,110);

            //установить название скина
            Text skinName = skinContent.transform.Find("Text_SkinName").GetComponent<Text>();
            skinName.text = productModel.Name;
            
            //установить описание скина
            Text description = skinContent.transform.Find("Text_Description").GetComponent<Text>();
            description.text = productModel.WarshipModel.Description;
            
            //установить цену
            Text cost = skinContent.transform.Find("Button_Buy/Text_Cost").GetComponent<Text>();
            cost.text = productModel.CostString;
            
            //TODO сделать установку типа валюты
        }

        private void AddListeners(GameObject skinContent, ProductModel productModel)
        {
            //устновить слушатель на кнопку покупки
        }
    }
}