using System;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.ECS.Extensions;
using Entitas;

namespace Code.Scenes.LobbyScene.ECS.AccountData.MovingAwards.MovingAwardsText
{
    /// <summary>
    /// Изменяет компонент текста.
    /// Поднимает его и делает более прозрачным.
    /// </summary>
    public class MovingAwardsTextDataUpdaterSystem:IExecuteSystem
    {
        private readonly IGroup<LobbyUiEntity> awardsTextGroup;
        private readonly ILog log = LogManager.CreateLogger(typeof(MovingAwardsTextDataUpdaterSystem));
        
        public MovingAwardsTextDataUpdaterSystem(Contexts contexts)
        {
            awardsTextGroup = contexts.lobbyUi.GetGroup(LobbyUiMatcher
                .AllOf(LobbyUiMatcher.AwardText, LobbyUiMatcher.Position, LobbyUiMatcher.Alpha));
        }

        public void Execute()
        {
            var awardTextEntities = awardsTextGroup.GetEntities();
            DateTime now = DateTime.Now;
            for (int i = 0; i < awardTextEntities.Length; i++)
            {
                var awardText = awardTextEntities[i];
                
                
                
                var startTime = awardText.awardText.CreationTime;
                var finishTime = awardText.awardText.FadeTime;

                float percentAttenuation = awardText.awardText.GetDistanceCoveragePercentage(now);
                awardTextEntities[i].position.value = awardText.awardText.CalculatePosition(now);
               
                if (now < startTime || finishTime < now)
                {
                    awardText.alpha.alpha = 0;
                }
                else
                {
                    awardText.alpha.alpha = 1-percentAttenuation/10;
                }
            }
        }
    }
}