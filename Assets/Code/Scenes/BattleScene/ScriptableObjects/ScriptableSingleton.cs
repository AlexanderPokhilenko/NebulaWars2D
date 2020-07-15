using System.Linq;
using UnityEngine;

namespace Code.Scenes.BattleScene.ScriptableObjects
{
    public abstract class ScriptableSingleton<T> : ScriptableObject where T : ScriptableSingleton<T>
    {
        protected static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    var type = typeof(T);
                    var instances = Resources.LoadAll<T>(string.Empty);
                    if (instances.Length > 1)
                    {
                       //DebugLogErrorFormat("[ScriptableSingleton] Multiple instances of {0} found!", type.ToString());
                    }
                    else
                    {
                        _instance = instances.FirstOrDefault();
                        if (_instance == null)
                        {
                           //DebugLogErrorFormat("[ScriptableSingleton] No instance of {0} found!", type.ToString());
                        }
                        else
                        {
                           //DebugLogFormat("[ScriptableSingleton] An instance of {0} was found!", type.ToString());
                        }
                    }
                }

                return _instance;
            }
        }
    }
}
