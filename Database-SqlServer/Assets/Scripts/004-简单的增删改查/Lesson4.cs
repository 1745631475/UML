using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UnityEngine;

public class Lesson4 : MonoBehaviour
{
    private void Start()
    {
        #region 知识点一 数据库的增删改查
        //数据库连接--------------------
        string connectionString = "Server=192.168.0.103,1433;database=Test;uid=sa;pwd=sa123;";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        if (sqlConnection.State != ConnectionState.Open)
            sqlConnection.Open();
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        //增----------insert----------
        sqlCommand.CommandText =
            "insert into Test(id,name,age,address) values(1,'沐风',21,'山东');" +
            "insert into Test values(2,'清风',23,'湖南',500)";
        try
        {
            sqlCommand.ExecuteNonQuery();
            Debug.Log("数据增加成功");
        }
        catch (SqlException se)
        {
            Debug.Log("数据增加失败：" + se.Message.ToString());
        }
        //删----------delete----------
        sqlCommand.CommandText =
            "delete from Test where id=1";
        try
        {
            sqlCommand.ExecuteNonQuery();
            Debug.Log("数据删除成功");
        }
        catch (SqlException se)
        {
            Debug.Log("数据删除失败：" + se.Message.ToString());
        }
        //改----------update----------
        sqlCommand.CommandText =
            "update Test set name='明月' where id=2"; ;
        try
        {
            sqlCommand.ExecuteNonQuery();
            Debug.Log("数据修改成功");
        }
        catch (SqlException se)
        {
            Debug.Log("数据修改失败：" + se.Message.ToString());
        }
        //查----------select----------
        //查之前先增加一些数据
        sqlCommand.CommandText =
            "insert into Test values(3,'亚瑟',25,'重庆',400);" +
            "insert into Test values(4,'李白',25,'湖北',3000);" +
            "insert into Test values(5,'韩信',26,'南京',700);" +
            "insert into Test values(6,'剑圣',26,'云南',400);";
        try
        {
            sqlCommand.ExecuteNonQuery();
            Debug.Log("数据增加成功");
        }
        catch (SqlException se)
        {
            Debug.Log("数据增加失败：" + se.Message.ToString());
        }
        //查询单个结果
        sqlCommand.CommandText =
            "select count(*) from Test";
        try
        {
            object count = sqlCommand.ExecuteScalar();
            Debug.Log($"查询Test中共有：{count}条数据");
        }
        catch (SqlException se)
        {
            Debug.Log("数据查询失败：" + se.Message.ToString());
        }
        //查询多个结果
        sqlCommand.CommandText =
            "select id,name,age,address from Test where age=25";
        try
        {
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            //1.判断是否有数据
            if (sqlDataReader.HasRows)
            {
                //2.开始读取数据,读取的方式是一行一行读,每执行一次Read(),读取一行
                while (sqlDataReader.Read())
                {
                    int id = sqlDataReader.IsDBNull(0) ? 0 : sqlDataReader.GetInt32(0);
                    string name = sqlDataReader.IsDBNull(1) ? string.Empty : sqlDataReader.GetString(1);
                    int age = sqlDataReader.IsDBNull(2) ? 2 : sqlDataReader.GetInt32(2);
                    string address = sqlDataReader.IsDBNull(3) ? string.Empty : sqlDataReader.GetString(3);
                    Debug.Log($"读取数据：id={id},name={name},age={age},address={address};");
                }
            }
        }
        catch (SqlException se)
        {
            Debug.Log("数据查询失败：" + se.Message.ToString());
        }
        //释放资源关闭数据库
        sqlConnection.Close();
        sqlConnection.Dispose();
        sqlCommand.Dispose();
        #endregion
    }
}
