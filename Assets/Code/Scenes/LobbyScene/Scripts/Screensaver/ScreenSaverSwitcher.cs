using System.Collections;
using Code.Common.Logger;
using UnityEngine;

namespace Code.Scenes.LobbyScene.Scripts.Screensaver
{
    /// <summary>
    /// Отвечает за выключение заставки перед лобби.
    /// </summary>
    public class ScreenSaverSwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject screenSaverImage;

        private AuthSingleton authSingleton;
        private LobbyEcsController lobbyEcsController;
        private readonly ILog log = LogManager.CreateLogger(typeof(ScreenSaverSwitcher));
        
        private void Awake()
        {
            authSingleton = FindObjectOfType<AuthSingleton>();
            lobbyEcsController = FindObjectOfType<LobbyEcsController>();
        }

        private void Start()
        {
            screenSaverImage.SetActive(true);
            StartCoroutine(DisableScreenSaverWhenInitializationIsCompleted());
        }

        private IEnumerator DisableScreenSaverWhenInitializationIsCompleted()
        {
            log.Info(nameof(DisableScreenSaverWhenInitializationIsCompleted)+" start");
            
            while (!IsInitializationCompleted())
            {
                yield return null;
            }
            
            log.Info("Инициализация закончена. Выключение скринсейвера");
            screenSaverImage.SetActive(false);
        }
        
        private bool IsInitializationCompleted()
        {
            bool isAuthorizationCompleted = authSingleton.IsAuthorizationCompleted();
            bool warshipsCreationCompleted = lobbyEcsController.IsWarshipsCreationCompleted();
            bool isUnityEditor = IsUnityEditor();
            bool initializationCompleted = isAuthorizationCompleted && warshipsCreationCompleted;
            bool result = initializationCompleted || isUnityEditor;
            
            
            log.Info($"{nameof(isAuthorizationCompleted)} {isAuthorizationCompleted}" +
                      $" {nameof(warshipsCreationCompleted)} {warshipsCreationCompleted}");
            return result;
        }

        private bool IsUnityEditor()
        {
#if UNITY_EDITOR
    return true;
#else
    return false;
#endif
        }
    }
};