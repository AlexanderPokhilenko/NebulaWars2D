using System.Collections.Generic;
using Code.Scenes.BattleScene.Experimental;
using Entitas;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Systems.NetworkSyncSystems
{
    public class UpdateDestroysSystem : IExecuteSystem
    {
        private static readonly object LockObj = new object();
        private static HashSet<ushort> destroys;
        private const float TimeDelay = ClientTimeManager.TimeDelay;
        private readonly IGroup<GameEntity> positionedGroup;

        public UpdateDestroysSystem(Contexts contexts)
        {
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
                    var id = entity.id.value;
                    if (destroys.Contains(id))
                    {
                        if (entity.hasDelayedDestroy)
                        {
                            Debug.LogError($"Сообщение об удалении объекта с id {id} пришло несколько раз.");
                        }
                        else
                        {
                            entity.AddDelayedDestroy(TimeDelay);
                        }
                        if (entity.hasSpeed) entity.ReplaceSpeed(Vector2.zero, 0f);
                        destroys.Remove(id);
                    }
                }
            }
        }
    }
}