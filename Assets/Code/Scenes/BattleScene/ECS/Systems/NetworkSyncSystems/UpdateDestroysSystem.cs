using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Code.BattleScene.ECS.Systems
{
    public class UpdateDestroysSystem : IExecuteSystem
    {
        private static readonly object LockObj = new object();
        private static HashSet<ushort> destroys;

        private readonly GameContext gameContext;
        private readonly IGroup<GameEntity> positionedGroup;

        public UpdateDestroysSystem(Contexts contexts)
        {
            gameContext = contexts.game;
            destroys = new HashSet<ushort>();
            var matcher = GameMatcher.AllOf(GameMatcher.Transform, GameMatcher.View);
            positionedGroup = contexts.game.GetGroup(matcher);
        }

        public static void SetNewDestroys(ushort[] newDestroys)
        {
            lock (LockObj)
            {
                destroys.UnionWith(newDestroys);
            }
        }

        public void Execute()
        {
            lock (LockObj)
            {
                foreach (var entity in positionedGroup)
                {
                    if (destroys.Contains(entity.id.value))
                    {
                        entity.isDestroyed = true;
                        if (entity.hasSpeed) entity.ReplaceSpeed(Vector2.zero);
                    }
                }
            }
        }
    }
}