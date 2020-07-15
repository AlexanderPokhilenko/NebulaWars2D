using System;
using System.Linq;
using Code.Common;
using Code.Scenes.LobbyScene.Scripts.Shop;
using DataLayer.Tables;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts
{
    /// <summary>
    /// Отвечает за создание раздела из префаба на сцене и его заполнение. 
    /// </summary>
    public class SectionSpawner:MonoBehaviour
    {
        private ShopUiStorage shopUiStorage;
        private SkinItemSpawner skinItemSpawner;
        private WarshipItemSpawner warshipItemSpawner;
        private LootboxItemsSpawner lootboxItemsSpawner;
        private DailyPresentItemSpawner dailyPresentItemSpawner;
        private SoftCurrencyItemSpawner softCurrencyItemSpawner;
        private HardCurrencyItemSpawner hardCurrencyItemSpawner;
        private ProductClickHandlerScript productClickHandlerScript;
        private WarshipPowerPointsItemSpawner warshipPowerPointsItemSpawner;
        private readonly ILog log = LogManager.CreateLogger(typeof(SectionSpawner));

        private void Awake()
        {
            shopUiStorage = FindObjectOfType<ShopUiStorage>()
                            ?? throw new Exception(nameof(ShopUiStorage)); 
            productClickHandlerScript = FindObjectOfType<ProductClickHandlerScript>()
                            ?? throw new Exception(nameof(ProductClickHandlerScript));

            skinItemSpawner = new SkinItemSpawner();
            warshipItemSpawner = new WarshipItemSpawner();
            lootboxItemsSpawner = new LootboxItemsSpawner();
            dailyPresentItemSpawner = new DailyPresentItemSpawner();
            softCurrencyItemSpawner = new SoftCurrencyItemSpawner();
            hardCurrencyItemSpawner = new HardCurrencyItemSpawner();
            warshipPowerPointsItemSpawner = new WarshipPowerPointsItemSpawner();
        }

        public void SpawnSection(SectionModel sectionModel)
        {
            bool success = new ShopSectionModelValidator().Validate(sectionModel);
            if (!success)
            {
                throw new Exception("Не знаю как отобразить этот раздел. "+sectionModel.HeaderName);
            }

            //спавн пустого раздела из префаба
            GameObject sectionPrefab = shopUiStorage.shopFlexibleSectionPrefab;
            Transform parent = shopUiStorage.shopSectionsParent.transform;
            GameObject sectionGo = Instantiate(sectionPrefab, parent, false);

            if (sectionModel.NeedFooterPointer)
            {
                sectionGo.name = sectionModel.HeaderName;
            }
            
            //Установить название раздела
            Text sectionHeader = sectionGo.transform.Find("Text_Header").GetComponent<Text>();
            sectionHeader.text = sectionModel.HeaderName;
            
            //Установить количество строк
            int linesCount;
            int yCellSize;
            var shopItemSizeEnum = sectionModel.UiItems.First().First().ShopItemSize;
            switch (shopItemSizeEnum)
            {
                case ProductSizeEnum.Big:
                    linesCount = 1;
                    yCellSize = 400;
                    break;
                case ProductSizeEnum.Small:
                    linesCount = 2;
                    yCellSize = 200;
                    break;
                default:
                    throw new Exception("Неизвестный размер элемента");
            }
            GridLayoutGroup gridLayoutGroup = sectionGo.GetComponent<GridLayoutGroup>();
            gridLayoutGroup.constraintCount = linesCount;
            gridLayoutGroup.cellSize = new Vector2(200, yCellSize);
            
            //Спавн предметов внутри раздела
            for (int yIndex = 0; yIndex < linesCount; yIndex++)
            {
                for (int xIndex = 0; xIndex < sectionModel.UiItems[yIndex].Length; xIndex++)
                {
                    ProductModel productModel = sectionModel.UiItems[yIndex][xIndex];
                    SpawnItem(productModel, sectionGo);
                }
            }
        }

        private void SpawnItem(ProductModel productModel, GameObject sectionGameObject)
        {
            switch (productModel.TransactionType)
            {
                case TransactionTypeEnum.Lootbox:
                    lootboxItemsSpawner.Spawn(productModel, sectionGameObject, productClickHandlerScript);
                    return;
                
                case TransactionTypeEnum.Skin:
                    skinItemSpawner.Spawn(productModel, sectionGameObject, productClickHandlerScript);
                    return;
                case TransactionTypeEnum.Warship:
                    warshipItemSpawner.Spawn(productModel, sectionGameObject, productClickHandlerScript);
                    break;
                case TransactionTypeEnum.WarshipAndSkin:
                    throw new ArgumentOutOfRangeException();
                case TransactionTypeEnum.WarshipPowerPoints:
                    warshipPowerPointsItemSpawner.Spawn(productModel, sectionGameObject, productClickHandlerScript);
                    return;
                case TransactionTypeEnum.HardCurrency:
                    hardCurrencyItemSpawner.Spawn(productModel, sectionGameObject, productClickHandlerScript);
                    return;
                case TransactionTypeEnum.SoftCurrency:
                    softCurrencyItemSpawner.Spawn(productModel, sectionGameObject, productClickHandlerScript);
                    return;
                case TransactionTypeEnum.DailyPrize:
                    dailyPresentItemSpawner.Spawn(productModel, sectionGameObject, productClickHandlerScript);
                    return;
                default:
                    throw new ArgumentOutOfRangeException(nameof(productModel.TransactionType));
            }
        }
    }
}