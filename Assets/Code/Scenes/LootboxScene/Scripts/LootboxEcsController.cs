using System;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.Scripts.UiStorages;
using Code.Scenes.LootboxScene.ECS.Systems;
using Entitas;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;

namespace Code.Scenes.LootboxScene.Scripts
{
    /// <summary>
    /// Создаёт/вызывает ситемы.
    /// Пропускает через себя нажатия на экран.
    /// </summary>
    public class LootboxEcsController : MonoBehaviour
    {
        private Systems systems;
        private Contexts contexts;
        private UiSoundsManager uiSoundsManager;
        private LootboxUiStorage lootboxUiStorage;
        private ChangePrizeSystem changePrizeSystem;
        private LootboxSceneSwitcher lobbyLoaderController;
        private LootboxOpenEffectController lootboxOpenEffectController;
        private readonly ILog log = LogManager.CreateLogger(typeof(LootboxEcsController));
        private bool firstClick = true;

        private void Awake()
        {
            uiSoundsManager = UiSoundsManager.Instance();
            lobbyLoaderController = FindObjectOfType<LootboxSceneSwitcher>()
                                    ?? throw new Exception("Не удалось найти контроллер");
            lootboxUiStorage = FindObjectOfType<LootboxUiStorage>()
                                    ?? throw new Exception("Не удалось найти контроллер");
            lootboxOpenEffectController = FindObjectOfType<LootboxOpenEffectController>()
                                          ?? throw new Exception("Не удалось найти контроллер");
        }

        private void Start()
        {
            contexts = Contexts.sharedInstance;
            changePrizeSystem = new ChangePrizeSystem(contexts, lobbyLoaderController);
            systems = new Systems()
                .Add(changePrizeSystem)
                .Add(new ShowPrizeSystem(contexts, lootboxUiStorage.text))
                ;
        }

        private void Update()
        {
            systems.Execute();
            systems.Cleanup();
        }

        private void OnDestroy()
        {
            systems.TearDown();
        }

        public void CanvasButton_OnClick()
        {
            log.Debug("Click");
            if (firstClick)
            {
                uiSoundsManager.PlayLootbox();
                firstClick = false;
            }
            lootboxOpenEffectController.OpenLootbox();
            LootboxEntity entity = contexts.lootbox.CreateEntity();
            entity.isCanvasClick = true;
        }
        
        public void SetLootboxData(LootboxModel lootboxModel)
        {
            changePrizeSystem.SetLootboxData(lootboxModel);
        }
    }
}