using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugSceneController : MonoBehaviour
{
    public void Button_Back_Click()
    {
        SceneManager.LoadScene("LobbyScene", LoadSceneMode.Single);
    }
}
