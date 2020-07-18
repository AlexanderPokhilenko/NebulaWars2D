using Code.Common;
using Code.Common.Logger;
using Code.Scenes.LootboxScene.ECS.Systems;
using Entitas;
using NetworkLibrary.NetworkLibrary.Http;
using System;
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
        private LootboxOpeningController lootboxOpenEffectController;
        private readonly ILog log = LogManager.CreateLogger(typeof(LootboxEcsController));

        private void Awake()
        {
            lobbyLoaderController = FindObjectOfType<LootboxSceneSwitcher>()
                                ?? throw new NullReferenceException(nameof(LootboxSceneSwitcher));
            lootboxUiStorage = FindObjectOfType<LootboxUiStorage>()
                                ?? throw new NullReferenceException(nameof(LootboxUiStorage));
            lootboxOpenEffectController = FindObjectOfType<LootboxOpeningController>()
                                ?? throw new NullReferenceException(nameof(LootboxOpeningController));
        }

        private void Start()
        {
            contexts = Contexts.sharedInstance;
            clickHandlerSystem = new ClickHandlerSystem(contexts, lobbyLoaderController, lootboxOpenEffectController,
                UiSoundsManager.Instance(), lootboxUiStorage);
            systems = new Systems()
                .Add(clickHandlerSystem)
                .Add(new ShowPrizeSystem(contexts, lootboxUiStorage))
                .Add(new ItemsLeftChangedSystem(contexts, lootboxUiStorage))
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
            systems.TearDown();
            contexts.lootbox.DestroyAllEntities();
        }

        public void CanvasButton_OnClick()
        {
            log.Debug("Click");
            LootboxEntity entity = contexts.lootbox.CreateEntity();
            entity.isCanvasClick = true;
        }
        
        public void SetLootboxModel(LootboxModel lootboxModel)
        {
            clickHandlerSystem.SetLootboxModel(lootboxModel);
        }
    }
}