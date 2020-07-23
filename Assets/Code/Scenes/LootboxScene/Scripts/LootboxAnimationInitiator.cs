using System;
using System.Collections;
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
    public class LootboxAnimationInitiator : MonoBehaviour
    {
        private LootboxEcsController lootboxEcsController;
        private LootboxSceneSwitcher lootboxSceneSwitcher;
        private readonly TimeSpan maxWaitingTime = TimeSpan.FromSeconds(3);
        private readonly ILog log = LogManager.CreateLogger(typeof(LootboxAnimationInitiator));

        protected void Awake()
        {
            lootboxEcsController = FindObjectOfType<LootboxEcsController>()
                                   ?? throw new NullReferenceException(nameof(lootboxEcsController));
            lootboxSceneSwitcher = FindObjectOfType<LootboxSceneSwitcher>();
        }

        private void Start()
        {
            
            StartCoroutine(ShowResourcesAccrual());
        }

        private IEnumerator ShowResourcesAccrual()
        {
            DateTime delayTime = DateTime.UtcNow + maxWaitingTime;
            yield return new WaitUntil(()=>
            {
                return LootboxModelDownloader.Instance.IsDownloadingCompleted() || DateTime.UtcNow > delayTime;
            });

            if (!LootboxModelDownloader.Instance.IsDownloadingCompleted())
            {
                //За отведённое время не удалось купить лутбокс на сервере
                UiSoundsManager.Instance().PlayError();
                lootboxSceneSwitcher.LoadLobbyScene();
                yield break;
            }
            LootboxModel lootboxModel = LootboxModelDownloader.Instance.GetLootboxModel();
            if (lootboxModel == null)
            {
                log.Error("Не удалось скачать данные о лутбоксе");
                yield break; 
            }

            log.Info("Данные о лутбоксе успешно скачаны");
            StartAnimation(lootboxModel);
        }

        private void StartAnimation(LootboxModel lootboxModelArg)
        {
            lootboxEcsController.SetLootboxModel(lootboxModelArg);
        }
    }
}