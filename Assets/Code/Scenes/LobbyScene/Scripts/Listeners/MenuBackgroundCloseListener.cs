using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts.Listeners
{
    [RequireComponent(typeof(Button))]
    public class MenuBackgroundCloseListener : MonoBehaviour
    {
        private GameObject menuRoot;

        private void Awake()
        {
            var button = GetComponent<Button>();
            button.onClick.RemoveAllListeners(); // Зачем?
            button.onClick.AddListener(DisableMenu);
            menuRoot = button.transform.parent.gameObject;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) DisableMenu();
        }

        public void DisableMenu()
        {
            menuRoot.SetActive(false);
        }
    }
}