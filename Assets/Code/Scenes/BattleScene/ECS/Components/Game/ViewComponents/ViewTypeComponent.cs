using Entitas;

namespace Code.Scenes.BattleScene.ECS.Components.Game.ViewComponents
{
    [Game]
    public sealed class ViewTypeComponent : IComponent
    {
        public ViewTypeId id;
    }
}