using System.Collections.Generic;
using Code.Scenes.LobbyScene.ECS.CommonLayoutSwitcher;
using Code.Scenes.LobbyScene.Scripts.UiStorages;
using Code.Scenes.LobbyScene.Scripts.WarshipsUi;
using Entitas;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.ECS.WarshipsUi.WarshipList
{
    /// <summary>
    /// Отвечает за включение слоя со списком кораблей
    /// </summary>
    public class WarshipListEnablingSystem:ReactiveSystem<LobbyUiEntity>
    {
        private readonly UiLayersStorage uiLayersStorage;
        private readonly WarshipsUiStorage warshipsUiStorage;
        private readonly LobbyLayoutSwitcher lobbyLayoutSwitcher;

        public WarshipListEnablingSystem(IContext<LobbyUiEntity> context, LobbyLayoutSwitcher lobbyLayoutSwitcher,
             UiLayersStorage uiLayersStorage) 
            : base(context)
        {
            this.lobbyLayoutSwitcher = lobbyLayoutSwitcher;
            this.uiLayersStorage = uiLayersStorage;
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.EnableWarshipListUiLayer);
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.messageEnableWarshipListUiLayer;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            EnableWarshipsLayer();
            lobbyLayoutSwitcher.SetCurrentLayer(ShittyUiLayerState.WarshipsList);
        }
        
        private void EnableWarshipsLayer()
        {
            uiLayersStorage.sectionText.GetComponent<Text>().text = "WARSHIPS";
            
            uiLayersStorage.backButton.SetActive(true);  
            uiLayersStorage.sectionText.SetActive(true);
            
            uiLayersStorage.layer0RootGameObject.SetActive(false);
            uiLayersStorage.lootboxRootGameObject.SetActive(false);
            uiLayersStorage.warshipsRootGameObject.SetActive(false);
            uiLayersStorage.shopLayerRootGameObject.SetActive(false);
            
            uiLayersStorage.warshipsUiLayerRootGameObject.SetActive(true);
        }
    }
}
