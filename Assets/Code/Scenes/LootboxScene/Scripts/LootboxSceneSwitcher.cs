using System;
using Code.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scenes.LootboxScene
{
    public class LootboxSceneSwitcher : MonoBehaviour
    {
        private LootboxEcsController ecsController;
        private readonly ILog log = LogManager.CreateLogger(typeof(LootboxSceneSwitcher));

        private void Awake()
        {
            ecsController = FindObjectOfType<LootboxEcsController>()
                            ?? throw new Exception("Не удалось найти контроллер");
        }

        public void LoadLobbyScene()
        {
            Destroy(ecsController);
            SceneManager.LoadScene("LobbyScene", LoadSceneMode.Single);
        }
    }
}