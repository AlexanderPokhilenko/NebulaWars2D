using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scenes._3dBattleScene
{
    public class Battle3dSceneSwitcher : MonoBehaviour
    {
        public void LoadLobby()
        {
            SceneManager.LoadScene("LobbyScene");
        }
    }
}