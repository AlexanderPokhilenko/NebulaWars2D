using System.Collections;
using Code.Scenes.LootboxScene.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scenes.LobbyScene.Scripts.Listeners
{
    public class ResourcesAccrualSceneManager:MonoBehaviour
    {
        private LobbyEcsController lobbyEcsController;

        private void Awake()
        {
            lobbyEcsController = FindObjectOfType<LobbyEcsController>();
        }

        public void ShowWithLootboxScene()
        {
            LootboxModelDownloader.Instance.StartDownloading();
            SceneManager.LoadSceneAsync("2dLootboxScene", LoadSceneMode.Additive);
            SceneManager.sceneLoaded += DisableLobbyUi;
            SceneManager.sceneUnloaded += EnableLobbyUi;
            ResourcesAccrualStorage.Instance.Clear();
            ResourcesAccrualStorage.Instance.SetLootboxNeeded();
            StartCoroutine(SetData());
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