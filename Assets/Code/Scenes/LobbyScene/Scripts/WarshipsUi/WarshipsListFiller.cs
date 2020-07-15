using System;
using Code.Common.Logger;
using UnityEngine;

namespace Code.Scenes.LobbyScene.Scripts.WarshipsUi
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