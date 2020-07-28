using System.Collections;
using System.Collections.Generic;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.Scripts.AccountModel;
using Code.Scenes.LobbyScene.Scripts.Listeners;
using Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow;
using Code.Scenes.LootboxScene.Scripts;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scenes.LobbyScene.Scripts.ResourcesAccrual
{
    /// <summary>
    /// todo это говнокод
    /// </summary>
    public class ResourcesAccrualSceneManager:MonoBehaviour
    {
        private LootboxModel lastLootboxPrizesModel;
        private LobbyEcsController lobbyEcsController;
        private LobbyModelLoadingInitiator loadingInitiator;
        private readonly ILog log = LogManager.CreateLogger(typeof(ResourcesAccrualSceneManager));

        private void Awake()
        {
            lobbyEcsController = FindObjectOfType<LobbyEcsController>();
            loadingInitiator = FindObjectOfType<LobbyModelLoadingInitiator>();
        }

        public void ShowLootboxScene()
        {
            LootboxModelDownloader.Instance.StartDownloading();
            DisableLobbyUi();
            SceneManager.LoadScene("2dLootboxScene", LoadSceneMode.Additive);
            SceneManager.sceneUnloaded += LootboxSceneClosed;
            ResourcesAccrualStorage.Instance.Clear();
            StartCoroutine(SetLootboxResources());
            //todo отнять лутбокс
            loadingInitiator.UpdateAccountModel();
        }

        public void ShowOneResource(PurchaseModel purchaseModel)
        {
            DisableLobbyUi();
            SceneManager.LoadScene("2dLootboxScene", LoadSceneMode.Additive);
            SceneManager.sceneUnloaded += OneResourceSceneClosed;
            ResourcesAccrualStorage.Instance.Clear();
            var resourceModel = new ResourceModelMapper().Map(purchaseModel);
            ResourcesAccrualStorage.Instance.SetResourcesModels(new List<ResourceModel>()
            {
                resourceModel
            });
            ResourcesAccrualStorage.Instance.SetNoLootboxNeeded();
            lobbyEcsController.ClosePurchaseConfirmationWindow();
            lobbyEcsController.CloseShopLayer();
            //todo запустить обновление ресурсов
            loadingInitiator.UpdateAccountModel();
        }

        private void OneResourceSceneClosed(Scene arg0)
        {
            SceneManager.sceneUnloaded -= OneResourceSceneClosed;
            EnableLobbyUi();
        }
        
        private void LootboxSceneClosed(Scene arg0)
        {
            SceneManager.sceneUnloaded -= LootboxSceneClosed;
            EnableLobbyUi();
            // if (lastLootboxPrizesModel != null)
            // {
            //     var rewardsThatHaveNotBeenShown = new RewardsThatHaveNotBeenShownFactory().Create(lastLootboxPrizesModel);
            //     lobbyEcsController.CreateUnshownRewardsComponent(rewardsThatHaveNotBeenShown);
            //     lastLootboxPrizesModel = null;
            // }
            // else
            // {
            //     log.Error("Не удаётся показать движущиеся награды после открытия лутбокса." +
            //               " lastLootboxPrizesModel не установлена.");
            // }
        }
        
        private IEnumerator SetLootboxResources()
        {
            ResourcesAccrualStorage.Instance.SetLootboxNeeded();
            yield return new WaitUntil(() => LootboxModelDownloader.Instance.IsDownloadingCompleted());
            var lootboxPrize = LootboxModelDownloader.Instance.GetLootboxModel();
            lastLootboxPrizesModel = lootboxPrize;
            var test = lootboxPrize.Prizes;
            ResourcesAccrualStorage.Instance.SetResourcesModels(test);
        }

        private void DisableLobbyUi()
        {
            lobbyEcsController.DisableLobbySceneUi();
        }
        
        private void EnableLobbyUi()
        {
            lobbyEcsController.EnableLobbySceneUi();
        }
    }
}