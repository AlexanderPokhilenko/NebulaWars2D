using System;
using Code.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts
{
    /// <summary>
    /// Отвечает за обработку нажатий кнопок START и CANCEL
    /// </summary>
    public class MatchLoadingButtonsHandlerBehaviour : MonoBehaviour
    {
        private MatchLoader matchLoader;
        
        private LobbyEcsController lobbyEcsController;
        private readonly ILog log = LogManager.CreateLogger(typeof(AccountDataLoader));

        [SerializeField] private Button startMatchSearchButton;
        [SerializeField] private Button cancelMatchSearchButton;
        
        private void Awake()
        {
            matchLoader = FindObjectOfType<MatchLoader>();
            lobbyEcsController = FindObjectOfType<LobbyEcsController>();
        }

        private void Start()
        {
            startMatchSearchButton.onClick.RemoveAllListeners();
            startMatchSearchButton.onClick.AddListener(StartMatchSearchButton_Click);
            cancelMatchSearchButton.onClick.RemoveAllListeners();
            cancelMatchSearchButton.onClick.AddListener(CancelMatchSearchButton_Click);
        }

        private void StartMatchSearchButton_Click()
        {
            if (!PlayerIdStorage.TryGetServiceId(out string playerServiceId))
            {
                log.Error($"{nameof(StartMatchSearchButton_Click)} {nameof(playerServiceId)} is null");
                return;
            }
            
            
            if (playerServiceId == null)
            {
                throw new Exception($"{nameof(playerServiceId)} is null");
            }
            
            int currentWarshipId = lobbyEcsController.GetCurrentWarshipId();
            
            log.Info($"Данные для входа в бой: {nameof(playerServiceId)} {playerServiceId}," +
                     $" {nameof(currentWarshipId)} {currentWarshipId}");   
            
            matchLoader.StartBattleLoading(playerServiceId, currentWarshipId);
            lobbyEcsController.Button_Start_Click();
        }
        
        private void CancelMatchSearchButton_Click()
        {
            lobbyEcsController.Button_Cancel_Click();    
            matchLoader.StopBattleLoading();
        }
    }
}