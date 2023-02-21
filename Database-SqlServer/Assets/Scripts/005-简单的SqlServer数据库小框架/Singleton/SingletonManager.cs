using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HFramework
{
    /// <summary>
    /// 单例管理器基类
    /// </summary>
    /// <typeparam name="T">实例类型</typeparam>
    public class SingletonManager<T> where T : SingletonManager<T>, new()
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                    instance = new T();
                return instance;
            }
        }
    }
}