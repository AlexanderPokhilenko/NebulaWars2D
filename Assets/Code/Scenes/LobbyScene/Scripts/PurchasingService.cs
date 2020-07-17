using System;
using System.Collections.Generic;
using System.Threading;
using Code.Common;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow;
using Code.Scenes.LobbyScene.Scripts.UiStorages;
using NetworkLibrary.Http.Lobby.Shop;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using UnityEngine.Purchasing.Security;
using ZeroFormatter;

namespace Code.Scenes.LobbyScene.Scripts
{
    /// <summary>
    /// Отвечает за взаимодействие с платёжной системой
    /// </summary>
    [RequireComponent(typeof(ProfileServerPurchaseValidatorBehaviour))]
    public class PurchasingService : MonoBehaviour, IStoreListener 
    {
        private IStoreController storeController;
        private IExtensionProvider extensionsProvider;
        private ProfileServerPurchaseValidatorBehaviour serverValidator;
        private readonly ILog log = LogManager.CreateLogger(typeof(PurchasingService));

        private void Awake()
        {
            serverValidator = GetComponent<ProfileServerPurchaseValidatorBehaviour>();
        }

        public void StartInitialization(List<ForeignServiceProduct> serviceProducts)
        {
#warning нужно использовать полное название пространства имён
            AbstractPurchasingModule purchasingModule = Google.Play.Billing.GooglePlayStoreModule.Instance();
#warning нужно использовать полное название пространства имён
            
            ConfigurationBuilder builder = ConfigurationBuilder.Instance(purchasingModule);
            foreach (ForeignServiceProduct foreignServiceProduct in serviceProducts)
            {
                string productId = foreignServiceProduct.ProductGoogleId;
                ProductType productType = foreignServiceProduct.Consumable
                    ? ProductType.Consumable
                    : ProductType.NonConsumable;
                log.Debug($"{nameof(productId)} {productId} {nameof(productType)} {productType}");
                builder.AddProduct(productId, productType);
            }
         
            UnityPurchasing.Initialize(this, builder);
        }
        
        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            log.Info(nameof(OnInitialized));
            storeController = controller;
            extensionsProvider = extensions;
        }
        
        public void OnInitializeFailed(InitializationFailureReason error)
        {
            log.Debug($"{nameof(OnInitializeFailed)} "+error);
        }

        public bool IsStoreInitialized()
        {
            return storeController != null && extensionsProvider != null;
        }

