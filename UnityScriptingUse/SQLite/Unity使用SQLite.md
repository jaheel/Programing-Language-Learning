# Unity使用SQLite

## 1 Plugins

1. 在项目Assets目录下创建Plugins文件夹

2. 放入sqlite3.dll和Mono.Data.Sqlite.dll

   > sqlite3.dll获取路径：官网下载
   >
   > Mono.Data.Sqlite.dll获取路径
   >
   > * /Unity.app/Contents/MonoBleedingEdge/lib/mono/2.0-api/Mono.Data.Sqlite.dll
   > * /Unity.app/Contents/Mono/lib/mono/2.0/Mono.Data.Sqlite.dll(更加稳定)

PS:

​	sqlite3.dll仅用于windows平台

## 2 Mono.Data.Sqlite使用

### 2.1 SqliteConnection

打开与关闭数据库

```c#
//需带"Data Souce="前缀, dbPath为数据库的路径
SqliteConnection connection=new SqliteConnection("Data Source="+dbPath);
//打开
connection.Open();
//关闭
connection.Close();
```

### 2.2 SqliteCommand

1. 构造操作指令

   ```c#
   SqliteConnection connection=new SqliteConnection("Data Source="+dbPath);
   
   SqliteCommand command=new SqliteCommand("SELECT * FROM table");
   SqliteCommand command = new SqliteCommand("SELECT * FROM table", connection);
   SqliteCommand command = new SqliteCommand("SELECT * FROM table", connection, transaction);
   SqliteCommand command = connection.CreateCommand();
   command.CommandText = "SELECT * FROM table";
   
   
   ```

2. 执行与取消

   ```c#
   SqliteCommand command=connection.CreateCommand();
   command.CommandText="SELECT * FROM table";
   //执行并取得结果
   SqliteDataReader reader=comand.ExecuteReader();
   //执行并返回执行行数，仅适用于INSERT、DELETE、UPDATE，其他返回0或-1
   int executeRowsCount=command.ExecuteNonQuery();
   //执行并返回结果的第一行第一列数据或null
   var obj=command.ExecuteScalar();
   
   //取消
   command.Cancel();
   
   //异步执行
   command.ExecuteReaderAsync();
   command.ExecuteNonQueryAsync();
   command.ExecuteScalarAsync();
   ```

3. 添加参数

   ```c#
   SqliteCommand command =connection.CreateCommand();
   
   //在SQL语句中使用key替代值，其中key前需添加:、@或$作为前缀
   command.CommandText="INSERT INTO table (col1,col2,col3) VALUES ($key1,:key2,@key3)";
   command.Parameters.AddWithValue("$key1",1);
   command.Parameters.AddWithValue(":key2","value2");
   command.Parameters.Add(new SqliteParameter("@key3","value3"));
   //执行并取得结果
   SqliteDataReader reader=command.ExecuteReader();
   ```

4. 执行事务

   ```c#
   using(var command=connection.CreateCommand())
   //执行事务    
   using(var transaction=connection.BeginTransaction())
   {
       try{
           //执行数据库操作
           command.CommandText="INSERT INTO table(col1,col2,col3) VALUES ('value1','value2','value3')";
           command.ExecuteNonQuery();
           command.CommandText="SELECT * FROM table";
           SqliteDataReader reader=command.ExecuteReader();
           reader.Close();
           //提交
           transaction.Commit();
       }
       catch(SqliteException e)
       {
           //回滚
           transaction.Rollback();
       }
   }
   ```



### 2.3 SqliteDataReader

读取结果

```c#
SqliteDataReader reader=command.ExecuteReader();
//若一次执行多条SQL语句返回多组结果，使用NextResult到下一组
While(reader.NextResult())
{
    //遍历该组结果每一行数据
    while(reader.Read())
    {
        //获取该行列数
        int count=reader.FieldCount;
        //获取第一列数据
        var obj=reader[0];
        //获取指定列数据
        var obj=reader["colum1"];
        //获取第二列数据并以int类型返回
        int result=reader.GetInt32(2);
    }
}

//使用完需关闭reader,否则同一个SqliteCommand对象的下次查询会出问题
reader.Close();
//或使用using包裹SqliteDataReader
using(SqliteDataReader reader=command.ExecuteReader())
{
    
}
```

