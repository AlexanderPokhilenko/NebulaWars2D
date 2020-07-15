using Entitas;

namespace Code.Scenes.BattleScene.ECS.Components.ViewComponents
{
    [Game]
    public sealed class RectangleComponent : IComponent
    {
        public float width;
        public float height;
    }
}