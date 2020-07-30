using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scenes.LobbyScene.Scripts.Listeners
{
    public class TestButtonListener : MonoBehaviour
    {
        public void Test()
        {
            SceneManager.LoadScene("Test");
        }
    }
}