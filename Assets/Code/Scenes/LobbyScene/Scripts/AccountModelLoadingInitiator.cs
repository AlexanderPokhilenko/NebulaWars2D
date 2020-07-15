using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Code.Common;
using Code.Common.Logger;
using Code.Common.NetworkStatistics;
using Code.Common.Statistics;
using Code.Scenes.LobbyScene.Utils;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;

namespace Code.Scenes.LobbyScene.Scripts
{
    /// <summary>
    /// Упраляет обновлением всех данных аккаунта при старте сцены.
    /// </summary>
    public class AccountModelLoadingInitiator : MonoBehaviour
    {
        private CancellationTokenSource cts;
        private LobbyEcsController lobbyEcsController;
        private readonly ILog log = LogManager.CreateLogger(typeof(AccountModelLoadingInitiator));

        private void Awake()
        {
            lobbyEcsController = FindObjectOfType<LobbyEcsController>();
        }

        private void Start()
        {
            NetworkStatisticsStorage.Instance.PrintSavedMatches();
            StartCoroutine(UpdateAccountData());
        }

        private IEnumerator UpdateAccountData()
        {
            cts = new CancellationTokenSource();
            Task<LobbyModel> task = new AccountDataDownloader().Load(cts.Token);
            yield return new WaitUntil(()=>task.IsCompleted);
            if (!task.IsCompleted)
            {
                log.Fatal("Не удалось скачать модель аккаунта");
            }
            SetData(task.Result);
        }

        private void SetData(LobbyModel lobbyModel)
        {
            //Отнять от данных аккаунта значения, которые будут начислены с анимацией
            AccountDto accountData =
                lobbyModel.AccountDto.Subtract(lobbyModel.RewardsThatHaveNotBeenShown);

            foreach (WarshipDto accountDataWarship in accountData.Warships)
            {
                log.Debug(accountDataWarship.CurrentSkinType.Name);
            }
            //Установить данные аккаунта
            lobbyEcsController.SetAccountData(accountData);
            //Установить данные для анимации начисления наград
            lobbyEcsController.CreateUnshownRewardsComponent(lobbyModel.RewardsThatHaveNotBeenShown);
            //Установить данные для шкалы рейтинга кораблей
            WarshipRatingScaleStorage.Instance.SetValue(lobbyModel.WarshipRatingScaleModel);
            //Установить данные для шкалы силы коралей
            WarshipPowerScaleStorage.Instance.SetValue(lobbyModel.WarshipPowerScaleModel);
        }

        private void OnDestroy()
        {
            cts?.Cancel();
        }
    }
}