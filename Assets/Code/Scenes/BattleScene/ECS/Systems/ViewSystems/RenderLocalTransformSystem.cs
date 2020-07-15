using Entitas;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Systems.ViewSystems
{
    public class RenderLocalTransformSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> positionedGroup;

        public RenderLocalTransformSystem(Contexts contexts)
        {
            var matcher = GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Direction, GameMatcher.View).NoneOf(GameMatcher.Speed);
            positionedGroup = contexts.game.GetGroup(matcher);
        }

        public void Execute()
        {
            try
            {
                foreach (var gameEntity in positionedGroup)
                {
                    var transform = gameEntity.view.gameObject.transform;
                    var position = gameEntity.position.value;
                    transform.localPosition = position - Vector3.forward * (0.00001f * gameEntity.id.value);
                    transform.localRotation = Quaternion.AngleAxis(gameEntity.direction.angle, Vector3.forward);
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}