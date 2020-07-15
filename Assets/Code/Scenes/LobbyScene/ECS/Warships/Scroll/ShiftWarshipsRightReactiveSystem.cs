using System.Collections.Generic;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.Scripts.UiStorages;
using Entitas;

namespace Code.Scenes.LobbyScene.ECS.Warships.Scroll
{
    /// <summary>
    /// Телепортирует все корабли влево при создании компонента.
    /// </summary>
    public class ShiftWarshipsRightReactiveSystem:ReactiveSystem<LobbyUiEntity>
    {
        private readonly LobbyUiContext lobbyUi;
        private readonly UiSoundsManager lobbySoundsManager;
        private readonly ILog log = LogManager.CreateLogger(typeof(ShiftWarshipsRightReactiveSystem));
        
        public ShiftWarshipsRightReactiveSystem(Contexts contexts, UiSoundsManager lobbySoundsManager) 
            : base(contexts.lobbyUi)
        {
            lobbyUi = contexts.lobbyUi;
            this.lobbySoundsManager = lobbySoundsManager;
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.ShiftWarshipsRightCommand.Added());
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.isShiftWarshipsRightCommand;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            if (lobbyUi.isBlockWarshipsShiftToTheRight)
            {
                log.Info($"Блок {nameof(ShiftWarshipsRightReactiveSystem)}");
            }
            else
            {
                //Сдвинуть индекс выбранного корабля
                int newIndex = --lobbyUi.currentWarshipIndex.value;
                lobbyUi.ReplaceCurrentWarshipIndex(newIndex);
                lobbySoundsManager.PlayWarshipChangingRight();
            }
        }
    }
}