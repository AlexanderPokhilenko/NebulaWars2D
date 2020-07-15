using Code.Scenes.LobbyScene.ECS.Components;
using Entitas;

namespace Code.Scenes.LobbyScene.ECS.Systems.Execute
{
    /// <summary>
    /// Создаёт комноненты для меню поиска матча после получения их от матчмейкера.
    /// </summary>
    public class MatchSearchDataUpdaterSystem:IExecuteSystem
    {
        private int numberOfPlayersInQueue;
        private int numberOfPlayersInBattles;
        private bool hasNewData;
        private readonly LobbyUiContext lobbyUiContext;
        private readonly object lockObj = new object();

        public MatchSearchDataUpdaterSystem(Contexts contexts)
        {
            lobbyUiContext = contexts.lobbyUi;
        }
        
        /// <summary>
        /// Вызывается при получении новых данных от матчмейкера
        /// </summary>
        public void SetNewData(int newNumberOfPlayersInQueue, int newNumberOfPlayersInBattles)
        {
            lock (lockObj)
            {
                numberOfPlayersInQueue = newNumberOfPlayersInQueue;
                numberOfPlayersInBattles = newNumberOfPlayersInBattles;
                hasNewData = true;   
            }
        }
        
        public void Execute()
        {
            lock (lockObj)
            {
                if (hasNewData)
                {
                    if (lobbyUiContext.hasMatchSearchDataForMenu)
                    {
                        lobbyUiContext.RemoveMatchSearchDataForMenu();
                    }
                    lobbyUiContext.SetMatchSearchDataForMenu(numberOfPlayersInBattles, numberOfPlayersInQueue);
                    hasNewData = false;
                }
            }
        }
    }
}