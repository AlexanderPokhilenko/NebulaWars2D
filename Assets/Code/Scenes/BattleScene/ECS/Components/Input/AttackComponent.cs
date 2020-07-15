using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code.Scenes.BattleScene.ECS.Components.Input
{
    [Input, Unique]
    public class AttackComponent:IComponent
    {
        public float angle;
    }
}
