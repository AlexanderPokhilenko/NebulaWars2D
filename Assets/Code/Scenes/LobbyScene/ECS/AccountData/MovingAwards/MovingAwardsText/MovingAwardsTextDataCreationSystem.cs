using System;
using System.Collections.Generic;
using Code.Scenes.LobbyScene.Scripts;
using Entitas;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.Systems.Execute
{
    /// <summary>
    /// Создаёт компоненты для текста с количеством награды в определённом месте в зависимости от типа награды.
    /// </summary>
    public class MovingAwardsTextCreationSystem:ReactiveSystem<LobbyUiEntity>
    {
        private readonly LobbyUiContext lobbyUiContext;

        public MovingAwardsTextCreationSystem(Contexts contexts) 
            : base(contexts.lobbyUi)
        {
            lobbyUiContext = contexts.lobbyUi;
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.CommandToCreateAwardImages.Added());
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.hasCommandToCreateAwardImages;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            foreach (var lobbyUiEntity in entities)
            {
                var command = lobbyUiEntity.commandToCreateAwardImages;
                var textEntity = lobbyUiContext.CreateEntity();
                Vector3 startPosition= MovingAwardsUiElementsStorage.Instance().GetStartPoint(command.awardType);
                textEntity.AddAwardText(command.quantity, MovingAwardsUiElementsStorage.Instance().GetStartPoint(command.awardType),
                     command.startSpawnTime,
                     command.startSpawnTime + TimeSpan.FromSeconds(1.5)
                );
                textEntity.AddPosition(startPosition);
                textEntity.AddAlpha(1);
            }
        }
    }
}