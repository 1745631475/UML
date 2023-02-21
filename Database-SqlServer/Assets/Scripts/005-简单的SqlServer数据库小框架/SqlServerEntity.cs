using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// SqlServer数据库实例
/// </summary>
public class SqlServerEntity : MonoBehaviour
{
    //是否自动打开数据库
    public bool isAutoOpen;
    //数据库ID
    public int sqlId;
    //配置
    public SqlServerSetting.SqlServerConfig sqlServerConfig;
    //Sql连接
    private SqlConnection sqlConnection;
    //sql字符串
    private SqlConnectionStringBuilder sqlString;

    private void Start()
    {
        sqlString = new SqlConnectionStringBuilder()
        {
            DataSource = sqlServerConfig.server,
            InitialCatalog = sqlServerConfig.databaseName,
            UserID = sqlServerConfig.userId,
            Password = sqlServerConfig.password
        };
        sqlConnection = new SqlConnection(sqlString.ConnectionString);
        if (isAutoOpen)
            Open();
    }

    private void OnDestroy()
    {
        Close();
        sqlConnection.Dispose();
    }

    /// <summary>
    /// 创建数据库命令
    /// </summary>
    public SqlCommand CreateCommand()
    {
        return sqlConnection.CreateCommand();
    }

    /// <summary>
    /// 数据库初始化
    /// </summary>
    public void SqlInit(string server, string databaseName, string userId, string password, bool isAutoOpen = false)
    {
        sqlServerConfig.server = server;
        sqlServerConfig.databaseName = databaseName;
        sqlServerConfig.userId = userId;
        sqlServerConfig.password = password;
        this.isAutoOpen = isAutoOpen;
    }

    /// <summary>
    /// 打开数据库
    /// </summary>
    public void Open()
    {
        if (sqlConnection.State != ConnectionState.Open)
        {
            try
            {
                sqlConnection.Open();
                Debug.Log("数据库连接成功：" + sqlConnection.DataSource + ";" + sqlConnection.Database);
            }
            catch (SqlException se)
            {
                Debug.Log("数据库打开错误：" + se);
            }
        }
    }

    /// <summary>
    /// 关闭数据库
    /// </summary>
    public void Close()
    {
        if (sqlConnection.State != ConnectionState.Closed)
        {
            try
            {
                sqlConnection.Close();
                Debug.Log("数据库关闭成功：" + sqlConnection.DataSource + ";" + sqlConnection.Database);
            }
            catch (SqlException se)
            {
                Debug.Log("数据库关闭错误：" + se);
            }
        }
    }
}
