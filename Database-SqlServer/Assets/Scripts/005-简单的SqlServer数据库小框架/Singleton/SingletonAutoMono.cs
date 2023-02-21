using UnityEngine;

namespace HFramework
{
    /// <summary>
    /// 单例模式基类（继承Mono 自动化）
    /// </summary>
    /// <typeparam name="T">实例类型</typeparam>
    public class SingletonAutoMono<T> : MonoBehaviour where T : SingletonAutoMono<T>
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).ToString();
                    DontDestroyOnLoad(obj);
                    instance = obj.AddComponent<T>();
                }
                return instance;
            }
        }
    }
}