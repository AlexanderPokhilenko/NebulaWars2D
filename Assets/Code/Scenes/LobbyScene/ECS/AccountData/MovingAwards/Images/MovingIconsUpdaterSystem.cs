using Code.Common.Logger;
using Code.Scenes.LobbyScene.ECS.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.AccountData.MovingAwards.Images
{
    /// <summary>
    /// Меняет позиции GO движущихся наград.
    /// </summary>
    public class MovingIconsUpdaterSystem:IExecuteSystem
    {
        private readonly RectTransform upperObject;
        private readonly IGroup<LobbyUiEntity> movingAwardsGroup;
        private readonly ILog log = LogManager.CreateLogger(typeof(MovingIconDataUpdaterSystem));

        public MovingIconsUpdaterSystem(Contexts contexts, RectTransform upperObject)
        {
            this.upperObject = upperObject;
            var contextsLobbyUi = contexts.lobbyUi;
            movingAwardsGroup = contextsLobbyUi.GetGroup(LobbyUiMatcher
                .AllOf(LobbyUiMatcher.MovingIcon, LobbyUiMatcher.View, LobbyUiMatcher.Position));
        }
        
        public void Execute()
        {
            foreach (LobbyUiEntity movingAward in movingAwardsGroup)
            {
                movingAward.view.gameObject.transform.position = movingAward.position.value;
                movingAward.view.gameObject.transform.localScale = movingAward.scale.scale;
                var oldColor =  movingAward.image.image.color; 
                movingAward.image.image.color = new Color(oldColor.r, oldColor.g, oldColor.b, movingAward.alpha.alpha);

                if (movingAward.movingIcon.IsRaiseUpNeeded())
                {
                    movingAward.view.gameObject.transform.SetParent(upperObject, false);
                    movingAward.movingIcon.TurnOffRaiseUp();
                }
            }
        }
    }
}