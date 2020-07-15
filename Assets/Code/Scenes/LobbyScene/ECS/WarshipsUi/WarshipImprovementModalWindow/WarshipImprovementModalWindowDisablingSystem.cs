using System.Collections.Generic;
using System.Linq;
using Code.Common;
using Code.Scenes.LobbyScene.ECS.Components.CommonLayoutSwitcher;
using Code.Scenes.LobbyScene.Scripts;
using Entitas;
using NetworkLibrary.NetworkLibrary.Http;

namespace Code.Scenes.LobbyScene.ECS.Components.WarshipsUi.WarshipOverview
{
    public class WarshipImprovementModalWindowDisablingSystem : ReactiveSystem<LobbyUiEntity>
    {
        private readonly WarshipsUiStorage warshipsUiStorage;
        private readonly LobbyLayoutSwitcher lobbyLayoutSwitcher;
        private readonly ILog log = LogManager.CreateLogger(typeof(WarshipImprovementModalWindowDisablingSystem));
        
        public WarshipImprovementModalWindowDisablingSystem(IContext<LobbyUiEntity> context, 
            WarshipsUiStorage warshipsUiStorage, LobbyLayoutSwitcher lobbyLayoutSwitcher) 
            : base(context)
        {
            this.warshipsUiStorage = warshipsUiStorage;
            this.lobbyLayoutSwitcher = lobbyLayoutSwitcher;
        }
        
        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.DisableWarshipImprovementModalWindow);
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.messageDisableWarshipImprovementModalWindow;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            HideModalWindow();
            lobbyLayoutSwitcher.SetCurrentLayer(ShittyUiLayerState.WarshipOverview);
        }
        
        private void HideModalWindow()
        {
            //todo скрыть окно с характеристиками
            warshipsUiStorage.popupWindow.SetActive(false);
        }
    }
}