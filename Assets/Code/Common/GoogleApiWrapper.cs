// using System;
// using GooglePlayGames;
// using GooglePlayGames.BasicApi;
// using UnityEngine;
//
// namespace Code.Scenes.Experimental
// {
//     public static class GoogleApiWrapper
//     {
//         public static void SpawnSection()
//         {
//             try
//             {
//                 PlayGamesClientConfiguration configuration = new PlayGamesClientConfiguration.Builder()
//                     .RequestIdToken()
//                     .Build();
//                 PlayGamesPlatform.InitializeInstance(configuration);
//                 PlayGamesPlatform.DebugLogEnabled = true;
//                 PlayGamesPlatform.Activate();
//             }
//             catch (Exception e)
//             {
//                Debug.LogError(e.Message);
//             }
//         }
//
//         public static void LogOut()
//         {
//             PlayGamesPlatform.Instance.SignOut();
//         }
//         
//         public static string Authenticate()
//         {
//             if (Social.localUser.authenticated)
//             {
//                 return "Пользователь уже вошёл в аккаунт";
//             }
//             else
//             {
//                 Social.localUser.Authenticate((success, str) =>
//                 {
//                     if (success)
//                     {
//                         Debug.Log("Усшеный вход в аккаунт");
//                     }
//                     else
//                     {
//                         Debug.LogError("Не удалось войти в google аккаунт");
//                     }
//                 } );
//                 return  "Попытка входа в google аккаунт";
//             }
//         }
//
//         public static string GetGooglePlayId()
//         {
//             return Social.localUser.id;
//         }
//         
//         public static string GetGooglePlayUserName()
//         {
//             return Social.localUser.userName;
//         }
//     }
// }