using Code.Common;
using Entitas;
using System;
using System.Collections.Generic;
using Code.Scenes.LobbyScene.Scripts.UiStorages;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.MatchSearch.StartButton
{
    public class StartButtonHandler:ReactiveSystem<LobbyUiEntity>
    {
        private readonly GameObject gameViewsRoot;
        private readonly GameObject overlayCanvas;
        private readonly GameObject matchSearchCanvas;
        private readonly GameObject battleLoadingMenu;
        private readonly LobbyUiContext lobbyUiContext;
        private readonly UiSoundsManager lobbySoundsManager;

        public StartButtonHandler(LobbyUiContext context, LobbyUiStorage lobbyUiStorage, UiSoundsManager lobbySoundsManager) 
            : base(context)
        {
            lobbyUiContext = context;
           
            battleLoadingMenu = lobbyUiStorage.battleLoadingMenu;
            matchSearchCanvas = lobbyUiStorage.matchSearchCanvas;
            overlayCanvas = lobbyUiStorage.overlayCanvas;
            gameViewsRoot = lobbyUiStorage.gameViewsRoot;
            
            if (battleLoadingMenu == null)
            {
                throw new NullReferenceException($"{nameof(battleLoadingMenu)} was null");
            }  
            if (matchSearchCanvas == null)
            {
                throw new NullReferenceException($"{nameof(matchSearchCanvas)} was null");
            }
            
            this.lobbySoundsManager = lobbySoundsManager;
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.StartButtonClicked.Added());
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.hasStartButtonClicked;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            ShowBattleLoadingMenu();
        }

        private void ShowBattleLoadingMenu()
        {
            matchSearchCanvas.SetActive(true);
            battleLoadingMenu.SetActive(true);
            overlayCanvas.SetActive(false);
            gameViewsRoot.SetActive(false);
            lobbySoundsManager.PlayStart();
        }
    }
}