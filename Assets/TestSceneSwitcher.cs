using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneSwitcher:MonoBehaviour
{
    public void GetBack()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}