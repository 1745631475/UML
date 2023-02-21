using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using System.Data;

public class Lesson2 : MonoBehaviour
{
    private void Start()
    {
        #region 知识点一 数据库的创建
        //1.创建连接字符串
        SqlConnectionStringBuilder sqlStr = new SqlConnectionStringBuilder();
        sqlStr.DataSource = "192.168.0.103,1433";
        sqlStr.UserID = "sa";
        sqlStr.Password = "sa123";
        //2.创建SqlConnection指定连接字符串并打开
        SqlConnection sqlConnection = new SqlConnection(sqlStr.ConnectionString);
        if (sqlConnection.State != ConnectionState.Open)
            sqlConnection.Open();
        //3.通过SqlConnection创建SqlCommand对象
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        //4.执行创建数据库的T-Sql语句
        sqlCommand.CommandText =
            "if DB_ID('Test') is not null " +
            "drop database Test " +
            "create database Test";
        try
        {
            sqlCommand.ExecuteNonQuery();
            Debug.Log("数据库创建成功");
        }
        catch (SqlException ae)
        {
            Debug.Log("数据库创建失败。" + ae.Message.ToString());
        }
        //5.使用完后记得释放资源
        sqlConnection.Dispose();
        sqlConnection.Close();
        sqlCommand.Dispose();
        #endregion
    }
}
