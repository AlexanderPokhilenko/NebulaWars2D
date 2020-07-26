using Code.Scenes.BattleScene.Experimental;
using Entitas;
using Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Systems.ViewSystems
{
    public class RenderSmoothedTransformSystem : IExecuteSystem
    {
        private const float ServerFps = ServerTimeConstants.MaxFps;
        private const float DelayFramesCount = ClientTimeManager.DelayFramesCount;
        private const float SmoothTime = DelayFramesCount / ServerFps;
        private readonly IGroup<GameEntity> positionedGroup;

        public RenderSmoothedTransformSystem(Contexts contexts)
        {
            var matcher = GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Direction, GameMatcher.View, GameMatcher.Speed);
            positionedGroup = contexts.game.GetGroup(matcher);
        }

        public void Execute()
        {
            try
            {
                foreach (var gameEntity in positionedGroup)
                {
                    var transform = gameEntity.view.gameObject.transform;
                    transform.localPosition = (Vector3)Vector2.SmoothDamp(transform.localPosition, gameEntity.position.value, ref gameEntity.speed.linear, SmoothTime) - Vector3.forward * (0.00001f * gameEntity.id.value);
                    var newAngle = Mathf.SmoothDampAngle(transform.localRotation.eulerAngles.z, gameEntity.direction.angle, ref gameEntity.speed.angular, SmoothTime);
                    transform.localRotation = Quaternion.Euler(0f, 0f, newAngle);
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}