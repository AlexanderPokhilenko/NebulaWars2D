using UnityEngine;

namespace Code.Common
{
    [RequireComponent(typeof(BaseMenuManager))]
    public class LobbyMenuManager : Singleton<LobbyMenuManager>
    {
        private UiSoundsManager uiSoundsManager;
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject confirmationMenu;

        protected override void Awake()
        {
            base.Awake();
            uiSoundsManager = UiSoundsManager.Instance();
        }

        public void Button_Exit_Click()
        {
            confirmationMenu.SetActive(true);
            uiSoundsManager.PlayMenuOpen();
            mainMenu.SetActive(false);
        }

        public void CancelExit()
        {
            confirmationMenu.SetActive(false);
            uiSoundsManager.PlayMenuClose();
            mainMenu.SetActive(true);
        }

        public void ConfirmExit()
        {
            Application.Quit();
        }
    }
}