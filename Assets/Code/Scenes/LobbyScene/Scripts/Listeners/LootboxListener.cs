using Code.Common.Logger;
using UnityEngine;

namespace Code.Scenes.LobbyScene.Scripts.Listeners
{
    /// <summary>
    /// Отвечает за обработку нажатия на лутбокс.
    /// </summary>
    public class LootboxListener : MonoBehaviour
    {
        private LobbyEcsController lobbyEcsController;
        private LobbySceneSwitcher lobbySceneSwitcher;
        private readonly ILog log = LogManager.CreateLogger(typeof(LootboxListener));

        private void Awake()
        {
            lobbyEcsController = FindObjectOfType<LobbyEcsController>();
            lobbySceneSwitcher = FindObjectOfType<LobbySceneSwitcher>();
        }

        public void OpenLootboxButton_OnClick()
        {
            if (!lobbyEcsController.LootboxCanBeOpened())
            {
                log.Info("Недостаточно баллов для открытия лутбокса");
                return;
            }
            
            LootboxModelDownloader.Instance.StartDownloading();
            lobbySceneSwitcher.LoadSceneAsync("2dLootboxScene");
        }
    }
}