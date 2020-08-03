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
        private int lastWaitTime;
        private readonly Text waitTimeGameObject;
        private readonly LobbyUiContext lobbyUiContext;
        
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
            if (lobbyUiContext.hasStartButtonClicked)
            {
                int waitingTime = (int) (DateTime.UtcNow - lobbyUiContext.startButtonClicked.value).TotalSeconds;
                if (waitingTime != lastWaitTime)
                {
                    waitTimeGameObject.text = $"Elapsed time: {waitingTime} sec";
                    lastWaitTime = waitingTime;
                }
            }
        }
    }
}