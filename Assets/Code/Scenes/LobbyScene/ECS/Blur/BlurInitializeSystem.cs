using Entitas;

namespace Code.Scenes.LobbyScene.ECS.Blur
{
    /// <summary>
    /// Обнуляет значение размытия.
    /// </summary>
    public class BlurInitializeSystem:IInitializeSystem
    {
        private readonly LobbyUiContext lobbyUiContext;
        public BlurInitializeSystem(LobbyUiContext lobbyUiContext)
        {
            this.lobbyUiContext = lobbyUiContext;
        }
        public void Initialize()
        {
            lobbyUiContext.SetBlurValue(0);
        }
    }
}