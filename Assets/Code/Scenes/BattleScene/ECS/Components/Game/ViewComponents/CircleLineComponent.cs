using Entitas;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Components.ViewComponents
{
    [Game]
    public sealed class CircleLineComponent : IComponent
    {
        public int numSegments;
        public float width;
        public Material material;
    }
}