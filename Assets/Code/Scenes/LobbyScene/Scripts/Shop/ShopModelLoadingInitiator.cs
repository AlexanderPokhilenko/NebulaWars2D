using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.Scripts.Shop.Spawners;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;

namespace Code.Scenes.LobbyScene.Scripts.Shop
{
    /// <summary>
    /// Точка входа в скрипты магазина.
    /// Скачивает данные для разметки магазина при входе в игру.
    /// </summary>
    public class ShopModelLoadingInitiator : MonoBehaviour
    {
        private ShopUiSpawner shopUiSpawner;
        private CancellationTokenSource cts;
        private PurchasingService purchasingService;
        private LobbyEcsController lobbyEcsController;
        private readonly ILog log = LogManager.CreateLogger(typeof(ShopModelLoadingInitiator));

        private void Awake()
        {
            shopUiSpawner = FindObjectOfType<ShopUiSpawner>()
                    ?? throw new NullReferenceException(nameof(ShopUiSpawner));
            purchasingService = FindObjectOfType<PurchasingService>()
                    ?? throw new NullReferenceException(nameof(PurchasingService));
        }
        
        private void Start()
        {
            StartCoroutine(LoadShop());
        }

        private IEnumerator LoadShop()
        {
            cts = new CancellationTokenSource();
            Task<ShopModel> loadShopModelTask = new ShowModelDownloader().GetShopModelAsync(cts.Token);
            yield return new WaitUntil(()=>loadShopModelTask.IsCompleted);
            if (loadShopModelTask.IsCanceled || loadShopModelTask.IsFaulted)
            {
                log.Error($"Не удалось скачать содержимое магазина. " +
                          $"{nameof(loadShopModelTask.IsCanceled)} {loadShopModelTask.IsCanceled}" +
                          $"{nameof(loadShopModelTask.IsFaulted)} {loadShopModelTask.IsFaulted}");
                yield break;
            }

            ShopModel shopModel = loadShopModelTask.Result;
#if !UNITY_EDITOR && UNITY_ANDROID
            Task<ShopModel> initProductCostTask = InitProductCostAsync(shopModel);
            yield return new WaitUntil(()=>initProductCostTask.IsCompleted);
            shopModel = initProductCostTask.Result;
#endif
            shopUiSpawner.Spawn(shopModel);
        }

        private async Task<ShopModel> InitProductCostAsync(ShopModel shopModel)
        {
            log.Debug($"Ожидание инициализации {nameof(purchasingService)}");
            List<ForeignServiceProduct> realCurrencyProducts = shopModel.GetRealCurrencyProducts();
            purchasingService.StartInitialization(realCurrencyProducts);
            await TaskExtensions.WaitUntil(purchasingService.IsStoreInitialized);
            log.Debug($"{nameof(purchasingService)} инициализирован");
            foreach (ProductModel item in shopModel.GetAllProducts())
            {
                if (item.CurrencyTypeEnum == CurrencyTypeEnum.RealCurrency)
                {
                    string productId = item.ForeignServiceProduct.ProductGoogleId;
                    string cost = null;
                    purchasingService.TryGetProductCostById(productId, ref cost);
                    if (cost == null)
                    {
                        throw new Exception("Не удалось достать цену товара из плагина магазина");
                    }

                    item.CostString = cost;
                }    
            }

            return shopModel;
        }
        
        private void OnDestroy()
        {
            cts?.Cancel();
        }
    }
}