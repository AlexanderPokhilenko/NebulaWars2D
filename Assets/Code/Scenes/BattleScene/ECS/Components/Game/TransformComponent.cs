using Entitas;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Components.Game
{
    [Game]
    public class TransformComponent : IComponent
    {
        public Vector2 position;
        public float angle;
    }
}
