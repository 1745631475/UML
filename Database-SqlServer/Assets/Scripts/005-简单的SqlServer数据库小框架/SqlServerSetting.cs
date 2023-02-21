using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// SqlServer配置文件
/// </summary>
[CreateAssetMenu(fileName = "SqlServerSetting", menuName = "ScriptableObject/SqlServerSetting", order = 0)]
public class SqlServerSetting : ScriptableObject
{
    [Serializable]
    public class SqlServerConfig
    {
        public string server;
        public string databaseName;
        public string userId;
        public string password;
    }

    /// <summary>
    /// 是否自动打开数据库
    /// </summary>
    public bool isAutoOpen;

    /// <summary>
    /// 数据库配置
    /// </summary>
    public List<SqlServerConfig> sqlServerConfigs;
}
