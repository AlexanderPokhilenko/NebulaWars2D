using System.Collections;
using System.Collections.Generic;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.Scripts.Listeners;
using Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow;
using Code.Scenes.LootboxScene.Scripts;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scenes.LobbyScene.Scripts.ResourcesAccrual
{
    public class ResourcesAccrualSceneManager:MonoBehaviour
    {
        private LobbyEcsController lobbyEcsController;
        private readonly ILog log = LogManager.CreateLogger(typeof(ResourcesAccrualSceneManager));

        private void Awake()
        {
            lobbyEcsController = FindObjectOfType<LobbyEcsController>();
        }

        public void ShowWithLootboxScene()
        {
            LootboxModelDownloader.Instance.StartDownloading();
            OpenLootboxScene();
            StartCoroutine(SetLootboxResources());
        }

        private void OpenLootboxScene()
        {
            DisableLobbyUi();
            SceneManager.LoadScene("2dLootboxScene", LoadSceneMode.Additive);
            SceneManager.sceneUnloaded += EnableLobbyUi;
            ResourcesAccrualStorage.Instance.Clear();
        }
        
        public void ShowOneResource(PurchaseModel purchaseModel)
        {
            OpenLootboxScene();
            var resourceModel = new ResourceModelMapper().Map(purchaseModel);
            ResourcesAccrualStorage.Instance.SetResourcesModels(new List<ResourceModel>()
            {
                resourceModel
            });
            ResourcesAccrualStorage.Instance.SetNoLootboxNeeded();
            lobbyEcsController.ClosePurchaseConfirmationWindow();
            lobbyEcsController.CloseShopLayer();
        }
        
        private IEnumerator SetLootboxResources()
        {
            ResourcesAccrualStorage.Instance.SetLootboxNeeded();
            yield return new WaitUntil(() => LootboxModelDownloader.Instance.IsDownloadingCompleted());
            var test = LootboxModelDownloader.Instance.GetLootboxModel().Prizes;
            ResourcesAccrualStorage.Instance.SetResourcesModels(test);
        }

        private void DisableLobbyUi()
        {
            lobbyEcsController.DisableLobbySceneUi();
        }
        
        private void EnableLobbyUi(Scene arg0)
        {
            lobbyEcsController.EnableLobbySceneUi();
        }
    }
}