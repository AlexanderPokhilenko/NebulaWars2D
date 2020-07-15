using Entitas;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Components.ViewComponents
{
    [Game]
    public sealed class AnimatorControllerComponent : IComponent
    {
        public RuntimeAnimatorController value;
    }
}