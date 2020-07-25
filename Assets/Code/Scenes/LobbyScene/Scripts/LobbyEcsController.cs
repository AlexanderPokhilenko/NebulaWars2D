using System;
using System.Collections.Generic;
using System.Linq;
using Code.Common;
using Code.Common.Logger;
using Code.Scenes.BattleScene.ECS.Systems.TearDownSystems;
using Code.Scenes.BattleScene.ECS.Systems.ViewSystems;
using Code.Scenes.LobbyScene.ECS;
using Code.Scenes.LobbyScene.ECS.AccountData.AccountDataChangingHandlers;
using Code.Scenes.LobbyScene.ECS.AccountData.MovingAwards;
using Code.Scenes.LobbyScene.ECS.AccountData.MovingAwards.Images;
using Code.Scenes.LobbyScene.ECS.AccountData.MovingAwards.MovingAwardsText;
using Code.Scenes.LobbyScene.ECS.Blur;
using Code.Scenes.LobbyScene.ECS.Clear;
using Code.Scenes.LobbyScene.ECS.CommonLayoutSwitcher;
using Code.Scenes.LobbyScene.ECS.LobbySceneUi;
using Code.Scenes.LobbyScene.ECS.MatchSearch;
using Code.Scenes.LobbyScene.ECS.MatchSearch.CancelButton;
using Code.Scenes.LobbyScene.ECS.MatchSearch.StartButton;
using Code.Scenes.LobbyScene.ECS.Shop.Layer;
using Code.Scenes.LobbyScene.ECS.Shop.PurchaseConfirmationWindow;
using Code.Scenes.LobbyScene.ECS.Warships;
using Code.Scenes.LobbyScene.ECS.WarshipsUi;
using Code.Scenes.LobbyScene.ECS.WarshipsUi.WarshipImprovementModalWindow;
using Code.Scenes.LobbyScene.ECS.WarshipsUi.WarshipList;
using Code.Scenes.LobbyScene.ECS.WarshipsUi.WarshipOverview;
using Code.Scenes.LobbyScene.ECS.WarshipsUi.WarshipOverview.Skins;
using Code.Scenes.LobbyScene.ECS.WarshipsUi.WarshipOverviewModalWindow;
using Code.Scenes.LobbyScene.Scripts.Shop;
using Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow;
using Code.Scenes.LobbyScene.Scripts.Shop.Spawners;
using Code.Scenes.LobbyScene.Scripts.UiStorages;
using Code.Scenes.LobbyScene.Scripts.WarshipsUi;
using Entitas;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;

namespace Code.Scenes.LobbyScene.Scripts
{
    
    /// <summary>
    /// Создаёт ecs системы
    /// Вызывает системы
    /// Пропускает через себя запросы на создание компонентов 
    /// </summary>
    public class LobbyEcsController : MonoBehaviour
    {
        private Systems systems;
        private Contexts contexts;
        private ShopUiSpawner shopUiSpawner;
        private ShopUiStorage shopUiStorage;
        private LobbyUiStorage lobbyUiStorage;
        private UiLayersStorage uiLayersStorage;
        private WarshipsUiStorage warshipsUiStorage;
        private LobbySceneSwitcher lobbySceneSwitcher;
        private LobbyLayoutSwitcher lobbyLayoutSwitcher;
        private WarshipSpawnerSystem warshipSpawnerSystem;
        private MovingAwardsMainSystem movingAwardsMainSystem;
        private InGameCurrencyPaymaster inGameCurrencyPaymaster;
        private MovingAwardsUiElementsStorage movingAwardsUiStorage;
        private MatchSearchDataUpdaterSystem matchSearchDataUpdaterSystem;
        private MovingIconsDataCreationSystem movingIconsDataCreationSystem;
        private AccountDataComponentsCreatorSystem accountDataComponentsCreatorSystem;
        private readonly ILog log = LogManager.CreateLogger(typeof(LobbyEcsController));
        private StartCancelMatchComponentsCreatorSystem startCancelMatchComponentsCreatorSystem;

