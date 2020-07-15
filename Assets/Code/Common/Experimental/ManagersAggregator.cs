using System.Collections.Generic;
using UnityEngine;

//TODO https://habr.com/ru/post/494930/

namespace Code.Common.Experimental
{
    public static class ControllerAggregator
    {
        static readonly Dictionary<string, MonoBehaviour> Controllers = new Dictionary<string, MonoBehaviour>();

        public static void AddController<T>(T controller)
        {
            string keyWord = typeof(T).ToString();

            if(Controllers.ContainsKey(keyWord))
            {
                Debug.Log($"[ControllersAregator] Менеджер -{controller}- с ключом -{keyWord}- уже существует");
            }
            else
            {
                Controllers.Add(keyWord, controller as MonoBehaviour);
                Debug.Log($"<color=green>[ControllersAregator] Добавлен новый менеджер -{controller}- с ключом -{keyWord}-</color>");
            }
        }

        public static T GetController<T>(string callback) where T: Singleton<T>
        {
            string keyWord = typeof(T).ToString();

            if(Controllers.ContainsKey(keyWord))
            {
                Debug.Log($"<color=yellow>[{callback}] Получение менеджера -{keyWord}-</color>");

                T manager = null;

                if(Controllers.TryGetValue(keyWord, out var monoBehaviour))
                {
                    manager = (T)monoBehaviour;
                    Debug.Log($"<color=green>[{callback}] Менеджер -{manager}- получен</color>");
                }
                else
                {
                    Debug.Log($"<color=red>[{callback}] Ошибка получения менеджера -{keyWord}-</color>");
                }

                return manager;
            }

            Debug.Log($"<color=red>[ControllersAregator] Менеджер с ключом -{keyWord}- отсутствует в словаре.</color>");
            return null;
        }

        public static void RemoveController<T>()
        {
            string keyWord = typeof(T).ToString();

            if(Controllers.ContainsKey(keyWord))
            {
                Controllers.Remove(keyWord);
                Debug.Log($"[ControllersAregator] Менеджер с ключом -{keyWord}- удален из словаря");
            }
            else
            {
                Debug.Log($"[ControllersAregator] Менеджер с ключом -{keyWord}- отсутствует в словаре.");
            }
        }
    }
}