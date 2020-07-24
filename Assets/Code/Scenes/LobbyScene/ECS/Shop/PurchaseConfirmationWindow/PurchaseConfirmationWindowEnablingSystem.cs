using System;
using System.Collections.Generic;
using System.Linq;
using Code.Common;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.Scripts;
using Code.Scenes.LobbyScene.Scripts.Shop;
using Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow;
using DataLayer.Tables;
using Entitas;
using Entitas.VisualDebugging.Unity;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.ECS.Shop.PurchaseConfirmationWindow
{
    /// <summary>
    /// Заполняет и включает  окно подтверждения покупки.
    /// </summary>
    public class PurchaseConfirmationWindowEnablingSystem:ReactiveSystem<LobbyUiEntity>
    {
        private ShopUiStorage shopUiStorage;
        private readonly LobbyEcsController lobbyEcsController;
        private SkinPurchaseConfirmationWindowController skinPurchaseConfirmationWindowController;
        private LootboxPurchaseConfirmationWindowController lootboxPurchaseConfirmationWindowController;
        private WarshipPurchaseConfirmationWindowController warshipPurchaseConfirmationWindowController;
        private readonly ILog log = LogManager.CreateLogger(typeof(PurchaseConfirmationWindowEnablingSystem));
        private SoftCurrencyPurchaseConfirmationWindowController softCurrencyPurchaseConfirmationWindowController;
        private WarshipPowerPointsPurchaseConfirmationWindowController warshipPowerPointsPurchaseConfirmationWindowController;

        public PurchaseConfirmationWindowEnablingSystem(IContext<LobbyUiEntity> context, LobbyEcsController lobbyEcsController,
            InGameCurrencyPaymaster inGameCurrencyPaymaster, ShopUiStorage shopUiStorage) 
            : base(context)
        {
            this.lobbyEcsController = lobbyEcsController;
            this.shopUiStorage = shopUiStorage;
            softCurrencyPurchaseConfirmationWindowController = new SoftCurrencyPurchaseConfirmationWindowController();
            skinPurchaseConfirmationWindowController = new SkinPurchaseConfirmationWindowController();
            lootboxPurchaseConfirmationWindowController = new LootboxPurchaseConfirmationWindowController(inGameCurrencyPaymaster);
            warshipPurchaseConfirmationWindowController = new WarshipPurchaseConfirmationWindowController(inGameCurrencyPaymaster);
            warshipPowerPointsPurchaseConfirmationWindowController =
                new WarshipPowerPointsPurchaseConfirmationWindowController(inGameCurrencyPaymaster);
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.EnablePurchaseConfirmationWindow);
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.hasEnablePurchaseConfirmationWindow;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            shopUiStorage.purchaseConfirmationWindowContent.transform.DestroyAllChildren();
            shopUiStorage.purchaseConfirmationWindowRoot.SetActive(true);
            var purchaseModel = entities.Last().enablePurchaseConfirmationWindow.purchase;
            //слушатель на кнопку с крестиком
            Button backgroundButton = shopUiStorage.purchaseConfirmationWindowRoot.transform
                .Find("Image_Menu/Button_Close")
                .GetComponent<Button>();
            backgroundButton.onClick.RemoveAllListeners();
            backgroundButton.onClick.AddListener(CreateHideWindowMessage);
 
            //слушатель на чёрный фон
            Button closeButton = shopUiStorage.purchaseConfirmationWindowRoot.transform
                .Find("Image_PurchaseConfirmationWindow")
                .GetComponent<Button>();
            closeButton.onClick.RemoveAllListeners();
            closeButton.onClick.AddListener(CreateHideWindowMessage);
            Spawn1(purchaseModel);
        }

        private void CreateHideWindowMessage()
        {
            lobbyEcsController.ClosePurchaseConfirmationWindow();
        }
        
        private void Spawn1(PurchaseModel purchaseModel)
        {
            switch (purchaseModel.productModel.TransactionType)
            {
                case TransactionTypeEnum.Lootbox:
                    lootboxPurchaseConfirmationWindowController.Spawn(purchaseModel, shopUiStorage.purchaseConfirmationWindowContent.transform);
                    break;
                case TransactionTypeEnum.Skin:
                    skinPurchaseConfirmationWindowController.Spawn(purchaseModel.productModel, shopUiStorage.purchaseConfirmationWindowContent.transform);
                    break;
                case TransactionTypeEnum.Warship:
                    warshipPurchaseConfirmationWindowController.Spawn(purchaseModel, shopUiStorage.purchaseConfirmationWindowContent.transform);
                    break;
                case TransactionTypeEnum.WarshipAndSkin:
                    break;
                case TransactionTypeEnum.WarshipPowerPoints:
                    warshipPowerPointsPurchaseConfirmationWindowController.Spawn(purchaseModel, shopUiStorage.purchaseConfirmationWindowContent.transform);
                    break;
                case TransactionTypeEnum.HardCurrency:
                    string message = "Жесткая валюта не должна покупать за внтриигровую валюту.";
                    log.Fatal(message);
                    throw new Exception(message);
                case TransactionTypeEnum.SoftCurrency:
                    softCurrencyPurchaseConfirmationWindowController.Spawn(purchaseModel.productModel, shopUiStorage.purchaseConfirmationWindowContent.transform);
                    break;
                case TransactionTypeEnum.DailyPrize:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}