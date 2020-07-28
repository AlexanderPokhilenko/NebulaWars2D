using Code.Common.Logger;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.Warships.Utils
{
    public static class CurrentWarshipTypeStorage
    {
        private const string Key = "warshipIndex";
        private static readonly ILog Log = LogManager.CreateLogger(typeof(CurrentWarshipTypeStorage));
        
        public static void WriteWarshipIndex(WarshipTypeEnum warshipTypeEnum)
        {
            Log.Error($"Установка типа корабля {warshipTypeEnum.ToString()}");
            PlayerPrefs.SetInt(Key, (int) warshipTypeEnum);
            PlayerPrefs.Save();
        }

        public static WarshipTypeEnum ReadWarshipIndex()
        {
            var result = (WarshipTypeEnum) PlayerPrefs.GetInt(Key, 0);
            Log.Error($"Чтение типа корабля  {result.ToString()}");
            return result ;
        }
    }
}