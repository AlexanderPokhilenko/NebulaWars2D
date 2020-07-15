using System;
using System.Collections.Generic;
using Code.Scenes.LobbyScene.Scripts.UiStorages;
using UnityEngine;
using Random = System.Random;

namespace Code.Scenes.LobbyScene.ECS.AccountData.MovingAwards.Images.Experimental
{
    /// <summary>
    /// По типу награды создаёт путь для награды.
    /// </summary>
    public class MovingAwardControlPointsFactoryFacade
    {
        //TODO это нормально?
        private readonly MovingAwardControlPointsFactory awardControlPointsFactory;

        public MovingAwardControlPointsFactoryFacade()
        {
            awardControlPointsFactory = new MovingAwardControlPointsFactory();
        }

        public List<ControlPoint> Create(int index, DateTime now, Random random, float screenHeight, AwardType awardType)
        {
            Vector3 spawnPoint = MovingAwardsUiElementsStorage.Instance().GetStartPoint(awardType);
            Vector3 finishPoint = MovingAwardsUiElementsStorage.Instance().GetFinishPoint(awardType);
            return awardControlPointsFactory.Create(index, now, spawnPoint, finishPoint, random, screenHeight);
        }
    }
}