using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.Warships.Utils
{
    public static class CurrentWarshipIndexStorage
    {
        private const string CurrentWarshipIndexName = "currentWarshipIndexName";
        public static  int Get()
        {
            return PlayerPrefs.GetInt(CurrentWarshipIndexName, 0);
        }

        public static void Set(int warshipIndex)
        {
            PlayerPrefs.SetInt(CurrentWarshipIndexName, warshipIndex);
            PlayerPrefs.Save();
        }
    }
}