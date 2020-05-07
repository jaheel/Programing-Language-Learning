# SQLite亲缘字段

| **声明类型**                                                 | **亲缘类型** | **应用规则** |
| ------------------------------------------------------------ | ------------ | ------------ |
| INT INTEGER TINYINT SMALLINT MEDIUMINT BIGINT UNSIGNED BIG INT INT2 INT8 | INTEGER      | 1            |
| CHARACTER(20) VARCHAR(255) VARYING CHARACTER(255) NCHAR(55) NATIVE CHARACTER(70) NVARCHAR(100) TEXT CLOB | TEXT         | 2            |
| BLOB                                                         | NONE         | 3            |
| REAL DOUBLE DOUBLE PRECISION FLOAT                           | REAL         | 4            |
| NUMERIC DECIMAL(10,5) BOOLEAN DATE DATETIME                  | NUMERIC      | 5            |