        public void BuyProductById(PurchaseModel purchaseModel)
        {
            string sku = purchaseModel.ProductModel.ForeignServiceProduct.ProductGoogleId;
            log.Debug($"{nameof(sku)} "+sku);
            bool isStoreInitialized = IsStoreInitialized(); 
            log.Debug($"{nameof(isStoreInitialized)} {isStoreInitialized}");
            if (!isStoreInitialized)
            {
                UiSoundsManager.Instance().PlayError();
                log.Error($"Вызов покупки был сделан до того как магазин " +
                          $"был инициализирован. {nameof(sku)} {sku}");
            }

            Product product = storeController.products.WithID(sku);
            if (product == null || !product.availableToPurchase)
            {
                log.Error($"product is null or not available for purchase");
            }

            if (!PlayerIdStorage.TryGetServiceId(out string playerServiceId))
            {
                UiSoundsManager.Instance().PlayError();
                log.Error($"Не удалось выполнить покупку потому, что {nameof(playerServiceId)} не доступен");
            }

            if (playerServiceId == null)
            {
                log.Error($"{nameof(playerServiceId)} is null");
                throw new Exception($"{nameof(playerServiceId)} is null");
            }

            // byte[] binaryProductModel = ZeroFormatterSerializer.Serialize(purchaseModel.ProductModel);
            // string base64ProductModel = Convert.ToBase64String(binaryProductModel);
            // PurchaseDeveloperPayload purchaseDeveloperPayload = new PurchaseDeveloperPayload()
            // {
            //     ProductId = purchaseModel.ProductModel.Id,
            //     Base64SerializedProduct = base64ProductModel,
            //     ServiceId = playerServiceId,
            //     ShopModelId = purchaseModel.ShopModelId
            // };
            // string payload = JsonUtility.ToJson(purchaseDeveloperPayload);
            // log.Debug($"{nameof(BuyProductById)} {nameof(payload)} {payload}");
            storeController.InitiatePurchase(sku);
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEventArgs)
        {   
             log.Debug(nameof(ProcessPurchase));
             string receipt = purchaseEventArgs.purchasedProduct.receipt;
             GooglePurchaseData data = new GooglePurchaseData(receipt);
             
             log.Debug($"{nameof(data.json.autoRenewing)} {data.json.autoRenewing}");
             log.Debug($"{nameof(data.json.developerPayload)} {data.json.developerPayload}");
             log.Debug($"{nameof(data.json.orderId)} {data.json.orderId}");
             log.Debug($"{nameof(data.json.packageName)} {data.json.packageName}");
             log.Debug($"{nameof(data.json.productId)} {data.json.productId}");
             log.Debug($"{nameof(data.json.purchaseState)} {data.json.purchaseState}");
             log.Debug($"{nameof(data.json.purchaseTime)} {data.json.purchaseTime}");
             log.Debug($"{nameof(data.json.purchaseToken)} {data.json.purchaseToken}");
             
             bool purchaseIsValid = true;
             string sku = purchaseEventArgs.purchasedProduct.definition.id;
             string token = null;
             
             
#if UNITY_ANDROID || UNITY_IOS || UNITY_STANDALONE_OSX
            CrossPlatformValidator validator = new CrossPlatformValidator(GooglePlayTangle.Data(),
                AppleTangle.Data(), Application.identifier);

            // purchaseEventArgs.purchasedProduct.LogProduct(log);

            try
            {
                IPurchaseReceipt[] result = validator.Validate(purchaseEventArgs.purchasedProduct.receipt);

                log.Debug("Receipt is valid. Contents:");
                foreach (IPurchaseReceipt productReceipt in result)
                {
                    log.Debug(productReceipt.productID);
                    log.Debug(productReceipt.purchaseDate.ToString());
                    log.Debug(productReceipt.transactionID);
                    if (productReceipt is GooglePlayReceipt google)
                    {
                        log.Debug(google.transactionID);
                        log.Debug(google.purchaseState.ToString());
                        log.Debug(google.purchaseToken);
                        token = google.purchaseToken;
                    }
                }
            }
            catch (IAPSecurityException)
            {
                log.Error("Invalid receipt, not unlocking content");
                purchaseIsValid = false;
            }
            catch (Exception e)
            {
                log.Error(e.Message+" "+e.StackTrace);
            }
#endif
            if (!purchaseIsValid)
            {
                log.Fatal($"Покупка не прошла локальную проверку");
                UiSoundsManager.Instance().PlayError();
            }
            
            serverValidator.StartValidation(sku, token);
            return PurchaseProcessingResult.Pending;    
        }

        public void OnPurchaseFailed(Product i, PurchaseFailureReason p)
        {
            log.Debug($"{nameof(OnPurchaseFailed)} "+p+" "+i.definition.id);
        }

        // public void ConfirmAll()
        // {
        //     log.Debug(nameof(ConfirmAll));
        //     var products = storeController.products.all;
        //     foreach (var product in products)
        //     {
        //         storeController.ConfirmPendingPurchase(product);
        //         log.Debug("success confirm "+product.definition.id);
        //     }
        // }
        
        public bool TryConfirmPendingPurchase(string sku)
        {
            bool success = false;
            log.Debug(nameof(TryConfirmPendingPurchase));
            try
            {
                Product product = storeController.products.WithID(sku);
                log.Debug($"Продукт найден по id {nameof(sku)} {sku}");
                log.Debug("Подтверждение транзакции " + product.definition.id);
                storeController.ConfirmPendingPurchase(product);
                log.Debug("Транзакция успешно подтверджена");
                success = true;
            }
            catch (Exception e)
            {
                UiSoundsManager.Instance().PlayError();
                log.Error($"Не удалось подтвердить продукт {nameof(sku)} {sku}." +
                          $" {e.Message} {e.StackTrace}");
            }
        
            return success;
        }
        
        public bool TryGetProductCostById(string sku, ref string cost)
        {
            try
            {
                Product product = storeController.products.WithID(sku);
                cost = product.metadata.localizedPriceString;
                return true;
            }
            catch (Exception e)
            {
                UiSoundsManager.Instance().PlayError();
                log.Error($"Не удалось получить стоимость продукта через api. " +
                          $"{nameof(sku)} {sku} {e.Message} {e.StackTrace}");
            }

            return false;
        }
    }
}
