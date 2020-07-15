using Entitas;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Systems.ViewSystems
{
    public class RenderSmoothedTransformSystem : IExecuteSystem
    {
        private const float ServerFps = 30f;
        private const float DelayFramesCount = 2f;
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
                    //Vector3 position = gameEntity.transform.position;
                    //transform.position = (Vector3)Vector2.SmoothDamp(transform.position, position, ref gameEntity.speed.value, SmoothTime) - Vector3.forward * (0.00001f * gameEntity.id.value);
                    //transform.rotation = Quaternion.AngleAxis(gameEntity.transform.angle, Vector3.forward);
                    transform.localPosition = (Vector3)Vector2.SmoothDamp(transform.localPosition, gameEntity.position.value, ref gameEntity.speed.value, SmoothTime) - Vector3.forward * (0.00001f * gameEntity.id.value);
                    transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.AngleAxis(gameEntity.direction.angle, Vector3.forward), 0.5f);
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}