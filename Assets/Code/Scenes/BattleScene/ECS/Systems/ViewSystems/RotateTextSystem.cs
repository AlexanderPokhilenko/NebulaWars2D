using Entitas;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Systems.ViewSystems
{
    public class RotateTextSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> withText;

        public RotateTextSystem(Contexts contexts)
        {
            withText = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.View, GameMatcher.TextMeshPro).NoneOf(GameMatcher.Hidden));
        }

        public void Execute()
        {
            foreach (var e in withText)
            {
                var tmp = e.textMeshPro.value;

                tmp.transform.rotation = Quaternion.identity;
            }
        }
    }
}