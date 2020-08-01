using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scenes.LobbyScene.Scripts.DebugMenu
{
    public class TestSceneListener : MonoBehaviour
    {
        public void TestScene()
        {
            SceneManager.LoadScene("Test");
        }
    }
}