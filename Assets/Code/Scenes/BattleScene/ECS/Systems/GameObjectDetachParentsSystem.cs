using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Systems
{
    public class GameObjectDetachParentsSystem : ReactiveSystem<GameEntity>
    {
        readonly Transform viewContainer;

        public GameObjectDetachParentsSystem(Contexts contexts, GameObject gameViews) : base(contexts.game)
        {
            viewContainer = gameViews.transform;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Parent.Removed());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasView && !entity.hasParent;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                e.view.gameObject.transform.SetParent(viewContainer, true);
            }
        }
    }
}