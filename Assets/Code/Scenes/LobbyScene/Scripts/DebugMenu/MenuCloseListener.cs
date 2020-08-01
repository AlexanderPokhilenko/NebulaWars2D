using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts.DebugMenu
{
    public class MenuCloseListener : MonoBehaviour
    {
        private DebugMenuUiStorage uiStorage;

        private void Awake()
        {
            var button = GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(DisableMenu);
            uiStorage = FindObjectOfType<DebugMenuUiStorage>();
        }

        public void DisableMenu()
        {
            uiStorage.debugMenuRoot.SetActive(false);
        }
    }
}