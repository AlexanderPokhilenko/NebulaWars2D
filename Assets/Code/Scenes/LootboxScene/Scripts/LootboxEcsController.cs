using Code.Common;
using Code.Common.Logger;
using Code.Scenes.LootboxScene.ECS.Systems;
using Entitas;
using NetworkLibrary.NetworkLibrary.Http;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Scenes.LootboxScene.Scripts
{
    /// <summary>
    /// Создаёт/вызывает системы.
    /// Пропускает через себя нажатия на экран.
    /// </summary>
    public class LootboxEcsController : MonoBehaviour
    {
        private Systems systems;
        private Contexts contexts;
        private LootboxUiStorage lootboxUiStorage;
        private ClickHandlerSystem clickHandlerSystem;
        private LootboxSceneSwitcher lobbyLoaderController;
        private ParticlesColorUpdater particlesColorUpdater;
        private readonly ILog log = LogManager.CreateLogger(typeof(LootboxEcsController));

        private void Awake()
        {
            lobbyLoaderController = FindObjectOfType<LootboxSceneSwitcher>()
                                ?? throw new NullReferenceException(nameof(LootboxSceneSwitcher));
            lootboxUiStorage = FindObjectOfType<LootboxUiStorage>()
                                ?? throw new NullReferenceException(nameof(LootboxUiStorage));
            particlesColorUpdater = FindObjectOfType<ParticlesColorUpdater>()
                                ?? throw new NullReferenceException(nameof(ParticlesColorUpdater));
            lootboxUiStorage.Check();
        }

        private void Start()
        {
            contexts = Contexts.sharedInstance;
            clickHandlerSystem = new ClickHandlerSystem(contexts, lobbyLoaderController, 
                UiSoundsManager.Instance(), lootboxUiStorage);
            systems = new Systems()
                .Add(clickHandlerSystem)
                .Add(new ShowLootboxSystem(contexts.lootbox, lootboxUiStorage.lootboxPrefab, 
                    lootboxUiStorage.resourcesRoot.transform))
                .Add(new ShowPrizeSystem(contexts, particlesColorUpdater, lootboxUiStorage))
                .Add(new ItemsLeftChangedSystem(contexts, lootboxUiStorage))
                
                .Add(new ResourcesInitializeSystem(lootboxUiStorage))
                ;
            
            systems.Initialize();
        }

        private void Update()
        {
            systems.Execute();
            systems.Cleanup();
        }

        private void OnDestroy()
        {
            if (systems != null)
            {
                systems.DeactivateReactiveSystems();
                systems.TearDown();
                contexts.lootbox.DestroyAllEntities();
                systems.ClearReactiveSystems();    
            }
        }

        public void CanvasButton_OnClick()
        {
            log.Info("Click");
            LootboxEntity entity = contexts.lootbox.CreateEntity();
            entity.isCanvasClick = true;
        }
        
        public void SetResourceModels(List<ResourceModel> resourceModels)
        {
            clickHandlerSystem.SetResourceModels(resourceModels);
        }

        public void ShowLootbox()
        {
            contexts.lootbox.CreateEntity().isShowLootbox = true;
        }
    }
}