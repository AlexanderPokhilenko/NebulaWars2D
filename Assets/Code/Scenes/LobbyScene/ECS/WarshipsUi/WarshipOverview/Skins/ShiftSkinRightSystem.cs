using Code.Common;
using Code.Common.Logger;
using Entitas;
using System.Collections.Generic;

namespace Code.Scenes.LobbyScene.ECS.WarshipsUi.WarshipOverview.Skins
{
    /// <summary>
    /// Отвечает за листание скинов
    /// </summary>
    public class ShiftSkinRightSystem : ReactiveSystem<LobbyUiEntity>
    {
        private readonly LobbyUiContext lobbyUiContext;
        private readonly UiSoundsManager lobbySoundsManager;
        private readonly ILog log = LogManager.CreateLogger(typeof(ShiftSkinRightSystem));

        public ShiftSkinRightSystem(Contexts contexts, UiSoundsManager lobbySoundsManager) 
            : base(contexts.lobbyUi)
        {
            lobbyUiContext = contexts.lobbyUi;
            this.lobbySoundsManager = lobbySoundsManager;
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.ShiftSkinRight);
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.messageShiftSkinRight;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            int currentSkinIndex = lobbyUiContext.warshipOverviewCurrentSkinIndex.index;
            if (currentSkinIndex == 0)
            {
                log.Warn("Нельзя сдвинуть скин вправо. Сейчас показывается крайний левый.");
            }
            else
            {
                lobbyUiContext.ReplaceWarshipOverviewCurrentSkinIndex(--currentSkinIndex);
                lobbySoundsManager.PlayWarshipChangingRight();
            }
        }
    }
}