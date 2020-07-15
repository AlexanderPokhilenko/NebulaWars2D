using System.Collections.Generic;
using Code.Common;
using Code.Scenes.LobbyScene.Scripts;
using Entitas;

namespace Code.Scenes.LobbyScene.ECS.Systems.Reactive
{
    /// <summary>
    /// Телепортирует все корабли вправо
    /// </summary>
    public class ShiftWarshipsLeftReactiveSystem:ReactiveSystem<LobbyUiEntity>
    {
        private readonly LobbyUiContext lobbyUi;
        private readonly UiSoundsManager lobbySoundsManager;
        private readonly ILog log = LogManager.CreateLogger(typeof(ShiftWarshipsLeftReactiveSystem));
        
        public ShiftWarshipsLeftReactiveSystem(Contexts contexts, UiSoundsManager lobbySoundsManager) 
            : base(contexts.lobbyUi)
        {
            lobbyUi = contexts.lobbyUi;
            this.lobbySoundsManager = lobbySoundsManager;
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.ShiftWarshipsLeftCommand.Added());
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.isShiftWarshipsLeftCommand;
        }

        protected override void Execute(List<LobbyUiEntity> _)
        {
            if (lobbyUi.isBlockWarshipsShiftToTheLeft)
            {
                log.Info($"Блок {nameof(ShiftWarshipsLeftReactiveSystem)}");
            }
            else
            {
                //Сдвинуть индекс выбранного корабля
                int newIndex = ++lobbyUi.currentWarshipIndex.value;
                lobbyUi.ReplaceCurrentWarshipIndex(newIndex);
                lobbySoundsManager.PlayWarshipChangingLeft();
            }
        }
    }
}