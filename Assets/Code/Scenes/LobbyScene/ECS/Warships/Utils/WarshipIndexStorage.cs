using Code.Common.Logger;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.Warships.Utils
{
    public static class WarshipIndexStorage
    {
        private const string PlayerPrefsKey = "warshipIndex";
        private static ILog log = LogManager.CreateLogger(typeof(WarshipIndexStorage));
        public static void WriteWarshipIndex(int warshipIndex)
        {
            // log.Error($"Установка нового индекса корабля warshipIndex {warshipIndex}");
            PlayerPrefs.SetInt(PlayerPrefsKey, warshipIndex);
            PlayerPrefs.Save();
        }

        public static int ReadWarshipIndex()
        {
            int warshipIndex = PlayerPrefs.GetInt(PlayerPrefsKey, 0);
            // log.Error($"Чтение индекса корабля warshipIndex {warshipIndex}");
            return warshipIndex;
        }
    }
}