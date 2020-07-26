using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Systems
{
    public class DestroyTimerSubtractionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> withTimerGroup;
        private readonly List<GameEntity> buffer;
        private const int predictedCapacity = 16;

        public DestroyTimerSubtractionSystem(Contexts contexts)
        {
            withTimerGroup = contexts.game.GetGroup(GameMatcher.DestroyTimer);
            buffer = new List<GameEntity>(predictedCapacity);
        }

        public void Execute()
        {
            var deltaTime = Time.deltaTime;

            foreach (var e in withTimerGroup.GetEntities(buffer))
            {
                var newTime = e.destroyTimer.time - deltaTime;

                if (newTime > 0f)
                {
                    e.ReplaceDestroyTimer(newTime);
                }
                else
                {
                    e.RemoveDestroyTimer();
                }
            }
        }
    }
}