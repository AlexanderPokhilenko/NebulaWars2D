using System;
using Code.Scenes.LobbyScene.Scripts.DebugMenu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scenes.LobbyScene.Scripts.Listeners
{
    public class TestButtonListener : MonoBehaviour
    {
        private DebugMenuUiStorage uiStorage;

        private void Awake()
        {
            uiStorage = FindObjectOfType<DebugMenuUiStorage>();
        }

        public void EnableDebugMenu()
        {
            uiStorage.debugMenuRoot.SetActive(true);
        }
    }
}