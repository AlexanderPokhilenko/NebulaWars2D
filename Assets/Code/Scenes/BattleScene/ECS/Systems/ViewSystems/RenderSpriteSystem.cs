using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Systems.ViewSystems
{
    /// <summary>
    /// Добавляет SpriteRenderer при создании сущности с названием картинки.
    /// </summary>
    public class RenderSpriteSystem : ReactiveSystem<GameEntity>
    {
        public RenderSpriteSystem(Contexts contexts)
            : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Sprite);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasSprite && entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity e in entities)
            {
                GameObject go = e.view.gameObject;
                SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
                if (sr == null) sr = go.AddComponent<SpriteRenderer>();
                sr.sprite = e.sprite.value;
            }
        }
    }
}