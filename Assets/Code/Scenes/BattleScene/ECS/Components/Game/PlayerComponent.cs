using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code.Scenes.BattleScene.ECS.Components.Game
{
    [Game]
    public class PlayerComponent:IComponent
    {
        [PrimaryEntityIndex] public int accountId;
        public string nickname;
    }
}
