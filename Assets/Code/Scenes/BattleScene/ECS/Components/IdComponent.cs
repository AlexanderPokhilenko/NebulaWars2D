using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code.Scenes.BattleScene.ECS.Components
{
    [Game, Input]
    public sealed class IdComponent : IComponent
    {
        [PrimaryEntityIndex]
        public ushort value;
    }
}