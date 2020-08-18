using Code.Common;
using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Systems.AudioSystems
{
    public class SpawnSoundSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext gameContext;
        private readonly SoundManager _soundManager = SoundManager.Instance();

        public SpawnSoundSystem(Contexts contexts) : base(contexts.game)
        {
            gameContext = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            var matcher = GameMatcher.AllOf(GameMatcher.View, GameMatcher.SpawnSound);
            return context.CreateCollector(matcher);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasView && entity.hasSpawnSound && entity.hasTransform && !entity.isHidden;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var playerEntity = gameContext.currentPlayerEntity;
            if (playerEntity == null) return;

            foreach (var e in entities)
            {
                var go = e.view.gameObject;

                var source = go.GetComponent<AudioSource>();
                if (source == null) source = go.AddComponent<AudioSource>();

                var dist = (playerEntity.transform.position - e.transform.position).magnitude;

                if (dist <= SoundManager.MaxBattleSoundDistance)
                {
                    _soundManager.PlayGameSound(source, e.spawnSound.value);
                }
            }
        }
    }
}