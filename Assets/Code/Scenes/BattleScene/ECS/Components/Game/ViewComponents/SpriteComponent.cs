using Entitas;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Components.ViewComponents
{
    [Game]
    public sealed class SpriteComponent : IComponent
    {
        public Sprite value;
    }
}