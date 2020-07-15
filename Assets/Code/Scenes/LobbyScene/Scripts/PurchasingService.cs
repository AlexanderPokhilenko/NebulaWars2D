using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Code.Common;
using Google.Play.Billing;
using JetBrains.Annotations;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using UnityEngine.Purchasing.Security;
using ZeroFormatter;

namespace Code.Scenes.DebugScene
{
    /// <summary>
    /// Отвечает за взаимодействие с платёжной системой
    /// </summary>
    public class PurchasingService : MonoBehaviour, IStoreListener 
    {
        private IStoreController storeController;
        private IExtensionProvider extensionsProvider;
        private readonly ILog log = LogManager.CreateLogger(typeof(PurchasingService));
        
        public void StartInitialization(List<ForeignServiceProduct> serviceProducts)
        {
            log.Debug(nameof(StartInitialization)+" 1");
            AbstractPurchasingModule test = GooglePlayStoreModule.Instance();
            ConfigurationBuilder builder = ConfigurationBuilder.Instance(test);
            log.Debug(nameof(StartInitialization)+" 2");
            foreach (ForeignServiceProduct foreignServiceProduct in serviceProducts)
            {
                ProductType productType = foreignServiceProduct.Consumable
                    ? ProductType.Consumable
                    : ProductType.NonConsumable;
                string productId = foreignServiceProduct.ProductGoogleId;
                builder.AddProduct(productId, productType);
            }
            log.Debug(nameof(StartInitialization)+" 3");
            UnityPurchasing.Initialize(this, builder);
            log.Debug(nameof(StartInitialization)+" 4");
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

        public void BuyProductById(string productId)
        {
            log.Debug($"{nameof(BuyProductById)} "+productId);
            bool isStoreInitialized = IsStoreInitialized(); 
            log.Debug($"{nameof(isStoreInitialized)} {isStoreInitialized}");
            if (isStoreInitialized)
            {
                Product product = storeController.products.WithID(productId);
                if (product != null && product.availableToPurchase)
                {
                    if (PlayerIdStorage.TryGetServiceId(out string playerServiceId))
                    {
                        if (playerServiceId == null)
                        {
                            throw new Exception($"{nameof(playerServiceId)} is null");
                        }
                    
                        string payload = playerServiceId;
                        storeController.InitiatePurchase(productId, payload);
                    }
                    else
                    {
                        LobbyScene.Scripts.UiSoundsManager.Instance().PlayError();
                        log.Error($"Не удалось выполнить покупку потому, " +
                                  $"что {nameof(playerServiceId)} не доступен");
                    }
                   
                }
            }
            else
            {
                LobbyScene.Scripts.UiSoundsManager.Instance().PlayError();
                log.Error($"Вызов покупки был сделан до того как магазин " +
                          $"был инициализирован. {nameof(productId)} {productId}");
            }
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
        {
            log.Debug(nameof(ProcessPurchase)+" start");
            bool purchaseIsValid = true;
            string sku = e.purchasedProduct.definition.id;
            string token = null;
            
#if UNITY_ANDROID || UNITY_IOS || UNITY_STANDALONE_OSX
            CrossPlatformValidator validator = new CrossPlatformValidator(GooglePlayTangle.Data(),
                AppleTangle.Data(), Application.identifier);

            LogProduct(e.purchasedProduct);
           
            try 
            {
                IPurchaseReceipt[] result = validator.Validate(e.purchasedProduct.receipt);
                
                log.Debug("Receipt is valid. Contents:");
                foreach (IPurchaseReceipt productReceipt in result) 
                {
                    log.Debug(productReceipt.productID);
                    log.Debug(productReceipt.purchaseDate);
                    log.Debug(productReceipt.transactionID);

                    if (productReceipt is GooglePlayReceipt google) 
                    {
                        log.Debug(google.transactionID);
                        log.Debug(google.purchaseState);
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
#endif

            if (purchaseIsValid) 
            {
                // Unlock the appropriate content here.
                ValidateProduct(sku, token).ConfigureAwait(true);
            }
            
            return PurchaseProcessingResult.Pending;
        }

        public void OnPurchaseFailed(Product i, PurchaseFailureReason p)
        {
            log.Debug($"{nameof(OnPurchaseFailed)} "+p+" "+i.definition.id);
        }

        public void ConfirmAll()
        {
            log.Debug(nameof(ConfirmAll));
            var products = storeController.products.all;
            foreach (var product in products)
            {
                storeController.ConfirmPendingPurchase(product);
                log.Debug("success confirm "+product.definition.id);
            }
        }
        
        private bool TryConfirmRegisteredProduct(string productId)
        {
            bool success = false;
            log.Debug(nameof(TryConfirmRegisteredProduct));
            try
            {
                Product product = storeController.products.WithID(productId);
                log.Debug($"Продукт найден по id {nameof(productId)} {productId}");
                log.Debug("Подтверждение транзакции " + product.definition.id);
                storeController.ConfirmPendingPurchase(product);
                log.Debug("Транзакция успешно подтверджена");
                success = true;
            }
            catch (Exception e)
            {
                LobbyScene.Scripts.UiSoundsManager.Instance().PlayError();
                log.Error($"Не удалось подтвердить продукт {nameof(productId)} {productId}." +
                          $" {e.Message} {e.StackTrace}");
            }

            return success;
        }
        
        private async Task ValidateProduct(string productId, string token)
        {
            log.Debug(nameof(ValidateProduct));

            try
            {
                (string name, string value)[] fields = 
                {
                    (nameof(productId), productId),
                    (nameof(token), token)
                };
                //Отправка запроса на проверку и регистрацию покупки
                byte[] data = await HttpWrapper.Post(NetworkGlobals.ValidatePurchaseUrl, fields);
                log.Debug("Успешное выполнение запроса.");
                string[] result = ZeroFormatterSerializer.Deserialize<string[]>(data);
                //проверка нормального ответа от сервера
                if (result == null || result.Length == 0)
                {
                    LobbyScene.Scripts.UiSoundsManager.Instance().PlayError();
                    log.Fatal("Не удалось получить от сервера список продуктов, которые были им проверены.");
                    return;
                }

                //вызвать Confirm по полученным данным
                foreach (string sku in result)
                {
                    bool success = TryConfirmRegisteredProduct(sku);
                    if (success)
                    {
                        //уведомить сервер, что удалось сообщить о сохранении в UnityApi 
                        await SendConfirmationSuccessMessage(sku);
                    }
                    else
                    {
                        LobbyScene.Scripts.UiSoundsManager.Instance().PlayError();
                        log.Error($"Не удалось уведомить unity api о том, что продукт был сохранён в БД. " +
                                  $"{nameof(sku)} {sku}");
                    }
                }
            }
            catch (Exception exception)
            {
                LobbyScene.Scripts.UiSoundsManager.Instance().PlayError();
                log.Error(exception.Message);
            }
        }

        private async Task SendConfirmationSuccessMessage(string sku)
        {
            log.Debug(nameof(SendConfirmationSuccessMessage));
            log.Debug($"{nameof(sku)} {sku}");
            if (PlayerIdStorage.TryGetServiceId(out string serviceId))
            {
                log.Debug($"{nameof(serviceId)} {serviceId}");
                (string name, string value)[] fields = 
                {
                    (nameof(serviceId), serviceId),
                    (nameof(sku), sku)
                };
                try
                {
                    await HttpWrapper.Post(NetworkGlobals.MarkOrderAsCompletedUrl, fields);
                    log.Debug("Успешное выполнение запроса.");
                }
                catch (Exception e)
                {
                    LobbyScene.Scripts.UiSoundsManager.Instance().PlayError();
                    log.Error("Не удалось сообщить об отправке " +
                        $"сообщения об успешном подтверждении покупки {nameof(sku)} {sku} {e.Message} {e.StackTrace}");
                }
            }
            else
            {
                LobbyScene.Scripts.UiSoundsManager.Instance().PlayError();
                log.Error($"Не удалось получить {nameof(serviceId)} при отправке " +
                          $"сообщения об успешном подтверждении покупки {nameof(sku)} {sku}");
            }
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
                LobbyScene.Scripts.UiSoundsManager.Instance().PlayError();
                log.Error($"Не удалось получить стоимость продукта через api. " +
                          $"{nameof(sku)} {sku} {e.Message} {e.StackTrace}");
            }

            return false;
        }

        private void LogProduct(Product purchasedProduct)
        {
            log.Debug(nameof(LogProduct)+" "+purchasedProduct.definition.id);
            try
            {
                var definitionEnabled = purchasedProduct.definition.enabled;
                var definitionId = purchasedProduct.definition.id;
                var definitionPayout = purchasedProduct.definition.payout;

                if (purchasedProduct.definition.payout != null)
                {
                    var payoutData = purchasedProduct.definition.payout.data;
                    var payoutQuantity = purchasedProduct.definition.payout.quantity;
                    var payoutSubtype = purchasedProduct.definition.payout.subtype;
                    var payoutTypeString = purchasedProduct.definition.payout.typeString;
                    
                    // log.Debug($"{nameof(payoutData)} {payoutData}");
                    // log.Debug($"{nameof(payoutQuantity)} {payoutQuantity}");
                    // log.Debug($"{nameof(payoutSubtype)} {payoutSubtype}");
                    // log.Debug($"{nameof(payoutTypeString)} {payoutTypeString}");
                }
                
                var purchasedProductDefinition = purchasedProduct.definition;
                var purchasedProductReceipt = purchasedProduct.receipt;
                var purchasedProductHasReceipt = purchasedProduct.hasReceipt;
                var purchasedProductTransactionId = purchasedProduct.transactionID;
                var metadataLocalizedPrice = purchasedProduct.metadata.localizedPrice;
                var metadataLocalizedTitle = purchasedProduct.metadata.localizedTitle;
                var metadataIsoCurrencyCode = purchasedProduct.metadata.isoCurrencyCode;
                var metadataLocalizedPriceString = purchasedProduct.metadata.localizedPriceString;
                
                // log.Debug($"{nameof(definitionEnabled)} {definitionEnabled}");
                // log.Debug($"{nameof(definitionId)} {definitionId}");
                // log.Debug($"{nameof(definitionPayout)} {definitionPayout}");
                // log.Debug($"{nameof(purchasedProductDefinition)} {purchasedProductDefinition}");
                // log.Debug($"{nameof(purchasedProductReceipt)} {purchasedProductReceipt}");
                // log.Debug($"{nameof(purchasedProductHasReceipt)} {purchasedProductHasReceipt}");
                // log.Debug($"{nameof(purchasedProductTransactionId)} {purchasedProductTransactionId}");
                // log.Debug($"{nameof(metadataLocalizedPrice)} {metadataLocalizedPrice}");
                // log.Debug($"{nameof(metadataLocalizedTitle)} {metadataLocalizedTitle}");
                // log.Debug($"{nameof(metadataIsoCurrencyCode)} {metadataIsoCurrencyCode}");
                // log.Debug($"{nameof(metadataLocalizedPriceString)} {metadataLocalizedPriceString}");
            }
            catch (Exception exception)
            {
                LobbyScene.Scripts.UiSoundsManager.Instance().PlayError();
                log.Error(exception.Message);   
            }
        }
    }
}
