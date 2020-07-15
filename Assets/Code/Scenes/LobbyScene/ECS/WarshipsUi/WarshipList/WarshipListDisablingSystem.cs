using System.Collections.Generic;
using Code.Scenes.LobbyScene.ECS.CommonLayoutSwitcher;
using Code.Scenes.LobbyScene.Scripts.UiStorages;
using Entitas;

namespace Code.Scenes.LobbyScene.ECS.WarshipsUi.WarshipList
{
    /// <summary>
    /// Отвечает за выключение слоя со списком кораблей
    /// </summary>
    public class WarshipListDisablingSystem : ReactiveSystem<LobbyUiEntity>
    {
        private readonly LobbyLayoutSwitcher lobbyLayoutSwitcher;
        private readonly UiLayersStorage uiLayersStorage;

        public WarshipListDisablingSystem(IContext<LobbyUiEntity> context, LobbyLayoutSwitcher lobbyLayoutSwitcher,
            UiLayersStorage uiLayersStorage)
            : base(context)
        {
            this.lobbyLayoutSwitcher = lobbyLayoutSwitcher;
            this.uiLayersStorage = uiLayersStorage;
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.DisableWarshipListUiLayer);
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.messageDisableWarshipListUiLayer;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            DisableWarshipsLayer();
            lobbyLayoutSwitcher.SetCurrentLayer(ShittyUiLayerState.DefaultLayer);
        }
        
        private void DisableWarshipsLayer()
        {
            uiLayersStorage.backButton.SetActive(false);  
            uiLayersStorage.sectionText.SetActive(false);
            
            uiLayersStorage.layer0RootGameObject.SetActive(true);
            uiLayersStorage.lootboxRootGameObject.SetActive(true);
            uiLayersStorage.warshipsRootGameObject.SetActive(true);
            
            uiLayersStorage.warshipsUiLayerRootGameObject.SetActive(false);
        }
    }
}