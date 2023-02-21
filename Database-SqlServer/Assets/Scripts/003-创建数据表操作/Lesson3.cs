using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UnityEngine;

public class Lesson3 : MonoBehaviour
{
    private void Start()
    {
        #region 知识点一 数据表的创建
        //1.创建连接字符串
        SqlConnectionStringBuilder sqlStr = new SqlConnectionStringBuilder();
        sqlStr.DataSource = "192.168.0.103,1433";
        sqlStr.UserID = "sa";
        sqlStr.Password = "sa123";
        //2.创建SqlConnection指定连接字符串并打开
        SqlConnection sqlConnection = new SqlConnection(sqlStr.ConnectionString);
        if (sqlConnection.State != ConnectionState.Open)
            sqlConnection.Open();
        //3.切换到指定数据库
        try
        {
            sqlConnection.ChangeDatabase("Test");
        }
        catch (SqlException se)
        {
            Debug.LogError(se);
        }
        //4.通过SqlConnection创建SqlCommand对象
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        //5.执行创建数据表的T-Sql语句
        sqlCommand.CommandText =
            "if object_id('Test','U') is not null " +
            "drop table Test " +
            "create table Test(id int not null," +
            "name varchar(20) not null," +
            "age int not null," +
            "address char(25)," +
            "salary decimal(18,2)," +
            "primary key(id))";
        try
        {
            sqlCommand.ExecuteNonQuery();
            Debug.Log("数据表创建成功");
        }
        catch (SqlException se)
        {
            Debug.Log("数据表创建失败：" + se.Message.ToString());
        }
        //5.使用完后记得释放资源
        sqlConnection.Dispose();
        sqlConnection.Close();
        sqlCommand.Dispose();
        #endregion
    }
}
