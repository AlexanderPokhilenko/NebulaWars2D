using System;
using UnityEngine;

namespace Code.Scenes.LobbyScene.Scripts
{
    public class ShopButtonListener : MonoBehaviour
    {
        private LobbyEcsController lobbyEcsController;

        private void Awake()
        {
            lobbyEcsController = FindObjectOfType<LobbyEcsController>() 
                    ?? throw new NullReferenceException(nameof(ShopButtonListener));
        }

        public void ShopButton_OnClick()
        {
            lobbyEcsController.ShopButton_OnClick();
        }
    }
}