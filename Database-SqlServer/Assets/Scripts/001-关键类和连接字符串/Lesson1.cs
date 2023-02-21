using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using System.Data;

public class Lesson1 : MonoBehaviour
{
    private void Start()
    {
        #region 知识点一 关键类
        //关键类：SqlConnection
        //作用:表示到SqlServer数据库的连接
        SqlConnection sqlConnection = new SqlConnection();
        //重要属性
        //1.获取或设置用于打开SqlServer数据库的连接字符串。
        Debug.Log(sqlConnection.ConnectionString);
        //2.获取当前数据库的名称或打开连接后要使用的数据库的名称。
        Debug.Log(sqlConnection.Database);
        //3.获取SqlServer的连接状态
        Debug.Log(sqlConnection.State);
        //重要方法
        //1.使用由ConnectionString指定的属性设置打开一个数据库连接。
        sqlConnection.Open();
        //2.关闭与数据库之间的连接。 此方法是关闭任何打开连接的首选方法。
        sqlConnection.Close();
        //3.创建并返回与SqlConnection关联的SqlCommand对象。
        sqlConnection.CreateCommand();

        //关键类：SqlCommand
        //作用：表示要对SqlServer数据库执行的一个Transact-SQL语句或存储过程。
        SqlCommand sqlCommand = new SqlCommand();
        //重要属性
        //1.获取或设置要在数据源中执行的Transact-SQL语句、表名或存储过程。
        Debug.Log(sqlCommand.CommandText);
        //2.获取或设置一个值，该值指示解释CommandText属性的方式。
        Debug.Log(sqlCommand.CommandType);
        //3.获取或设置SqlCommand的此实例使用的SqlConnection。
        Debug.Log(sqlCommand.Connection);
        //重要方法
        //1.连接执行Transact-SQL语句并返回受影响的行数。（适用于非查询）
        sqlCommand.ExecuteNonQuery();
        //2.执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。（适用于单查询）
        sqlCommand.ExecuteScalar();
        //3.执行查询，并返回查询到的所以结果集，存储到SqlDataReader中（适应于多查询）
        sqlCommand.ExecuteReader();

        //更多......
        //1.SqlDataReader：提供一种从SqlServer数据库中读取数据的方式。
        //2.SqlDataAdapter：表示用于填充DataSet和更新SqlServer数据库的一组数据命令和一个数据库连接。
        //3.DataTable：表示内存中数据的一个表。
        //4.DataSet：表示数据的内存中缓存。
        //5.DataView：代表DataTable的可绑定数据的自定义视图，
        //它用于排序、筛选、搜索、编辑和导航。
        //DataView不存储数据，而改为表示对应的DataTable的连接视图。
        //更改DataView的数据会影响DataTable。
        //更改DataTable的数据将影响与之关联的所有DataView。
        //6.DataColumn：表示 DataTable 中的列的架构。
        //7.DataRow：表示 DataTable 中的一行数据。
        //8.SqlParameter：表示 SqlCommand 的参数，或者其与 DataSet 列的映射。 
        #endregion

        #region 知识点二 连接字符串
        //连接字符串连接到数据库的基本配置
        //连接SqlServer数据库通常需要指定服务器地址、连接方式、数据库名称、用户名、密码等
        //连接字符串就是通过指定格式配置上述的信息用于数据库连接
        //--------------------
        //连接字符串格式：
        //连接字符串的基本格式包括一系列用分号分隔的关键字/值对。 
        //每个关键字和它的值之间用等号 (=) 连接。
        //--------------------
        //常用的几种连接数据库的连接字符串
        //1.连接到SqlServer数据库
        //Server=192.168.0.103,1443;database=“数据库名称”;uid=sa;pwd=sa123456;
        //2.连接到SqlServer服务器
        //Server=192.168.0.103,1443;uid=sa;pwd=sa123456;
        //--------------------
        //关键类：SqlConnectionStringBuilder
        //为创建和管理由SqlConnection类使用的连接字符串的内容提供了一种简单方法。
        #endregion
    }
}
