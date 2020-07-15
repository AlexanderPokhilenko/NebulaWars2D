using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Code.BattleScene.ECS.Systems
{
    public class AddNicknameDistanceSystem : ReactiveSystem<GameEntity>
    {
        public AddNicknameDistanceSystem(Contexts contexts) : base(contexts.game)
        { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            var matcher = GameMatcher.AllOf(GameMatcher.View, GameMatcher.Player).NoneOf(GameMatcher.NicknameDistance);
            return context.CreateCollector(matcher);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasView && entity.hasPlayer && !entity.hasNicknameDistance;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity e in entities)
            {
                var go = e.view.gameObject;
                var sprite = go.GetComponent<SpriteRenderer>();
                e.AddNicknameDistance(sprite.bounds.max.magnitude);
            }
        }
    }
}