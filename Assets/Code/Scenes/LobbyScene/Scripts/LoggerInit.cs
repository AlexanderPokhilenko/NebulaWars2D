using Code.Common;
using Code.Common.Logger;
using UnityEngine;

namespace Code.Scenes.LobbyScene.Scripts
{
    public class LoggerInit : MonoBehaviour
    {
        private readonly ILog log = LogManager.CreateLogger(typeof(LoggerInit));
        
        private void Awake()
        {
            UnityThread.InitUnityThread();
            LoggerConfig config = new LoggerConfig(1, 10_000,
                Application.persistentDataPath);
            if (LogManager.TrySetConfig(config))
            {
                log.Info("Путь к файлу с логами "+config.PersistentDataPath);    
            }
        }
        
        private void OnDestroy()
        {
            LogManager.Print();
        }
    }
}