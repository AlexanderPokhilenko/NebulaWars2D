using Code.Common;
using UnityEngine;

namespace Code.Scenes.LobbyScene.Scripts
{
    public class ButtonBackListener:MonoBehaviour
    {
        private LobbyEcsController lobbyEcsController;
        private readonly ILog log = LogManager.CreateLogger(typeof(ButtonBackListener));
        
        private void Awake()
        {
            lobbyEcsController = FindObjectOfType<LobbyEcsController>();
        }

        public void ButtonBack_OnClick()
        {
            // log.Debug("Нажатие на Back");
            lobbyEcsController.BackButton_OnClick();
        }
    }
}