        private void Awake()
        {
            lobbyUiStorage = FindObjectOfType<LobbyUiStorage>()
                            ?? throw new NullReferenceException(nameof(LobbyUiStorage));
            uiLayersStorage = FindObjectOfType<UiLayersStorage>()
                            ?? throw new NullReferenceException(nameof(UiLayersStorage));
            shopUiStorage = FindObjectOfType<ShopUiStorage>()
                            ?? throw new NullReferenceException(nameof(ShopUiStorage));
            movingAwardsUiStorage = FindObjectOfType<MovingAwardsUiElementsStorage>()
                            ?? throw new NullReferenceException(nameof(MovingAwardsUiElementsStorage));
            warshipsUiStorage = FindObjectOfType<WarshipsUiStorage>()
                            ?? throw new NullReferenceException(nameof(WarshipsUiStorage));
            shopUiSpawner = FindObjectOfType<ShopUiSpawner>()
                            ?? throw new NullReferenceException(nameof(shopUiSpawner));
            lobbySceneSwitcher = FindObjectOfType<LobbySceneSwitcher>()
                            ?? throw new NullReferenceException(nameof(lobbySceneSwitcher));
            inGameCurrencyPaymaster = FindObjectOfType<InGameCurrencyPaymaster>()
                            ?? throw new NullReferenceException(nameof(inGameCurrencyPaymaster));
        }

