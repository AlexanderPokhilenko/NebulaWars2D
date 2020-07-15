using System;
using System.Collections.Generic;
using Assets.Code.Scenes.BattleScene.Experimental;
using Code.Common;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts
{
    /// <summary>
    /// Заполняет меню со списком кораблей после получения данных о аккаунте с сервера.
    /// </summary>
    public class Dich : MonoBehaviour
    {
        private WarshipsUiStorage warshipsUiStorage;
        private LobbyEcsController lobbyEcsController;
        private readonly ILog log = LogManager.CreateLogger(typeof(Dich));

        private void Awake()
        {
            warshipsUiStorage = FindObjectOfType<WarshipsUiStorage>()
                ?? throw new NullReferenceException(nameof(WarshipsUiStorage));
            lobbyEcsController = FindObjectOfType<LobbyEcsController>()
                ?? throw new NullReferenceException(nameof(LobbyEcsController));
        }

       
    }
}