using Code.Common.Logger;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.Warships.Utils
{
    public static class CurrentWarshipTypeStorage
    {
        private const string Key = "warshipIndex";
        private static readonly ILog Log = LogManager.CreateLogger(typeof(CurrentWarshipTypeStorage));
        
        public static void WriteWarshipType(WarshipTypeEnum warshipTypeEnum)
        {
            // Log.Debug($"Установка типа корабля {warshipTypeEnum.ToString()}");
            PlayerPrefs.SetInt(Key, (int) warshipTypeEnum);
            PlayerPrefs.Save();
        }

        public static WarshipTypeEnum ReadWarshipIndex()
        {
            var result = (WarshipTypeEnum) PlayerPrefs.GetInt(Key, (int) WarshipTypeEnum.Hare);
            // Log.Debug($"Чтение типа корабля  {result.ToString()}");
            return result ;
        }
    }
}