        private void Start()
        {
            lobbyUiStorage.Check();
            uiLayersStorage.Check();
            movingAwardsUiStorage.Check();
            warshipsUiStorage.Check();

            contexts = Contexts.sharedInstance;
            
            warshipSpawnerSystem = new WarshipSpawnerSystem(contexts, lobbyUiStorage.warshipsRoot);
            accountDataComponentsCreatorSystem = new AccountDataComponentsCreatorSystem(contexts);

            startCancelMatchComponentsCreatorSystem = new StartCancelMatchComponentsCreatorSystem(contexts.lobbyUi);
            matchSearchDataUpdaterSystem = new MatchSearchDataUpdaterSystem(contexts);
            
            movingIconsDataCreationSystem = new MovingIconsDataCreationSystem(contexts,
                movingAwardsUiStorage.movingAwardImageParentRectTransform);
            
            movingAwardsMainSystem = new MovingAwardsMainSystem(contexts);

            lobbyLayoutSwitcher = new LobbyLayoutSwitcher(contexts.lobbyUi);
            systems = new Systems()
                    
                    //Движение наград
                    .Add(movingAwardsMainSystem)
                    
                    //Движение текта
                    .Add(new MovingAwardsTextCreationSystem(contexts))
                    .Add(new MovingAwardsTextSpawnSystem(contexts, movingAwardsUiStorage.movingAwardTextParentRectTransform))
                    .Add(new MovingAwardsTextDataUpdaterSystem(contexts))
                    .Add(new MovingAwardsTextGameObjectUpdaterSystem(contexts))
                    .Add(new MovingAwardsTextDeleteSystem(contexts))
                    
                    //Движение наград
                    .Add(movingIconsDataCreationSystem)
                    .Add(new MovingIconInstantiatorSystem(contexts,  movingAwardsUiStorage.movingAwardImageParentRectTransform))
                    .Add(new MovingIconDataUpdaterSystem(contexts))
                    .Add(new MovingIconsUpdaterSystem(contexts, movingAwardsUiStorage.movingAwardImageUpperObject))
                    .Add(new MovingIconDestroySystem(contexts))
                    
                    //Поиск матча
                    .Add(matchSearchDataUpdaterSystem)
                    .Add(new MatchSearchTimeUpdaterSystem(contexts.lobbyUi,lobbyUiStorage.waitTimeText))
                    .Add(new MatchSearchMenuUpdaterSystem(contexts.lobbyUi,
                        lobbyUiStorage.numberOfPlayersInQueueText, lobbyUiStorage.numberOfPlayersInBattlesText))
                    
                    //Обработка start/stop
                    .Add(startCancelMatchComponentsCreatorSystem)
                    .Add(new StartButtonHandler(contexts.lobbyUi, lobbyUiStorage.battleLoadingMenu, lobbyUiStorage.lobbySoundsManager))
                    .Add(new CancelButtonHandler(contexts.lobbyUi, lobbyUiStorage.battleLoadingMenu, lobbyUiStorage.lobbySoundsManager))
                    
                    //Установка размытия при поике матча
                    .Add(new BlurInitializeSystem(contexts.lobbyUi))
                    .Add(new BlurImageStateUpdaterSystem(contexts.lobbyUi))
                    .Add(new BlurValueUpdatingSystem(contexts.lobbyUi, lobbyUiStorage.blurMaterial, lobbyUiStorage.uiBlurDefaultMaterial, !lobbyUiStorage.blurIsActive))
                    .Add(new BlurImageDisableHandler(contexts.lobbyUi, lobbyUiStorage.blurImage.gameObject))
                    .Add(new BlurImageEnableHandler(contexts.lobbyUi, lobbyUiStorage.blurImage.gameObject))
                    
                    //Анимация кнопки START
                    .Add(new StartButtonAnimationSystem(contexts.lobbyUi, lobbyUiStorage.startButtonSatellites))

                    //Обновление статистики в ui (валюты, рейтинг, сундуки)
                    .Add(accountDataComponentsCreatorSystem)
                    .Add(new HardCurrencyChangingHandler(contexts.lobbyUi, lobbyUiStorage.hardCurrencyText))
                    .Add(new SoftCurrencyChangingHandler(contexts.lobbyUi, lobbyUiStorage.softCurrencyText))
                    .Add(new UsernameChangingHandler(contexts.lobbyUi, lobbyUiStorage.usernameText))
                    .Add(new LootboxPointsChangingHandler(contexts.lobbyUi, lobbyUiStorage.smallLootboxText,  lobbyUiStorage.smallLootboxPinGameObject, lobbyUiStorage.smallLootboxPinText))
                    .Add(new LootboxSliderChangingHandler(contexts.lobbyUi, lobbyUiStorage.lootboxSlider))
                    .Add(new AccountRatingChangingHandler(contexts.lobbyUi, lobbyUiStorage.accountRatingText))
                    
                    //Отрисовка кораблей
                    .Add(warshipSpawnerSystem)
                    .Add(new RenderSpriteSystem(contexts))
                    .Add(new RenderTransformSystem(contexts))
                    .Add(new SetAnimatorSystem(contexts))
                    
                    //Заполненеи списка кораблей
                    .Add(new WarshipListFillerSystem(contexts, warshipsUiStorage, this))
                    
                    //Листание кораблей
                    .Add(new WarshipsMoverSystem(contexts))
                    //Обновление рейтинга и ранга для текущего корабля
                    .Add(new WarshipDataUpdaterSystem(contexts, lobbyUiStorage.rankText,
                        lobbyUiStorage.ratingText, lobbyUiStorage.ratingSlider))

                    //Переключение слоёв ui 
                    .Add(lobbyLayoutSwitcher)
                    
                    //Магазин
                    .Add(new ShopUiLayerEnablingSystem(contexts.lobbyUi,uiLayersStorage, shopUiStorage, lobbyLayoutSwitcher, shopUiSpawner))
                    .Add(new ShopUiLayerDisablingSystem(contexts.lobbyUi,uiLayersStorage, lobbyLayoutSwitcher))
                    .Add(new PurchaseConfirmationWindowEnablingSystem(contexts.lobbyUi, this, inGameCurrencyPaymaster, shopUiStorage))
                    .Add(new PurchaseConfirmationWindowDisablingSystem(contexts.lobbyUi, shopUiStorage))
                    
                    //Список кораблей
                    .Add(new WarshipListEnablingSystem(contexts.lobbyUi, lobbyLayoutSwitcher,  uiLayersStorage))
                    .Add(new WarshipListDisablingSystem(contexts.lobbyUi, lobbyLayoutSwitcher,  uiLayersStorage))
                    
                    //Обзор корабля
                    .Add(new WarshipOverviewEnablingSystem(contexts, warshipsUiStorage, lobbyLayoutSwitcher, this))
                    .Add(new WarshipOverviewDisablingSystem(contexts.lobbyUi, warshipsUiStorage, lobbyLayoutSwitcher))
                    
                    //Переключение скинов корабля
                    .Add(new ShiftSkinRightSystem(contexts, lobbyUiStorage.lobbySoundsManager))
                    .Add(new ShiftSkinLeftSystem(contexts, lobbyUiStorage.lobbySoundsManager))
                    .Add(new SkinButtonsSwitcherSystem(contexts, warshipsUiStorage))
                    .Add(new SkinSwitcherSystem(contexts, warshipsUiStorage))
                    
                    
                    //Модальное окно с характеристиками корабля
                    .Add(new WarshipOverviewModalWindowEnablingSystem(contexts.lobbyUi, warshipsUiStorage, lobbyLayoutSwitcher))
                    .Add(new WarshipOverviewModalWindowDisablingSystem(contexts.lobbyUi, warshipsUiStorage,lobbyLayoutSwitcher))
                    
                    //Модальное окно улучшения корабля
                    .Add(new WarshipImprovementModalWindowEnablingSystem(contexts.lobbyUi, warshipsUiStorage, lobbyLayoutSwitcher, lobbySceneSwitcher))
                    .Add(new WarshipImprovementModalWindowDisablingSystem(contexts.lobbyUi, warshipsUiStorage, lobbyLayoutSwitcher))
                    
                    //Слушатель кнопки покупки улучшения
                    .Add(new WarshipImproveOnClickSystem(contexts.lobbyUi))
                    
                    //Показ начисления наград
                    .Add(new LobbySceneUiEnablingSystem(contexts.lobbyUi, lobbyUiStorage))
                    .Add(new LobbySceneUiDisablingSystem(contexts.lobbyUi, lobbyUiStorage))
                    
                    //Очистка
                    .Add(new ContextsClearSystem(contexts))
                    .Add(new ClearLobbyUiSystem(contexts.lobbyUi))
                ;
            
        
            systems.ActivateReactiveSystems();    
            systems.Initialize();
            
            contexts.lobbyUi.CreateEntity().messageDisableWarshipImprovementModalWindow = true;
            contexts.lobbyUi.CreateEntity().messageDisableWarshipOverviewModalWindow = true;
            contexts.lobbyUi.CreateEntity().messageDisableWarshipOverviewUiLayer = true;
            contexts.lobbyUi.CreateEntity().messageDisableWarshipListUiLayer = true;
            contexts.lobbyUi.CreateEntity().messageDisableShopUiLayer = true;
        }

