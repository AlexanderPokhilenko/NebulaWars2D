using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.Clear
{
    public class ClearLobbyUiSystem:ITearDownSystem
    {
        private readonly LobbyUiContext lobbyUiContext;

        public ClearLobbyUiSystem(LobbyUiContext lobbyUiContext)
        {
            this.lobbyUiContext = lobbyUiContext;
        }
        
        public void TearDown()
        {
            LobbyUiEntity[] entities = lobbyUiContext.GetEntities();
            foreach (LobbyUiEntity entity in entities)
            {
                if (entity.hasView)
                {
                    GameObject gameObject = entity.view.gameObject;
                    if (gameObject != null)
                    {
                        gameObject.Unlink();
                        Object.Destroy(gameObject);   
                    }
                }
                entity.Destroy();
            }
        }
    }
}