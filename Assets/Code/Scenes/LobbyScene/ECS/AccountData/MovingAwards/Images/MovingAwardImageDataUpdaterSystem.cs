using System;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.ECS.Extensions;
using Entitas;

namespace Code.Scenes.LobbyScene.ECS.AccountData.MovingAwards.Images
{
    /// <summary>
    /// Меняет позицию компонента движущейся награды.
    /// </summary>
    public class MovingAwardImageDataUpdaterSystem:IExecuteSystem
    {
        private readonly IGroup<LobbyUiEntity> movingAwardsGroup;
        private readonly ILog log = LogManager.CreateLogger(typeof(MovingAwardImageDataUpdaterSystem));

        public MovingAwardImageDataUpdaterSystem(Contexts contexts)
        {
            var contextsLobbyUi = contexts.lobbyUi;
            movingAwardsGroup = contextsLobbyUi.GetGroup(LobbyUiMatcher.AllOf(
                LobbyUiMatcher.MovingAward, LobbyUiMatcher.Alpha, LobbyUiMatcher.Position,
                LobbyUiMatcher.Scale));
        }
        
        public void Execute()
        {
            DateTime now = DateTime.Now;
            foreach (LobbyUiEntity award in movingAwardsGroup)
            {
                var movingAward = award.movingAward;
                DateTime currentTargetArrivalTime = movingAward.GetCurrentTargetArrivalTime();

                //Если уже нужно переходить на новый отрезок пути 
                if (currentTargetArrivalTime <= now)
                {
                    //то стать в последнюю точку текущего отрезка
                    award.position.value = movingAward.GetCurrentTargetPoint(); 
                    
                    //если отрезки ещё есть, то перейти дальше
                    if (movingAward.currentTargetIndex + 1 < movingAward.controlPoints.Count)
                    {
                        movingAward.currentTargetIndex++;
                    }
                }
                //иначе сдвинуть в зависимости от времени
                else
                {
                    award.position.value = movingAward.CalculatePosition(now);
                    award.scale.scale = movingAward.CalculateScale(now);
                    award.alpha.alpha = movingAward.CalculateAlpha(now);
                }
            }
        }
    }
}