using System.Collections.Generic;
using System.Linq;
using Code.Common.Logger;
using Entitas;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.Warships
{
    /// <summary>
    /// Сдвигает объекты кораблей при изменении индекса текущего
    /// </summary>
    public class WarshipsMoverSystem : ReactiveSystem<LobbyUiEntity>
    {
        private readonly IGroup<GameEntity> withTransformGroup;
        private readonly ILog log = LogManager.CreateLogger(typeof(WarshipsMoverSystem));
        public WarshipsMoverSystem(Contexts contexts) 
            : base(contexts.lobbyUi)
        {
            withTransformGroup = contexts.game.GetGroup(GameMatcher.Transform);
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.CurrentWarshipIndex);
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.hasCurrentWarshipIndex;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            int newWarshipIndex = entities.Last().currentWarshipIndex.value;
            // log .Debug($"{nameof(newWarshipIndex)} {newWarshipIndex}");
            int currentWarshipIndex = 0;
            foreach (var entity in withTransformGroup)
            {
                int delta = (currentWarshipIndex - newWarshipIndex) * LobbyUiGlobals.DistanceBetweenWarships;
                var oldTransform = entity.transform;
                var newPosition = new Vector2(delta, 0);
                entity.ReplaceTransform(newPosition, oldTransform.angle);
                currentWarshipIndex++;
            }
        }
    }
}