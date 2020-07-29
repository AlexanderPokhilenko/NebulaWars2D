#define FORCE_AUTH


using System;
using Code.Common;
using Code.Common.Logger;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
namespace Code.Scenes.LobbyScene.Scripts
{
   /// <summary>
   /// Отвечает за авторизацию. Остаётся на сцене всегда.
   /// </summary>
   public class AuthSingleton : MonoBehaviour
   {
      private static bool isInstantiated;
      private bool isAuthorizationCompleted;
      private readonly object lockObj = new object();
      private readonly ILog log = LogManager.CreateLogger(typeof(AuthSingleton));
      
      private void Awake()
      {
         if (!isInstantiated)
         {
            DontDestroyOnLoad(gameObject);
            isInstantiated = true;
         }
      }

      private void Start()
      {
#if UNITY_ANDROID
         if (!PlayGamesPlatform.Instance.IsAuthenticated())
         {
            log.Info("Игрок ещё не зашёл в аккаунт");
            StartAuth();
         }
         else
         {
            log.Debug("Игрок уже зашёл в аккаунт");
            isAuthorizationCompleted = true;
            PrintPlayerData();
            PlayerIdStorage.SetServiceId(Social.localUser.id);
         }
#else
          StartAuth();
#endif
      }

      private void StartAuth()
      {
#if UNITY_ANDROID
         PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .RequestServerAuthCode(false /*forceRefresh*/)
            .Build();
         PlayGamesPlatform.InitializeInstance(config);
         PlayGamesPlatform.Activate();
         log.Info("Play Games Configuration initialized");
#endif
            Social.localUser.Authenticate(AuthCallback);
      }
      
      private void AuthCallback(bool success)
      {
         log.Info($"{nameof(AuthCallback)} {nameof(success)} {success}");
         if (success)
         {
            log.Info("Игрок авторизован");
            PrintPlayerData();
            lock (lockObj)
            {
               PlayerIdStorage.SetServiceId(Social.localUser.id);
               PlayerIdStorage.SetUsername(Social.localUser.userName);
               isAuthorizationCompleted = true;
            }
         }
         else
         {
            log.Warn("Auth failed");
#if (UNITY_EDITOR || FORCE_AUTH)
            AuthIfDeveloper();
#endif
         }


      }

#if (UNITY_EDITOR || FORCE_AUTH)
      private void AuthIfDeveloper()
      {
         log.Warn("Принудительное выставление флага успеха авторизации");
         const string prefabsPlayerIdKey = "playerId";
         const string prefabsUsernameKey = "username";

         //Прочитать из жесткого диска
         string playerServiceId = PlayerPrefs.GetString(prefabsPlayerIdKey);
         string username = PlayerPrefs.GetString(prefabsUsernameKey);

         //На жестком диске уже был сохранён serviceId?
         if (string.IsNullOrEmpty(playerServiceId) || playerServiceId.Length < 10)
         {
            //Создать новый serviceId
            // playerServiceId = "devAccount" + new System.Random().Next(1, ushort.MaxValue);
            playerServiceId = "username";
            //Сохранить на жесткий диск
            PlayerPrefs.SetString(prefabsPlayerIdKey, playerServiceId);
            //Проверить, что сохранилось нормально
            if (PlayerPrefs.GetString(prefabsPlayerIdKey) != playerServiceId)
            {
               throw new Exception("Failed to save user id.");
            }
         }

         if (string.IsNullOrEmpty(username))
         {
            //Создать новый serviceId
            username = "username" + new System.Random().Next(1, ushort.MaxValue);
            //Сохранить на жесткий диск
            PlayerPrefs.SetString(prefabsUsernameKey, username);
            //Проверить, что сохранилось нормально
            if (PlayerPrefs.GetString(prefabsUsernameKey) != username)
            {
               throw new Exception("Failed to save username.");
            }
         }

         //Присвоить serviceId
         lock (lockObj)
         {
            PlayerIdStorage.SetServiceId(playerServiceId);
            PlayerIdStorage.SetUsername(username);
            isAuthorizationCompleted = true;
         }
      }
#endif

      private void PrintPlayerData()
      {
         log.Info(nameof(PrintPlayerData));
         log.Info($"{nameof(Social.localUser.authenticated)} {Social.localUser.authenticated}");
         log.Info($"{nameof(Social.localUser.underage)} {Social.localUser.underage}");
         log.Info($"{nameof(Social.localUser.id)} {Social.localUser.id}");
         log.Info($"{nameof(Social.localUser.state)} {Social.localUser.state}");
         log.Info($"{nameof(Social.localUser.userName)} {Social.localUser.userName}");
      }

      /// <summary>
      /// Нужно для того, чтобы понять можно ли выключать скринсейвер.
      /// </summary>
      /// <returns></returns>
      public bool IsAuthorizationCompleted()
      {
         lock (lockObj)
         {
            return isAuthorizationCompleted;
         }
      }
   }
}
