using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HFramework
{
    /// <summary>
    /// 单例模式基类（继承Mono）
    /// </summary>
    /// <typeparam name="T">实例类型</typeparam>
    public class SingletonMono<T> : MonoBehaviour where T : SingletonMono<T>
    {
        private static T instance;
        public static T Instance => instance;
        protected virtual void Awake() => instance = this as T;
    }
}
