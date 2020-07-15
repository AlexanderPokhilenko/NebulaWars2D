using System.Collections.Generic;
using Code.Scenes.LobbyScene.ECS.CommonLayoutSwitcher;
using Code.Scenes.LobbyScene.Scripts.WarshipsUi;
using Entitas;

namespace Code.Scenes.LobbyScene.ECS.WarshipsUi.WarshipOverviewModalWindow
{
    public class WarshipOverviewModalWindowDisablingSystem : ReactiveSystem<LobbyUiEntity>
    {
        private readonly WarshipsUiStorage warshipsUiStorage;
        private readonly LobbyLayoutSwitcher lobbyLayoutSwitcher;
        
        public WarshipOverviewModalWindowDisablingSystem(IContext<LobbyUiEntity> context, WarshipsUiStorage warshipsUiStorage,
            LobbyLayoutSwitcher lobbyLayoutSwitcher) 
            : base(context)
        {
            this.warshipsUiStorage = warshipsUiStorage;
            this.lobbyLayoutSwitcher = lobbyLayoutSwitcher;
        }
        
        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.DisableWarshipOverviewModalWindow);
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.messageDisableWarshipOverviewModalWindow;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            HideModalWindow();
            lobbyLayoutSwitcher.SetCurrentLayer(ShittyUiLayerState.WarshipOverview);
        }
        
        private void HideModalWindow()
        {
            warshipsUiStorage.popupWindow.SetActive(false);
        }
    }
}