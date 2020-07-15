using Entitas;

namespace Code.Scenes.LobbyScene.ECS.Systems.TearDown
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
            lobbyUiContext.DestroyAllEntities();
        }
    }
}