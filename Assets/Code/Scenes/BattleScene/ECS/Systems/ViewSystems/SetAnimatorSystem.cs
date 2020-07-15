using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Systems.ViewSystems
{
    public class SetAnimatorSystem : ReactiveSystem<GameEntity>
    {
        public SetAnimatorSystem(Contexts contexts) 
            : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AnimatorController);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasView && entity.hasAnimatorController;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                var gameObject = gameEntity.view.gameObject;
                var animator = gameObject.GetComponent<Animator>();
                if (animator == null) animator = gameObject.AddComponent<Animator>();
                animator.runtimeAnimatorController = gameEntity.animatorController.value;
            }
        }
    }
}