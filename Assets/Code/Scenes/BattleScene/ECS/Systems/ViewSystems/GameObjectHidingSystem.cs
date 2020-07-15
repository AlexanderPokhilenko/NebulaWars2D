using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Systems.ViewSystems
{
    public class GameObjectHidingSystem : ReactiveSystem<GameEntity>
    {
        public GameObjectHidingSystem(Contexts contexts) : base(contexts.game)
        { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Hidden.AddedOrRemoved());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasView && !entity.isDestroyed;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity e in entities)
            {
                var go = e.view.gameObject;
                if (e.isHidden)
                {
                    foreach (var source in go.GetComponentsInChildren<AudioSource>())
                    { // что-то странное со звуками, лучше их отключать
                        if (source.isPlaying) source.Stop();
                    }
                }
                go.SetActive(!e.isHidden);
            }
        }
    }
}