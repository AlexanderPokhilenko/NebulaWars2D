using Code.Common.Logger;
using Code.Scenes.LobbyScene.ECS.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.AccountData.MovingAwards.Images
{
    /// <summary>
    /// Меняет позиции GO движущихся наград.
    /// </summary>
    public class MovingAwardGameObjectUpdaterSystem:IExecuteSystem
    {
        private readonly RectTransform upperObject;
        private readonly IGroup<LobbyUiEntity> movingAwardsGroup;
        private readonly ILog log = LogManager.CreateLogger(typeof(MovingAwardImageDataUpdaterSystem));

        public MovingAwardGameObjectUpdaterSystem(Contexts contexts, RectTransform upperObject)
        {
            this.upperObject = upperObject;
            var contextsLobbyUi = contexts.lobbyUi;
            movingAwardsGroup = contextsLobbyUi.GetGroup(LobbyUiMatcher
                .AllOf(LobbyUiMatcher.MovingAward, LobbyUiMatcher.View, LobbyUiMatcher.Position));
        }
        
        public void Execute()
        {
            foreach (var movingAward in movingAwardsGroup)
            {
                movingAward.view.GameObject.transform.position = movingAward.position.value;
                movingAward.view.GameObject.transform.localScale = movingAward.scale.scale;
                var oldColor =  movingAward.image.image.color; 
                movingAward.image.image.color = new Color(oldColor.r, oldColor.g, oldColor.b, movingAward.alpha.alpha);


                if (movingAward.movingAward.IsRaiseUpNeeded())
                {
                    movingAward.view.GameObject.transform.SetParent(upperObject, false);
                    movingAward.movingAward.TurnOffRaiseUp();
                }
            }
        }
    }
}