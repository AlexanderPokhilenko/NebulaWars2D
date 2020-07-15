using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scenes.DebugScene
{
    public class DebugSceneController : MonoBehaviour
    {
        public void Button_Back_Click()
        {
            SceneManager.LoadScene("LobbyScene", LoadSceneMode.Single);
        }
    }
}
