using Entitas;
using Entitas.CodeGeneration.Attributes;


[Game]
public sealed class ParentComponent : IComponent
{
    [EntityIndex]
    public ushort id;
}