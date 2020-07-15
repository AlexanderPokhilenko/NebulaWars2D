using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scenes.LobbyScene.Scripts
{
    public class LobbySceneSwitcher : MonoBehaviour
    {
        private LobbyEcsController lobbyEcsController;

        private void Awake()
        {
            lobbyEcsController = FindObjectOfType<LobbyEcsController>();
        }

        public void LoadSceneAsync(string sceneName)
        {
            Destroy(lobbyEcsController);
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        }
        
        public void ReloadScene()
        {
            Destroy(lobbyEcsController);
            SceneManager.LoadScene("LobbyScene", LoadSceneMode.Single);
        }
    }
}