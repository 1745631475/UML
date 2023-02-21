using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HFramework;

/// <summary>
/// SqlServer管理器
/// </summary>
public class SqlServerManager : SingletonMono<SqlServerManager>
{
    //SqlServer配置表
    public SqlServerSetting sqlServerSetting;
    //当前场景中所有的ServerEntity
    private Dictionary<int, SqlServerEntity> allSqlServerEntitys;
}
