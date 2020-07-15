using System;
using System.Collections.Generic;
using System.Linq;
using Code.Common;
using Code.Scenes.LobbyScene.ECS.Components;
using Entitas;
using UnityEngine;
using Random = System.Random;

namespace Code.Scenes.LobbyScene.ECS.Systems.Execute
{
    /// <summary>
    /// Создаёт компоненты для наград. Внутри компонента указан его путь.
    /// </summary>
    public class MovingAwardImagesDataCreationSystem:ReactiveSystem<LobbyUiEntity>
    {
        private readonly float screenHeight;
        
        private readonly Random random = new Random();
        private readonly LobbyUiContext contextsLobbyUi;
        
        private readonly ILog log = LogManager.CreateLogger(typeof(MovingAwardImagesDataCreationSystem));
        private readonly MovingAwardControlPointsFactoryFacade awardControlPointsFactoryFacade;

        public MovingAwardImagesDataCreationSystem(Contexts contexts, RectTransform movingAwardsParentRectTransform)
            :base(contexts.lobbyUi)
        {
            contextsLobbyUi = contexts.lobbyUi;
            screenHeight = movingAwardsParentRectTransform.sizeDelta.y;
            awardControlPointsFactoryFacade = new MovingAwardControlPointsFactoryFacade();
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
            foreach (var command in entities.Select(entity => entity.commandToCreateAwardImages))
            {
                AwardType awardType = command.awardType;
                DateTime spawnStartTime = command.startSpawnTime;
                for (int index = 0; index < command.quantity; index++)
                {
                    LobbyUiEntity entity = contextsLobbyUi.CreateEntity();
                    List<ControlPoint> controlPoints = awardControlPointsFactoryFacade
                        .Create(index, spawnStartTime, random, screenHeight, awardType);

                    int increment = 1;
                    entity.AddMovingAward( increment, awardType,1  , controlPoints);
                    entity.AddPosition(controlPoints.First().position);
                    entity.AddAlpha(0);
                    entity.AddScale(new Vector3(1,1,1));
                }
            }
        }
    }
}