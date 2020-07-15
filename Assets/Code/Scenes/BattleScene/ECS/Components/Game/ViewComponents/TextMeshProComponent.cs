using Entitas;
using TMPro;

namespace Code.Scenes.BattleScene.ECS.Components.Game.ViewComponents
{
    [Game]
    public sealed class TextMeshProComponent : IComponent
    {
        public TextMeshPro value;
    }
}