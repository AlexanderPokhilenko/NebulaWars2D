using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code.Scenes.BattleScene.ECS.Components.Game
{
    [Game]
    public sealed class ParentComponent : IComponent
    {
        [EntityIndex]
        public ushort id;
    }
}