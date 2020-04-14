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

## 5 备注

### 5.1 using用法

1. 作为指令

   > 为命名空间创建别名或导入其他命名空间中定义的类型
   >
   > * 使用类型
   >
   >   ```c#
   >   using System.Text;
   >   using PC.Company;
   >   ```
   >
   > * 创建别名
   >
   >   ```c#
   >   using MyCompany=PC.Company;
   >   using Project=PC.Company.Project;
   >   ```
   >
   >   

2. 作为语句

   > 用于定义一个范围，在此范围的末尾将释放对象
   >
   > * 在using语句之中声明对象
   >
   >   ```c#
   >   Font font2 = new Font("Arial", 10.0f);
   >   　　    using (font2)
   >   　　    {
   >   　　        // use font2
   >   　　    }
   >   ```
   >
   > * 在using语句之前声明对象
   >
   >   ```c#
   >    using (Font font2 = new Font("Arial", 10.0f))
   >   　　    {
   >   　　        // use font2
   >   　　    }
   >   ```
   >
   > * 多个对象，必须在using语句内部声明
   >
   >   ```c#
   >   using (Font font3=new Font("Arial",10.0f), font4=new Font("Arial",10.0f))
   >   　　    {
   >   　　        // Use font3 and font4.
   >   　　    }
   >   ```



PS:

1. 只能用于实现了IDisposable接口的类型，禁止为不支持IDisposable接口的类型使用using语句，否则出现编译错误

2. 适用于清理单个非托管资源的情况，而多个非托管对象的清理最好用try-finally来实现

   > 内层using块引发异常时，将不能释放外层using块的对象资源



using本质：

​		程序编译阶段，编译器会自动将using语句生成为try-finally语句，并在finally块中调用对象的Dispose方法，来清理资源。

```c#
 Font f2 = new Font("Arial", 10, FontStyle.Bold);
　　try
　　{
　　    //执行文本绘制操作
　　}
　　finally
　　{
　　    if (f2 != null) ((IDisposable)f2).Dispose();
　　}
```

