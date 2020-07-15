using Entitas;

namespace Code.Scenes.BattleScene.ECS.Systems
{
    public class GameObjectParentsCheckerSystem : IExecuteSystem
    {
        private readonly GameContext gameContext;
        private readonly IGroup<GameEntity> withParents;

        public GameObjectParentsCheckerSystem(Contexts contexts)
        {
            gameContext = contexts.game;
            withParents = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.View, GameMatcher.Parent).NoneOf(GameMatcher.Destroyed));
        }

        public void Execute()
        {
            foreach (var e in withParents)
            {
                var parentEntity = gameContext.GetEntityWithId(e.parent.id);

                if (parentEntity != null && parentEntity.hasView && !parentEntity.isDestroyed)
                {
                    e.view.gameObject.transform.SetParent(parentEntity.view.gameObject.transform);
                }
            }
        }
    }
}