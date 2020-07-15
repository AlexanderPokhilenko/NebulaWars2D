using System;
using Entitas;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.ECS.MatchSearch
{
    /// <summary>
    /// Обновляет строку времени ожидания в меню
    /// </summary>
    public class MatchSearchTimeUpdaterSystem : IExecuteSystem
    {
        private readonly LobbyUiContext lobbyUiContext;
        private readonly Text waitTimeGameObject;
        private int lastWaitTime;
        
        public MatchSearchTimeUpdaterSystem(LobbyUiContext lobbyUiContext, Text waitTimeGameObject)
        {
            this.lobbyUiContext = lobbyUiContext;
            if (waitTimeGameObject == null)
            {
                throw new NullReferenceException($"{nameof(waitTimeGameObject)} was null");
            }
            this.waitTimeGameObject = waitTimeGameObject;
        }

        public void Execute()
        {
            if (lobbyUiContext.isBlurImageEnabled)
            {
                if (lobbyUiContext.hasStartButtonPressTime)
                {
                    int waitingTime =
                        (int) (DateTime.Now - lobbyUiContext.startButtonPressTime.value).TotalSeconds;

                    if (waitingTime != lastWaitTime)
                    {
                        waitTimeGameObject.text = $"Waiting time for the match: {waitingTime} sec";
                        lastWaitTime = waitingTime;
                    }
                }
            }
        }
    }
}