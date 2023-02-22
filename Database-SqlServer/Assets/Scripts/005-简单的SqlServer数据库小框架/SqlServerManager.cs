using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HFramework;
using Sirenix.OdinInspector;

/// <summary>
/// SqlServer管理器
/// </summary>
public class SqlServerManager : SingletonMono<SqlServerManager>
{
    //使用外部配置
    public bool useExternalConfig;
    //SqlServer配置表
    [InlineEditor(DrawPreview = true),ReadOnly]
    [ShowIf("@useExternalConfig==false")]
    public SqlServerSetting sqlServerSetting;
    //当前场景中所有的ServerEntity
    private Dictionary<int, SqlServerEntity> allSqlServerEntitys;
}
