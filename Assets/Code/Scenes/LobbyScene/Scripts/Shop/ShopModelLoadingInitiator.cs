using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Code.Common;
using Code.Scenes.DebugScene;
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
            Task<ShopModel> task = new ShowModelDownloader().GetShopModel(cts.Token);
            yield return new WaitUntil(()=>task.IsCompleted);
            
            if (task.IsCanceled || task.IsFaulted)
            {
                log.Error($"Не удалось скачать содержимое магазина. " +
                          $"{nameof(task.IsCanceled)} {task.IsCanceled}" +
                          $"{nameof(task.IsFaulted)} {task.IsFaulted}");
                yield break;
            }

            ShopModel shopModel = task.Result;
            
#if !UNITY_EDITOR
            log.Debug($"Ожидание инициализации {nameof(purchasingService)}");
            List<ForeignServiceProduct> realCurrencyProducts = shopModel.GetRealCurrencyProducts();
            purchasingService.StartInitialization(realCurrencyProducts);
            yield return new WaitUntil(purchasingService.IsStoreInitialized);
            log.Debug($"{nameof(purchasingService)} инициализирован");
            foreach (ProductModel item in shopModel.GetAllProducts())
            {
                if (item.CurrencyTypeEnum == CurrencyTypeEnum.RealCurrency)
                {
                    string productId = item.ForeignServiceProduct.ProductGoogleId;
                    string cost = null;
                    yield return new WaitUntil( ()=>purchasingService.TryGetProductCostById(productId, ref cost));
                    //Если не удалось достать цену
                    if (cost == null)
                    {
                        throw new Exception("Не удалось достать цену товара из плагина магазина");
                    }
                    else
                    {
                        item.CostString = cost;
                    }
                }    
            }
#endif
            
            shopUiSpawner.Spawn(shopModel);
        }

        private void OnDestroy()
        {
            cts?.Cancel();
        }
    }
}