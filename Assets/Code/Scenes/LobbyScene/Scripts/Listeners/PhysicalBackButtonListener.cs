using UnityEngine;

namespace Code.Scenes.LobbyScene.Scripts.Listeners
{
    public class PhysicalBackButtonListener : MonoBehaviour
    {
        private LobbyEcsController lobbyEcsController;

        private void Awake()
        {
            lobbyEcsController = FindObjectOfType<LobbyEcsController>();
        }

        private void Update()
        {
            // Кажется, это соответствует кнопке "Назад" на телефоне
            if (Input.GetKeyDown(KeyCode.Escape)) 
            {
                lobbyEcsController.PhysicalBackButton_OnClick();
            }
        }
    }
}