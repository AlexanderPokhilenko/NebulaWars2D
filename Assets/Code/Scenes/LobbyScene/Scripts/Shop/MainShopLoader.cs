using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Code.Common;
using Code.Scenes.DebugScene;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;

namespace Code.Scenes.LobbyScene.Scripts
{
    /// <summary>
    /// Точка входа в скрипты магазина.
    /// Скачивает данные для разметки магазина при входе в игру.
    /// </summary>
    public class MainShopLoader : MonoBehaviour
    {
        private ShopUiSpawner shopUiSpawner;
        private CancellationTokenSource cts;
        private PurchasingService purchasingService;
        private LobbyEcsController lobbyEcsController;
        private readonly ILog log = LogManager.CreateLogger(typeof(MainShopLoader));

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

            List<ProductModel> productModels = shopModel.UiSections
                .SelectMany(container => container.UiItems)
                .SelectMany(test1=>test1)
                .ToList();
            List<ForeignServiceProduct> realCurrencyProducts = productModels
                .Where(productModel => productModel.CurrencyTypeEnum == CurrencyTypeEnum.RealCurrency)
                .Select(productModel => productModel.ForeignServiceProduct)
                .ToList();
            purchasingService.StartInitialization(realCurrencyProducts);
            log.Debug($"Ожидание инициализации {nameof(purchasingService)}");
            yield return new WaitUntil(purchasingService.IsStoreInitialized);
            log.Debug($"{nameof(purchasingService)} инициализирован");
            
            foreach (ProductModel item in productModels)
            {
                if (item.CurrencyTypeEnum == CurrencyTypeEnum.RealCurrency)
                {
                    string productId = item.ForeignServiceProduct.ProductGoogleId;
                    string cost = null;
                    yield return new WaitUntil( ()=>purchasingService
                        .TryGetProductCostById(productId, ref cost));
                    //Если не удалось достать цену
                    if (cost == null)
                    {
                        throw new Exception("Не удалось достать цену товара");
                    }
                    else
                    {
                        item.CostString = cost;
                    }
                }    
            }
            
            shopUiSpawner.Spawn(shopModel);
        }

        private void OnDestroy()
        {
            cts?.Cancel();
        }
    }
}