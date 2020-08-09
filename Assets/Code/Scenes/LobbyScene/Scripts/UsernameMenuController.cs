using Code.Common;
using Code.Common.Storages;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts
{
    public class UsernameMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject menuRoot;
        [SerializeField] private GameObject errorRoot;
        [SerializeField] private InputField usernameInput;
        [SerializeField] private Text errorText;
        private AuthSingleton authSingleton;

        private void Start()
        {
            authSingleton = AuthSingleton.Instance();
        }

        public void ShowMenu()
        {
            menuRoot.SetActive(true);
            PlayerIdStorage.TryGetUsername(out var username);
            usernameInput.text = username;
        }

        public void ConfirmChanges()
        {
            if (authSingleton.TrySetUsername(usernameInput.text, out var errorMessage))
            {
                menuRoot.SetActive(false);
            }
            else
            {
                errorText.text = "<color='red'>" + errorMessage + "</color>\n<i>Click to return.</i>";
                errorRoot.SetActive(true);
                UiSoundsManager.Instance().PlayError();
            }
        }
    }
}