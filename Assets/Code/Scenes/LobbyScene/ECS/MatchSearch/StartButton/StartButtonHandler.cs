using Code.Common;
using Entitas;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.MatchSearch.StartButton
{
    public class StartButtonHandler:ReactiveSystem<LobbyUiEntity>
    {
        private readonly LobbyUiContext lobbyUiContext;
        private readonly GameObject battleLoadingMenu;
        private readonly UiSoundsManager lobbySoundsManager;

        public StartButtonHandler(LobbyUiContext context, GameObject battleLoadingMenu, UiSoundsManager lobbySoundsManager) : base(context)
        {
            lobbyUiContext = context;
            if (battleLoadingMenu == null)
            {
                throw new NullReferenceException($"{nameof(battleLoadingMenu)} was null");
            }
            this.battleLoadingMenu = battleLoadingMenu;
            this.lobbySoundsManager = lobbySoundsManager;
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.StartButtonClicked.Added());
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.isStartButtonClicked;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            ShowBattleLoadingMenu();
            UpdateStartButtonPressTime();
        }

        private void ShowBattleLoadingMenu()
        {
            battleLoadingMenu.SetActive(true);
            lobbySoundsManager.PlayStart();
        }
        
        private void UpdateStartButtonPressTime()
        {
            lobbyUiContext.ReplaceStartButtonPressTime(DateTime.Now);
        }
    }
}