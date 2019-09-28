# Singleton Pattern

用来创建独一无二的，只能有一个实例的对象的入场券。

单件模式的类图是所有模式的类图中最简单的，它的类图上只有一个类。

## 1 经典的单件模式实现（存在问题）

```java
public class Singleton{
    private static Singleton uniqueInstance;
    //这里是其他的有用实例化变量
    private Singleton(){}
    public static Singleton getInstance()
    {
       if(uniqueInstance==null)
       {
           uniqueInstance=new Singleton();
       }
        return uniqueInstance;
    }
    //这里有其他有用方法

}
```

## 2 定义单件模式

确保一个类只有一个实例，并提供一个全局访问点



##  3 化身为JVM（多线程中代码正确实现）

### 3.1 多线程的同步解决

在多线程中，经典的单件模式将会引发问题，getInstance()方法的次序和uniqueInstance的值会发生错误。

解决方案就是将 getInstance()编程同步(synchronized)方法，多线程灾难就会解决：

```java
public class Singleton{
    private static Singleton uniqueInstance;
    private Singleton(){}
    public static synchronized Singleton getInstance(){
        if(uniqueInstance==null)
        {
            uniqueInstance=new Singleton();
        }
        return uniqueInstance;
    }
}

//通过增加synchronized关键字到getInstance()方法中
//我们迫使每个线程在进入这个方法之前，要先等待别的线程离开该方法
//也就是说，不会有两个线程可以同时进入这个方法
```

### 3.2 多线程改善

只有第一次执行此方法时，才真正需要同步。一旦设置好uniqueInstance变量，就不再需要同步这个方法了。

解决方案：

1. 如果getInstance()的性能对应用程序不是很关键，就什么都别做

2. 使用“急切”创建实例，而不用延迟实例化的做法

   * 如果应用程序总是创建并使用单件实例，或者在创建和运行时方面的负担不太繁重，你可能想要急切（eagerly）创建此单件

     ```java
     public class Singleton{
         //在静态初始化器中创建单件，保证线程安全
         private static Singleton uniqueInstance = new Singleton();
         private Singleton(){}
         public static Singleton getInstance(){
             return uniqueInstance;//已经有实例了，直接使用
         }
     }
     
     ```

3. 用“双重检查加锁”（不适用于1.4及更早版本的Java)，在getInstance()中减少使用同步

   首先检查是否实例已经创建了，如果尚未创建，“才”进行同步。

   ```java
   //volatile关键词确保：
   //当uniqueInstance变量被初始化成Singleton实例时，多个线程正确地处理uniqueInstance变量。
   
   public class Singleton{
       private volatile static Singleton uniqueInstance;
       private Singleton(){}
       public static Singleton getInstance(){
           //检查实例，如果不存在，就进入同步区块
           //只有第一次才彻底执行这里的代码
           if(uniqueInstance==null)
           {
               synchronized(Singleton.class){
                   if(uniqueInstance==null){
                       uniqueInstance=new Singleton();
                   }
               }
           }
       }
   }
   ```

   