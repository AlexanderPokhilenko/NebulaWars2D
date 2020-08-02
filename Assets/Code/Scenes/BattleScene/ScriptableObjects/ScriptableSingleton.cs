using System;
using System.Linq;
using Code.Common.Logger;
using UnityEngine;

namespace Code.Scenes.BattleScene.ScriptableObjects
{
    public abstract class ScriptableSingleton<T> : ScriptableObject 
        where T : ScriptableSingleton<T>
    {
        protected static T _instance;
        private static ILog log = LogManager.CreateLogger(typeof(ScriptableSingleton<T>));
        
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    Type type = typeof(T);
                    T[] instances = Resources.LoadAll<T>(string.Empty);
                    if (instances.Length > 1)
                    {
                        log.Error($"[ScriptableSingleton] Multiple instances of {type.Name} found!");
                    }
                    else
                    {
                        _instance = instances.FirstOrDefault();
                        if (_instance == null)
                        {
                            log.Error($"[ScriptableSingleton] No instance of {type.Name} found!");
                        }
                        else
                        {
                            log.Error($"[ScriptableSingleton] An instance of {type.Name} was found!");
                        }
                    }
                }

                return _instance;
            }
        }
    }
}
