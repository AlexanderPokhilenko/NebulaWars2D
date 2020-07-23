using System;
using Code.Scenes.LobbyScene.Scripts.Listeners;
using UnityEngine;

namespace Code.Scenes.LobbyScene.Scripts
{
    public class EscapeButtonListener : MonoBehaviour
    {
        private ButtonBackListener backListener;

        private void Awake()
        {
            backListener = FindObjectOfType<ButtonBackListener>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) 
            {
                backListener.ButtonBack_OnClick();
            }
        }
    }
}