# 1 简介

1. 进程内的库

   > * 可以按应用程序需求进行静态或动态连接
   > * SQLite直接访问其存储文件

2. 实现自给自足、无服务器、零配置、事务性的SQL数据库引擎。

# 2 命令

## 2.1 DDL（数据定义语言）

| 命令   | 描述                 |
| ------ | -------------------- |
| CREATE | 创建表、视图等       |
| ALTER  | 修改已有数据库对象   |
| DROP   | 删除整个表，或视图等 |



## 2.2 DML（数据操作语言）

| 命令   | 描述         |
| ------ | ------------ |
| INSERT | 创建一条记录 |
| UPDATE | 修改记录     |
| DELETE | 删除记录     |



## 2.3 DQL（数据查询语言）

| 命令   | 描述                         |
| ------ | ---------------------------- |
| SELECT | 从一个或多个表中检索某些记录 |

## 2.4 CMD

| 命令                  | 描述                                                         |
| :-------------------- | :----------------------------------------------------------- |
| .backup ?DB? FILE     | 备份 DB 数据库（默认是 "main"）到 FILE 文件。                |
| .bail ON\|OFF         | 发生错误后停止。默认为 OFF。                                 |
| .databases            | 列出数据库的名称及其所依附的文件。                           |
| .dump ?TABLE?         | 以 SQL 文本格式转储数据库。如果指定了 TABLE 表，则只转储匹配 LIKE 模式的 TABLE 表。 |
| .echo ON\|OFF         | 开启或关闭 echo 命令。                                       |
| .exit                 | 退出 SQLite 提示符。                                         |
| .explain ON\|OFF      | 开启或关闭适合于 EXPLAIN 的输出模式。如果没有带参数，则为 EXPLAIN on，即开启 EXPLAIN。 |
| .header(s) ON\|OFF    | 开启或关闭头部显示。                                         |
| .help                 | 显示消息。                                                   |
| .import FILE TABLE    | 导入来自 FILE 文件的数据到 TABLE 表中。                      |
| .indices ?TABLE?      | 显示所有索引的名称。如果指定了 TABLE 表，则只显示匹配 LIKE 模式的 TABLE 表的索引。 |
| .load FILE ?ENTRY?    | 加载一个扩展库。                                             |
| .log FILE\|off        | 开启或关闭日志。FILE 文件可以是 stderr（标准错误）/stdout（标准输出）。 |
| .mode MODE            | 设置输出模式，MODE 可以是下列之一：**csv** 逗号分隔的值**column** 左对齐的列**html** HTML 的 <table> 代码**insert** TABLE 表的 SQL 插入（insert）语句**line** 每行一个值**list** 由 .separator 字符串分隔的值**tabs** 由 Tab 分隔的值**tcl** TCL 列表元素 |
| .nullvalue STRING     | 在 NULL 值的地方输出 STRING 字符串。                         |
| .output FILENAME      | 发送输出到 FILENAME 文件。                                   |
| .output stdout        | 发送输出到屏幕。                                             |
| .print STRING...      | 逐字地输出 STRING 字符串。                                   |
| .prompt MAIN CONTINUE | 替换标准提示符。                                             |
| .quit                 | 退出 SQLite 提示符。                                         |
| .read FILENAME        | 执行 FILENAME 文件中的 SQL。                                 |
| .schema ?TABLE?       | 显示 CREATE 语句。如果指定了 TABLE 表，则只显示匹配 LIKE 模式的 TABLE 表。 |
| .separator STRING     | 改变输出模式和 .import 所使用的分隔符。                      |
| .show                 | 显示各种设置的当前值。                                       |
| .stats ON\|OFF        | 开启或关闭统计。                                             |
| .tables ?PATTERN?     | 列出匹配 LIKE 模式的表的名称。                               |
| .timeout MS           | 尝试打开锁定的表 MS 毫秒。                                   |
| .width NUM NUM        | 为 "column" 模式设置列宽度。                                 |
| .timer ON\|OFF        | 开启或关闭 CPU 定时器。                                      |

# 3 数据类型

| 存储类  | 描述                                                         |
| :------ | :----------------------------------------------------------- |
| NULL    | 值是一个 NULL 值。                                           |
| INTEGER | 值是一个带符号的整数，根据值的大小存储在 1、2、3、4、6 或 8 字节中。 |
| REAL    | 值是一个浮点值，存储为 8 字节的 IEEE 浮点数字。              |
| TEXT    | 值是一个文本字符串，使用数据库编码（UTF-8、UTF-16BE 或 UTF-16LE）存储。 |
| BLOB    | 值是一个 blob 数据，完全根据它的输入存储。                   |