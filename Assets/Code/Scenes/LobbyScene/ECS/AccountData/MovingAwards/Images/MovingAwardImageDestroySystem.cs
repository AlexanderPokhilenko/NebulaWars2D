using System;
using System.Linq;
using Code.Common;
using Code.Scenes.LobbyScene.ECS.Components;
using Code.Scenes.LobbyScene.Scripts;
using Entitas;
using Object = UnityEngine.Object;

namespace Code.Scenes.LobbyScene.ECS.Systems.Execute
{
    /// <summary>
    /// Удаляет объекты наград, когда они приближаются к месту назначения
    /// </summary>
    public class MovingAwardImageDestroySystem : IExecuteSystem
    {
        private readonly UiSoundsManager uiSoundsManager;
        private readonly LobbyUiContext lobbyUiContext;
        private readonly IGroup<LobbyUiEntity> movingAwardsGroup;
        private readonly ILog log = LogManager.CreateLogger(typeof(MovingAwardImageDataUpdaterSystem));

        public MovingAwardImageDestroySystem(Contexts contexts)
        {
            uiSoundsManager = UiSoundsManager.Instance();
            lobbyUiContext = contexts.lobbyUi;
            movingAwardsGroup = lobbyUiContext.GetGroup(LobbyUiMatcher.MovingAward);
        }
        
        public void Execute()
        {
            DateTime now = DateTime.Now;
            LobbyUiEntity[] awards = movingAwardsGroup.GetEntities();
            for (int index = 0; index < awards.Length; index++)
            {
                LobbyUiEntity movingAward = awards[index];
                DateTime arrivalTime = movingAward.movingAward.controlPoints.Last().ArrivalTime;
                if (arrivalTime <= now)
                {
                    int increment = movingAward.movingAward.Increment;
                    switch (movingAward.movingAward.awardType)
                    {
                        case AwardType.SoftCurrency:
                            uiSoundsManager.PlaySoftAdding();
                            lobbyUiContext.ReplaceSoftCurrency(lobbyUiContext.softCurrency.value+increment);
                            break;
                        case AwardType.AccountRating:
                            uiSoundsManager.PlayRatingAdding();
                            lobbyUiContext.ReplaceAccountRating(lobbyUiContext.accountRating.value+increment);
                            break;
                        case AwardType.HardCurrency:
                            uiSoundsManager.PlayHardAdding();
                            lobbyUiContext.ReplaceHardCurrency(lobbyUiContext.hardCurrency.value+increment);
                            break;
                        case AwardType.LootboxPoints:
                            uiSoundsManager.PlayPointsAdding();
                            lobbyUiContext.ReplacePointsForSmallLootbox(lobbyUiContext.pointsForSmallLootbox.value+increment);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    Object.Destroy(movingAward.view.GameObject);
                    movingAward.Destroy();
                }
            }
        }
    }
}