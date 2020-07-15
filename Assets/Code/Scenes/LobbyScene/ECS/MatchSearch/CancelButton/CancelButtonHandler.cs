using System;
using System.Collections.Generic;
using Code.Scenes.LobbyScene.Scripts;
using Entitas;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.Systems.Reactive
{
    public class CancelButtonHandler:ReactiveSystem<LobbyUiEntity>
    {
        readonly LobbyUiContext lobbyUiContext;
        private readonly GameObject battleLoadingMenu;
        private readonly UiSoundsManager lobbySoundsManager;


        public CancelButtonHandler(LobbyUiContext context, GameObject battleLoadingMenu, UiSoundsManager lobbySoundsManager) : base(context)
        {
            lobbyUiContext = context;
            if (battleLoadingMenu == null)
            {
                throw new Exception($"{nameof(battleLoadingMenu)} was null");
            }
            this.battleLoadingMenu = battleLoadingMenu;
            this.lobbySoundsManager = lobbySoundsManager;
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.CancelButtonClicked.Added());
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.isCancelButtonClicked;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            if (lobbyUiContext.isStartButtonClicked)
            {
                lobbyUiContext.startButtonClickedEntity.Destroy();
            }

            if (lobbyUiContext.hasStartButtonPressTime)
            {
                lobbyUiContext.RemoveStartButtonPressTime();
            }
            battleLoadingMenu.SetActive(false);
            
            if (lobbyUiContext.hasMatchSearchDataForMenu)
            {
                lobbyUiContext.RemoveMatchSearchDataForMenu();
            }

            lobbySoundsManager.PlayStop();
        }
    }
}