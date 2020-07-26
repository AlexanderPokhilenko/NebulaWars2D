using Entitas;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Systems.ViewSystems
{
    public class UpdateParticlesSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> movableGroup;

        public UpdateParticlesSystem(Contexts contexts)
        {
            var matcher = GameMatcher.AllOf(GameMatcher.MaxSpeed, GameMatcher.Speed, GameMatcher.View);
            movableGroup = contexts.game.GetGroup(matcher);
        }

        public void Execute()
        {
            foreach (var e in movableGroup)
            {
                var percentage = e.speed.linear.magnitude / e.maxSpeed.value;
                if (percentage > 1f) percentage = 1f;

                var particleSystems = e.view.gameObject.GetComponentsInChildren<ParticleSystem>();

                foreach (var particleSystem in particleSystems)
                {
                    var mainModule = particleSystem.main;
                    mainModule.startLifetime = percentage * 0.5f;
                }
            }
        }
    }
}