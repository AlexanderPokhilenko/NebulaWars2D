using System.Collections;
using Code.Common.Logger;
using Code.Scenes.LootboxScene.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scenes.LobbyScene.Scripts.Listeners
{
    /// <summary>
    /// Отвечает за обработку нажатия на лутбокс.
    /// </summary>
    public class LootboxListener : MonoBehaviour
    {
        private LobbyEcsController lobbyEcsController;
        private readonly ILog log = LogManager.CreateLogger(typeof(LootboxListener));

        private void Awake()
        {
            lobbyEcsController = FindObjectOfType<LobbyEcsController>();
        }

        public void OpenLootboxButton_OnClick()
        {
            if (!lobbyEcsController.LootboxCanBeOpened())
            {
                log.Info("Недостаточно баллов для открытия лутбокса");
                return;
            }
            
            LootboxModelDownloader.Instance.StartDownloading();
            SceneManager.LoadSceneAsync("2dLootboxScene", LoadSceneMode.Additive);
            ResourcesAccrualStorage.Instance.Clear();
            ResourcesAccrualStorage.Instance.LootboxDownloadingStarted();
            StartCoroutine(SetData());
            SceneManager.sceneLoaded += DisableLobbyUi;
            SceneManager.sceneUnloaded += EnableLobbyUi;
        }

        private IEnumerator SetData()
        {
            yield return new WaitUntil(() => LootboxModelDownloader.Instance.IsDownloadingCompleted());

            var test = LootboxModelDownloader.Instance.GetLootboxModel().Prizes;
            ResourcesAccrualStorage.Instance.SetResourcesModels(test);
        }

        private void DisableLobbyUi(Scene arg0, LoadSceneMode arg1)
        {
            lobbyEcsController.DisableLobbySceneUi();
        }
        
        private void EnableLobbyUi(Scene arg0)
        {
            lobbyEcsController.EnableLobbySceneUi();
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= DisableLobbyUi;
            SceneManager.sceneUnloaded -= EnableLobbyUi;
        }
    }
}