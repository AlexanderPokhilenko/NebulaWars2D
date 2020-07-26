using Entitas;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Components.Game
{
    [Game]
    public class SpeedComponent : IComponent
    {
        public Vector2 linear;
        public float angular;
    }
}
