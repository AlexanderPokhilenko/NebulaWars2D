// using Code.Common.Logger;
// using UnityEngine;
//
// namespace Code.Scenes.LobbyScene.ECS.Warships
// {
//     /// <summary>
//     /// Хранит номер скина для каждого корабля.
//     /// </summary>
//     public static class CurrentWarshipSkinIndexStorage
//     {
//         private static readonly ILog log = LogManager.CreateLogger(typeof(CurrentWarshipSkinIndexStorage)); 
//         public static  int Get(string warshipName)
//         {
//             return PlayerPrefs.GetInt(warshipName, 0);
//         }
//
//         public static void Set(string warshipName, int skinIndex)
//         {
//             log.Debug($"Установка нового скина {nameof(skinIndex)} {skinIndex}");
//             PlayerPrefs.SetInt(warshipName, skinIndex);
//             PlayerPrefs.Save();
//         }
//     }
// }