        private void Update()
        {
            if (systems != null)
            {
                systems.Execute();
                systems.Cleanup();
            }
            else
            {
                log.Error($"{nameof(systems)} was null");
            }
        }

        private void OnDestroy()
        {
            if (systems != null)
            {
                systems.DeactivateReactiveSystems();
                systems.TearDown();
                systems.ClearReactiveSystems();    
            }
        }
     
        public void ShiftWarshipsRight()
        {
            contexts.lobbyUi.CreateEntity().isShiftWarshipsRightCommand = true;
        }
        
        public void ShiftWarshipsLeft()
        {
            contexts.lobbyUi.CreateEntity().isShiftWarshipsLeftCommand = true;
        }
        
        public bool IsWarshipsCreationCompleted()
        {
            return warshipSpawnerSystem != null && warshipSpawnerSystem.IsWarshipCreationCompleted();
        }
        
        public void CreateUnshownRewardsComponent(RewardsThatHaveNotBeenShown rewardsThatHaveNotBeenShown)
        {
            movingAwardsMainSystem.CreateAwards(rewardsThatHaveNotBeenShown);
        }
        
        public void SetAccountData(AccountDto accountData)
        {
            accountDataComponentsCreatorSystem.SetAccountData(accountData);
            PlayerIdStorage.AccountId = accountData.AccountId;
        }

        public int GetCurrentWarshipId()
        {
            return accountDataComponentsCreatorSystem.GetCurrentWarshipId();
        }

        public void Button_Start_Click()
        {
            startCancelMatchComponentsCreatorSystem.Button_Start_Click();
        }

        public void Button_Cancel_Click()
        {
            startCancelMatchComponentsCreatorSystem.Button_Cancel_Click();
        }

