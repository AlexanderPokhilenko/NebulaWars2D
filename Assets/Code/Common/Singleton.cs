using UnityEngine;

namespace Code.Common
{
    public class Singleton<T> : MonoBehaviour
        where T : Singleton<T>
    {
        private static T instance;
        protected virtual bool DontDestroy { get; } = false;
        private static readonly object LockObj = new object();
        
        public static T Instance()
        {
            lock(LockObj)
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        GameObject singleton = Resources.Load<GameObject>("Singletons/" + typeof(T).Name);
                        if (singleton == null)
                        {
                            singleton = new GameObject(typeof(T).Name);
                            instance = singleton.AddComponent<T>();
                        }
                        else
                        {
                            singleton = Instantiate(singleton);
                            singleton.name = typeof(T).Name;
                            instance = singleton.GetComponent<T>();
                            if (instance == null)
                            {
                                throw new System.NullReferenceException("Синглтон из префаба не содержал необходимый компонент.");
                            }
                        }
                    }
                }
            }
            
            return instance;
        }

        protected virtual void Awake()
        {
            lock(LockObj)
            {
                if (instance == null)
                {
                    instance = this as T;
                    if (DontDestroy)
                    {
                        transform.parent = null;
                        DontDestroyOnLoad(gameObject);
                    }
                }
                else
                {
                    Destroy(gameObject);
                }    
            }
        }
    }
}