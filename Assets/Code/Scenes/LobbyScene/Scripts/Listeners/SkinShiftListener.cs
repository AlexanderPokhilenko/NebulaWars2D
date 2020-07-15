using System;
using UnityEngine;

namespace Code.Scenes.LobbyScene.Scripts
{
    public class SkinShiftListener : MonoBehaviour
    {
        private LobbyEcsController lobbyEcsController;

        private void Awake()
        {
            lobbyEcsController = FindObjectOfType<LobbyEcsController>() 
                                 ?? throw new NullReferenceException(nameof(lobbyEcsController));
        }

        public void RightButtonClick()
        {
            lobbyEcsController.ShiftSkinLeft();
        }
        
        
        public void LeftButtonClick()
        {
            lobbyEcsController.ShiftSkinRight();
        }
    }
}