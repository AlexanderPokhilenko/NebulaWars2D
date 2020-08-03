using Code.Common;
using Entitas;
using System;
using System.Collections.Generic;
using Code.Scenes.LobbyScene.Scripts.UiStorages;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.MatchSearch.CancelButton
{
    public class CancelButtonHandler:ReactiveSystem<LobbyUiEntity>
    {
        readonly LobbyUiContext lobbyUiContext;
        private readonly GameObject gameViewsRoot;
        private readonly GameObject overlayCanvas;
        private readonly GameObject battleLoadingMenu;
        private readonly GameObject matchSearchCanvas;
        private readonly UiSoundsManager lobbySoundsManager;

        public CancelButtonHandler(LobbyUiContext context, LobbyUiStorage lobbyUiStorage,
            UiSoundsManager lobbySoundsManager)
            : base(context)
        {
            lobbyUiContext = context;
           
            battleLoadingMenu = lobbyUiStorage.battleLoadingMenu;
            matchSearchCanvas = lobbyUiStorage.matchSearchCanvas;
            overlayCanvas = lobbyUiStorage.overlayCanvas;
            gameViewsRoot = lobbyUiStorage.gameViewsRoot;
            
            if (battleLoadingMenu == null)
            {
                throw new Exception($"{nameof(battleLoadingMenu)} was null");
            }
            if (matchSearchCanvas == null)
            {
                throw new Exception($"{nameof(matchSearchCanvas)} was null");
            }
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
            if (lobbyUiContext.hasStartButtonClicked)
            {
                lobbyUiContext.RemoveStartButtonClicked();
            }
            
            battleLoadingMenu.SetActive(false);
            matchSearchCanvas.SetActive(false);
            overlayCanvas.SetActive(true);
            gameViewsRoot.SetActive(true);
            
            
            if (lobbyUiContext.hasMatchSearchDataForMenu)
            {
                lobbyUiContext.RemoveMatchSearchDataForMenu();
            }

            lobbySoundsManager.PlayStop();
        }
    }
}