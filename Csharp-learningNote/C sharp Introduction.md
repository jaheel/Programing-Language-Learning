# C sharp Introduction

## 1 特性

面向对象、面向组件

**垃圾回收：**自动回收未使用的对象占用的内存

**异常处理：**一种结构化的可扩展方法用于错误检测和恢复

**类型安全：**不可能从未初始化的变量中进行读取，将数组索引在其边界之外，或者执行未检查的类型转换。



**统一类型系统：**所有C#类型（包括int和double等基元类型）均继承自一个根object类型。



## 2 类型

### 2.1 值类型

直接包含数据

| 简单类型 | 枚举类型    | 结构类型      | 可以为null的类型               |
| -------- | ----------- | ------------- | ------------------------------ |
| sbyte    | enum E{...} | struct S{...} | 值为null的其他所有值类型的扩展 |
| short    |             |               |                                |
| int      |             |               |                                |
| long     |             |               |                                |
| byte     |             |               |                                |
| ushort   |             |               |                                |
| uint     |             |               |                                |
| ulong    |             |               |                                |
| char     |             |               |                                |
| float    |             |               |                                |
| double   |             |               |                                |
| decimal  |             |               |                                |
| bool     |             |               |                                |



### 2.2 引用类型

存储对象的引用

| 类类型       | 接口类型         | 数组类型 | 委托类型            |
| ------------ | ---------------- | -------- | ------------------- |
| object       | interface I{...} | int[]    | delegate int D(...) |
| string       |                  | int[,]   |                     |
| class C{...} |                  |          |                     |
|              |                  |          |                     |

## 3 语句

| 选择语句 | 迭代语句 | 跳转语句 |               |
| -------- | -------- | -------- | ------------- |
| if       | while    | break    | try...catch   |
| switch   | do       | continue | try...finally |
|          | for      | goto     | checked       |
|          | foreach  | throw    | unchecked     |
|          |          | return   | lock          |
|          |          | yield    | using         |
|          |          |          |               |

## 4 类和对象

### 4.1 成员

常量、字段、方法、属性、索引器、事件、运算符、构造函数、析构函数、类型

### 4.2 可访问性

public、protected、internal、protected internal、private

### 4.3 参数

值参数、引用参数(ref)、输出参数(out)、输入参数(in)、参数数组(params)

### 4.4 virtual、override、abstract

虚方法：运行时类型决定(virtual)

重写虚方法(override)

抽象方法：无实现的虚方法(abstract)

> 只允许在abstract类中使用，必须在所有非抽象派生类中重写抽象方法

