using System;
using Code.Common;
using DataLayer.Tables;
using JetBrains.Annotations;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;

namespace Code.Scenes.LobbyScene.Scripts
{
    /// <summary>
    /// Отвечает за наполнение окна подтверждения покупки.
    /// В зависимости от типа товара наполнение будет разным.
    /// </summary>
    public class PurchaseConfirmationWindowController:MonoBehaviour
    {
        private ShopUiStorage shopUiStorage;
        private LobbyEcsController lobbyEcsController;
        private PurchaseConfirmationWindow purchaseConfirmationWindow;
        private SkinPurchaseConfirmationWindowController skinPurchaseConfirmationWindowController;
        private LootboxPurchaseConfirmationWindowController lootboxPurchaseConfirmationWindowController;
        private WarshipPurchaseConfirmationWindowController warshipPurchaseConfirmationWindowController;
        private readonly ILog log = LogManager.CreateLogger(typeof(PurchaseConfirmationWindowController));
        private SoftCurrencyPurchaseConfirmationWindowController softCurrencyPurchaseConfirmationWindowController;
        private WarshipPowerPointsPurchaseConfirmationWindowController warshipPowerPointsPurchaseConfirmationWindowController;
        private Paymaster paymaster;

        private void Awake()
        {
            shopUiStorage = FindObjectOfType<ShopUiStorage>();
            lobbyEcsController = FindObjectOfType<LobbyEcsController>();
            purchaseConfirmationWindow = FindObjectOfType<PurchaseConfirmationWindow>();
            paymaster = FindObjectOfType<Paymaster>();

            softCurrencyPurchaseConfirmationWindowController = new SoftCurrencyPurchaseConfirmationWindowController();
            skinPurchaseConfirmationWindowController = new SkinPurchaseConfirmationWindowController();
            lootboxPurchaseConfirmationWindowController = new LootboxPurchaseConfirmationWindowController(paymaster);
            warshipPurchaseConfirmationWindowController = new WarshipPurchaseConfirmationWindowController();
            warshipPowerPointsPurchaseConfirmationWindowController =
                new WarshipPowerPointsPurchaseConfirmationWindowController(paymaster);
        }

        public void Show([NotNull] ProductModel productModel)
        {
            purchaseConfirmationWindow.ClearWindow();
            
            switch (productModel.TransactionType)
            {
                case TransactionTypeEnum.Lootbox:
                    lootboxPurchaseConfirmationWindowController
                        .Spawn(productModel, shopUiStorage.purchaseConfirmationWindowContent.transform);
                    break;
                case TransactionTypeEnum.Skin:
                    skinPurchaseConfirmationWindowController
                        .Spawn(productModel, shopUiStorage.purchaseConfirmationWindowContent.transform);
                    break;
                case TransactionTypeEnum.Warship:
                    warshipPurchaseConfirmationWindowController
                        .Spawn(productModel, shopUiStorage.purchaseConfirmationWindowContent.transform);
                    break;
                case TransactionTypeEnum.WarshipAndSkin:
                    break;
                case TransactionTypeEnum.WarshipPowerPoints:
                    warshipPowerPointsPurchaseConfirmationWindowController
                        .Spawn(productModel, shopUiStorage.purchaseConfirmationWindowContent.transform);
                    break;
                case TransactionTypeEnum.HardCurrency:
                    string message = "Жесткая валюта не должна покупать за внтриигровую валюту.";
                    log.Fatal(message);
                    throw new Exception(message);
                case TransactionTypeEnum.SoftCurrency:
                    softCurrencyPurchaseConfirmationWindowController
                        .Spawn(productModel, shopUiStorage.purchaseConfirmationWindowContent.transform);
                    break;
                case TransactionTypeEnum.DailyPrize:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            //Показать
            purchaseConfirmationWindow.ShowWindow();
            
            //Уведомить систему о том, что окно включилось
            lobbyEcsController.PurchaseConfirmationWindowWasShown();
        }
    }
}