        public void SetNewMatchSearchData(int responseNumberOfPlayersInQueue, int responseNumberOfPlayersInBattles)
        {
            matchSearchDataUpdaterSystem.SetNewData(responseNumberOfPlayersInQueue, responseNumberOfPlayersInBattles);
        }

        public bool LootboxCanBeOpened()
        {
            return contexts.lobbyUi.pointsForSmallLootbox.value>=100;
        }

        public void BackButton_OnClick()
        {
            UiSoundsManager.Instance().PlayClick();
            contexts.lobbyUi.CreateEntity().messageBackButtonPressed = true;
        }
        
        public void PhysicalBackButton_OnClick()
        {
            log.Debug(nameof(PhysicalBackButton_OnClick));
        }

        public void ShopButton_OnClick()
        {
            contexts.lobbyUi.CreateEntity().messageEnableShopUiLayer = true;
        }

        public void ShowWarshipList()
        {
            contexts.lobbyUi.CreateEntity().messageEnableWarshipListUiLayer = true;
        }

        public ushort GetWarshipIndexById(int warshipId)
        {
            foreach (WarshipComponent warshipComponent in contexts.lobbyUi
                .GetGroup(LobbyUiMatcher.Warship).AsEnumerable().Select((entity=>entity.warship)))
            {
                if (warshipComponent.warshipDto.Id == warshipId)
                {
                    return warshipComponent.index;
                }
            }
            
            throw new Exception("В лобби нет такого корабля");
        }
        
        public void ShowWarshipOverviewById(int warshipId)
        {
            var warshipDto = contexts.lobbyUi
                .GetGroup(LobbyUiMatcher.Warship)
                .AsEnumerable()
                .Last(entity => entity.warship.warshipDto.Id == warshipId).warship.warshipDto;
            
            contexts.lobbyUi.CreateEntity().AddEnableWarshipOverviewUiLayer(warshipDto);
        }
        
        public void ShowWarshipOverview(WarshipDto warshipDto)
        {
            contexts.lobbyUi.CreateEntity().AddEnableWarshipOverviewUiLayer(warshipDto);
        }

        public void ShowWarshipImprovementModalWindow(WarshipDto warshipDto)
        {
            contexts.lobbyUi.CreateEntity().AddEnableWarshipImprovementModalWindow(warshipDto);
        }

        public void ShowWarshipCharacteristics(WarshipDto warshipDto)
        {
            contexts.lobbyUi.CreateEntity().AddEnableWarshipOverviewModalWindow(warshipDto);
        }

        public bool IsSoftCurrencyReady()
        {
            return contexts.lobbyUi.hasSoftCurrency;
        }
        
        public int GetSoftCurrency()
        {
            if (contexts.lobbyUi.hasSoftCurrency)
            {
                return contexts.lobbyUi.softCurrency.value;
            }

            return 0;
        }
        
        public int GetHardCurrency()
        {
            return contexts.lobbyUi.hardCurrency.value;
        }

        public void ShiftSkinLeft()
        {
            contexts.lobbyUi.CreateEntity().messageShiftSkinLeft = true;
        }

        public void ShiftSkinRight()
        {
            contexts.lobbyUi.CreateEntity().messageShiftSkinRight = true;
        }

        public void ClosePurchaseConfirmationWindow()
        {
            contexts.lobbyUi.CreateEntity().isDisablePurchaseConfirmationWindow = true;
        }

        public void ShowPurchaseConfirmationWindow(PurchaseModel purchaseModel)
        {
            contexts.lobbyUi.CreateEntity().AddEnablePurchaseConfirmationWindow(purchaseModel);
        }

        public void DisableLobbySceneUi()
        {
            contexts.lobbyUi.CreateEntity().isDisableLobbySceneUi = true;
        } 
        
        public void EnableLobbySceneUi()
        {
            contexts.lobbyUi.CreateEntity().isEnableLobbySceneUi = true;
        }

        public void CloseShopLayer()
        {
            contexts.lobbyUi.CreateEntity().messageDisableShopUiLayer = true;
        }
    }
}