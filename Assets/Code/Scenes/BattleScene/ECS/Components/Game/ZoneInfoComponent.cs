using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Components.Game
{
    [Game, Unique]
    public class ZoneInfoComponent : IComponent
    {
        public Vector2 position;
        public float radius;
    }
}
