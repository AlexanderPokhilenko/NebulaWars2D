using System;
using System.Collections;
using System.Collections.Generic;
using Code.Common;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.Scripts.Listeners;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;

namespace Code.Scenes.LootboxScene.Scripts
{
    /// <summary>
    /// Начинает анимацию после того как данные о сундуке были получены в LootboxModelDownloader.
    /// </summary>
    public class ResourcesAccrualManager : MonoBehaviour
    {
        private LootboxEcsController lootboxEcsController;
        private LootboxSceneSwitcher lootboxSceneSwitcher;
        private readonly TimeSpan maxWaitingTime = TimeSpan.FromSeconds(3);
        private readonly ILog log = LogManager.CreateLogger(typeof(ResourcesAccrualManager));

        protected void Awake()
        {
            lootboxEcsController = FindObjectOfType<LootboxEcsController>()
                                   ?? throw new NullReferenceException(nameof(lootboxEcsController));
            lootboxSceneSwitcher = FindObjectOfType<LootboxSceneSwitcher>()
                                   ?? throw new NullReferenceException(nameof(lootboxSceneSwitcher));
        }

        private void Start()
        {
            StartCoroutine(StartAnimation());
        }

        private IEnumerator StartAnimation()
        {
            if (ResourcesAccrualStorage.Instance.IsLootboxNeeded)
            {
                log.Debug("LootboxNeeded");
                lootboxEcsController.ShowLootbox();
            }
            
            DateTime delayTime = DateTime.UtcNow + maxWaitingTime;
            yield return new WaitUntil(()=>
            {
                return ResourcesAccrualStorage.Instance.ResourceModels!=null || DateTime.UtcNow > delayTime;
            });

            if (ResourcesAccrualStorage.Instance.ResourceModels != null)
            {
                lootboxEcsController.SetResourceModels(ResourcesAccrualStorage.Instance.ResourceModels );
            }
            else
            {
                UiSoundsManager.Instance().PlayError();
                lootboxSceneSwitcher.LoadLobbyScene();
            }
        }
    }
}