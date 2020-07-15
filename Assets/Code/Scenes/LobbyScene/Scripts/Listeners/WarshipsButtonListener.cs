using System;
using UnityEngine;

namespace Code.Scenes.LobbyScene.Scripts
{
    /// <summary>
    /// Реагирует на нажатие кнопки Warship
    /// </summary>
    public class WarshipsButtonListener : MonoBehaviour
    {
        private LobbyEcsController lobbyEcsController;

        private void Awake()
        {
            lobbyEcsController = FindObjectOfType<LobbyEcsController>() 
                                 ?? throw new NullReferenceException(nameof(LobbyEcsController));
        }

        public void WarshipsButton_OnClick()
        {
            lobbyEcsController.ShowWarshipList();
        }
    }
}