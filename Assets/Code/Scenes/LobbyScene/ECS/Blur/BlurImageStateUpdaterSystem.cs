using Entitas;

namespace Code.Scenes.LobbyScene.ECS.Systems.Execute
{
    /// <summary>
    /// Отвечает за создание данных о включении/выключении картинки с размытием по значению размытия.
    /// </summary>
    public class BlurImageStateUpdaterSystem:IExecuteSystem
    {
        private readonly LobbyUiContext lobbyUiContext;

        public BlurImageStateUpdaterSystem(LobbyUiContext lobbyUiContext)
        {
            this.lobbyUiContext = lobbyUiContext;
        }
        
        public void Execute()
        {
            bool isBlueImageEnabled = IsBlurImageEnabled();
            if(isBlueImageEnabled)
            {
                TryEnableBlurImageData();
            }
            else
            {
                TryDisableBlurImageData();
            }
        }

        private bool IsBlurImageEnabled()
        {
            int currentBlurValue = lobbyUiContext.blurValue.blurValue;
            return currentBlurValue != 0;
        }

        private void TryDisableBlurImageData()
        {
            if (lobbyUiContext.isBlurImageEnabled)
            {
                lobbyUiContext.isBlurImageEnabled = false;
            }
        }
        
        private void TryEnableBlurImageData()
        {
            if (!lobbyUiContext.isBlurImageEnabled)
            {
                lobbyUiContext.isBlurImageEnabled = true;
            }
        }
    }
}