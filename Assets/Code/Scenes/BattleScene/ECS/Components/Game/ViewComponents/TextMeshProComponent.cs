using Entitas;
using TMPro;

namespace Code.Scenes.BattleScene.ECS.Components.ViewComponents
{
    [Game]
    public sealed class TextMeshProComponent : IComponent
    {
        public TextMeshPro value;
    }
}