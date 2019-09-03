# C#高质量编程学习总结

## 第1章 基本语言要素

### 建议1：正确操作字符串

```
String str1="str1"+9;
String str2="str2"+9.ToString();
```

第二行效率高于第一行，减少了装箱操作

（在自己编写的代码中，应当尽可能地避免编写不必要地装箱代码）

① 避免过多装箱

② 避免分配额外的内存空间

### 建议2：使用默认转型方法

1、使用类型的转换运算符

2、使用类型内置的Parse、TryParse，或者如ToString、ToDouble和ToDateTime等方法

3、使用帮助类提供的方法

4、使用CLR支持的转型

### 建议3：区别对待强制转型与as和is

如果类型之间都上溯到某个共同的基类，那么根据此基类进行的转型（即基类转型为子类本身）应该使用as。子类与子类之间的转型，则应该提供转换操作符，以便进行强制转型。

**as 操作符永远不会抛出异常，如果类型不匹配或转型源对象为null，那么转型之后的值也为null**

```
static void DoWithSomeType(object obj)
{
   SecondType secondType=obj as SecondType;
   if(secondType!=null)
   {
       //省略
   }
}

```

**as 不能操作基元类型**

涉及基元类型的算法，就需要is转型前的类型判断，以避免转型失败。

```
static void DoWithSomeType(object obj)
{
   if(obj is SecondType)
   {
    SecondType secondType=obj as SecondType;
    //省略
   }
}
```

**没有上一版效率高，进行了两次类型检测**

### 建议4：TryParse比Parse好

能用TryParse就用TryParse函数

### 建议5：使用int?来确保值类型也可以为null

```
Nullable<int> i=null;
也可为：
int? i=null;

例如：Nullable<Int32> 值范围：-2147483648-2147483647,再加一个null值

int? i=123;
int j= i ?? 0;//如果i的HasValue为true，则将i的value赋值给j；否则，就给j赋值为0
```

### 建议6：区别readonly和const的使用方法

本质区别：

const 是一个编译期常量，readonly 是一个运行时常量。

const 只能修饰基元类型、枚举类型或字符串类型，readonly没有限制。

### 建议7：将0值作为枚举的默认值

### 建议8：避免给枚举类型的元素提供显式的值

枚举元素允许设定重复的值

### 建议9：习惯重载运算符

```
Salary mikeIncome =new Salary(){RMB=22};
Salary roseIncome=new Salary(){RMB=33};
Salary familiIncome=mikeIncome+roseIncome;

class Salary
{
   public int RMB{get;set;}
   public static Salary operator +(Salary s1,Salary s2)
   {
   s2.RMB+=s1.RMB;
   return s2;
   }
}
```

### 建议10：创建对象时需要考虑是否实现比较器

### 建议11：区别对待==和Equals

值相等性、引用相等性，==和Equals皆可重载

我们要定义”值相等性“，应该仅仅去重载Equals方法，同时让"=="表示"引用相等性"

### 建议12：重写Equals时也要重写GetHashCode

### 建议13：为类型输出格式化字符串

### 建议14：正确实现浅拷贝和深拷贝

拷贝：为对象创建副本

浅拷贝：值类型字段完全拷贝，副本中修改不影响源对象；引用类型在副本中是引用类型的引用，对引用类型的修改会影响到源对象本身。

深拷贝：值类型、引用类型均会被重新创建并赋值，不会影响到源对象本身。

### 建议15：使用dynamic来简化反射实现

var类型，一旦被编译，编译期会自动匹配var变量的实际类型，并用实际类型来替换该变量的声明

dynamic类型，被编译后为object类型，（编译器对dynamic类型进行特殊处理，让它在编译期间不进行任何的类型检查，而是将类型检查放到了运行期）

**始终用dynamic优化反射实现**



## 第2章 集合和LINQ

### 建议16：元素数量可变的情况下不应使用数组

```
int [] iArr={0,1,2,3,4,5,6};
ArrayList arrayListInt=ArrayList.Adapter(iArr);//将数组转变为ArrayList
arrayListInt.Add(7);
List<int> listInt=iArr.ToList<int>();//将数组转变为List<T>
listInt.Add(7);
```



### 建议17：多数情况下使用foreach进行循环遍历

### 建议18：foreach不能代替for

foreach(迭代器)（不支持集合增删操作）

for(索引器)

### 建议19：使用更有效的对象和集合初始化

对象初始化：

```
class Program
{
  static void Main(string[] args)
  {
     Person person=new Person(){Name="Mike",Age=20};
  }
}

class Person
{
   public string Name{get;set;}
   public int Age{get;set;}
}
```

集合初始化：

```
List<Person> personList=new List<Person>()
{
   new Person() {Name="Rose",Age=19},
   mike,null
};
```

### 建议20：使用泛型集合代替非泛型集合

例如：

```
List<int> intList=new List<int>();
intList.Add(1);
intList.Add(2);
foreach(var item int intList)
{
   Console.WriteLine(item.ToString());
}
```

### 建议21：选择正确的集合

如果集合的数目固定且不涉及转型，使用数组效率高，否则就使用List<T>。

### 建议22：确保集合的线程安全

**多个线程上添加或删除元素时，线程之间必须保持同步**

通过加锁实现线程的互斥运行

### 建议23：避免将List\<T>作为自定义集合类的基类

​        需扩展的泛型接口通常是IEnumerable<T>和ICollection<T>，前者规范了集合类的迭代功能，后者规范了一个集合通常会有的操作。

### 建议24： 迭代器应该是只读的

### 建议25：谨慎集合属性的可写操作

### 建议26：使用匿名类型存储LINQ查询结果

匿名类型特性：

> 既支持简单类型也支持复杂类型
>
> > 简单类型必须是一个非空初始值，复杂类型则是一个以new开头的初始化项

> 只读属性，没有属性设置器，一旦被初始化不可更改

> 如果两个匿名类型的属性值相同，那么就认为两个匿名类型相等

> 匿名类型可以在循环中用作初始化器

> 匿名类型支持智能感知

### 建议27：在查询中使用Lambda表达式

### 建议28：理解延迟求值和主动求值之间的区别

延迟求值（lazy evaluation)、主动求值(eager evaluation)

```
List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var temp1 = from c in list where c > 5 select c;
            var temp2 = (from c in list where c > 5 select c).ToList<int>();
            list[0] = 11;
            Console.Write("temp1: ");
            foreach (var item in temp1)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.Write("\ntemp2: ");
            foreach (var item in temp2)
            {
                Console.Write(item.ToString() + " ");
            }
            
            结果：
            temp1: 11 6 7 8 9
            temp2: 6 7 8 9
```

*查询调用ToList、ToArray等方法，将会使其立即执行*

### 建议29：区别LINQ查询中的IEnumerable\<T>和IQueryable\<T>

​       本地数据源用IEnumerable\<T>，远程数据源用IQueryable\<T>

​        IEnumerable\<T>查询的逻辑可以直接用我们所定义的方法，而IQueryable\<T>则不能使用自定义的方法，它必须先生成表达式树，查询由LINQ to SQL引擎处理。

### 建议30：使用LINQ取代集合中的比较器和迭代器

```
List<Salary> companySalary = new List<Salary>()
                {
                    new Salary() { Name = "Mike", BaseSalary = 3000, Bonus = 1000 },
                    new Salary() { Name = "Rose", BaseSalary = 2000, Bonus = 4000 },
                    new Salary() { Name = "Jeffry", BaseSalary = 1000, Bonus = 6000 },
                    new Salary() { Name = "Steve", BaseSalary = 4000, Bonus = 3000 }
                };
            Console.WriteLine("默认排序：");
            foreach (Salary item in companySalary)
            {
                Console.WriteLine(string.Format("Name:{0} \tBaseSalary:{1} \tBonus:{2}", item.Name, item.BaseSalary, item.Bonus));
            }
            Console.WriteLine("BaseSalary排序：");
            var orderByBaseSalary = from s in companySalary orderby s.BaseSalary select s;
            foreach (Salary item in orderByBaseSalary)
            {
                Console.WriteLine(string.Format("Name:{0} \tBaseSalary:{1} \tBonus:{2}", item.Name, item.BaseSalary, item.Bonus));
            }
            Console.WriteLine("Bonus排序：");
            var orderByBonus = from s in companySalary orderby s.Bonus select s;
            foreach (Salary item in orderByBonus)
            {
                Console.WriteLine(string.Format("Name:{0} \tBaseSalary:{1} \tBonus:{2}", item.Name, item.BaseSalary, item.Bonus));
            }
```

*LINQ功能的实现本身就是借助于FCL泛型集合的比较器、迭代器、索引器的，LINQ相当于封装了这些功能，让我们使用起来更加方便*

### 建议31：在LINQ查询中避免不必要的迭代

```
 
 List<Person> list = new List<Person>()
            {
                new Person(){ Name = "Mike", Age = 20 },
                new Person(){ Name = "Mike", Age = 30 },
                new Person(){ Name = "Rose", Age = 25 },
                new Person(){ Name = "Steve", Age = 30 },
                new Person(){ Name = "Jessica", Age = 20 }
            };
 
 
 MyList list = new MyList();
            var temp = (from c in list where c.Age == 20 select c).ToList();
            Console.WriteLine(list.IteratedNum.ToString());
            list.IteratedNum = 0;
            var temp2 = (from c in list where c.Age >= 20 select c).First();
            Console.WriteLine(list.IteratedNum.ToString());
       
       代码输出为：
       5
       1
```

第二次查询仅仅迭代1次是因为20正好放在List的首位。First方法实际完成的工作是：搜索到满足条件的第一个元素，就从集合中返回。如果没有符合条件的元素，它也会遍历整个集合。

```
MyList list = new MyList();
            var temp = (from c in list select c).Take(2).ToList();
            Console.WriteLine(list.IteratedNum.ToString());
            list.IteratedNum = 0;
            var temp2 = (from c in list where c.Name == "Mike" select c).ToList();
            Console.WriteLine(list.IteratedNum.ToString());
            
          代码输出为：
          2
          5
```

Take方法接收一个整型参数，然后为我们返回该参数指定的元素个数。与First一样，满足条件后，会从当前的迭代过程中直接返回。

**使用First和Take方法，能给应用带来高效性，避免无效迭代**



## 第3章 泛型、委托和事件

### 建议32：总是优先考虑泛型

设计自己类型时，尽量让自己的类型成为泛型类

### 建议33：避免在泛型类型中声明静态成员

为T指定不同数据类型，MyList\<T>相应地也变成了不同地数据类型，在它们之间是不共享静态成员的。

* 非泛型类型中的泛型方法并不会在运行时的本地代码中生成不同的类型

### 建议34：为泛型参数设定约束

### 建议35：使用default为泛型类型变量指定初始值

* 值类型变量的默认初始值为0，引用类型变量的默认初始值为null

  ```
  public T Func<T>()
  {
      T t=default(T);
      return t;
  }
  ```

* 这样default以后，在运行时碰到的T是一个整型，那么运行时会为其赋值为0；碰到的是引用类型，则会为其赋值null。

### 建议36：使用FCL中的委托声明

FCL中存在三类委托声明：Action、Func、Predicate

Action表示接收0个或多个输入参数，执行一段代码，没有任何返回值

Func表示接受0个或多个输入参数，执行一段代码，带返回值

​       （Func<T>的用法：多个参数，前面的为委托方法的参数，最后一个参数，为委托方法的返回类型。）

Predicate表示定义一组条件并判断参数是否符合条件

```
class Program
    {
        delegate int AddHandler(int i, int j);
        delegate void PrintHandler(string msg);

        static void Main(string[] args)
        {
            //AddHandler add = Add;
            //PrintHandler print = Print;
            //print(add(1, 2).ToString());

            Func<int, int, int> add = Add;
            Action<string> print = Print;
            print(add(1, 2).ToString());

        }

        static int Add(int i, int j)
        {
            return i + j;
        }

        static void Print(string msg)
        {
            Console.WriteLine(msg);
        }

    }
```



### 建议37：使用Lambda表达式代替方法和匿名方法

```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip37
{
    class Program
    {
        static void Main(string[] args)
        {
            //第一种写法
            //Func<int, int, int> add = new Func<int, int, int>(Add);
            //Action<string> print = new Action<string>(Print);
            //print(add(1, 2).ToString());

            //Func<int, int, int> add = new Func<int, int, int>(delegate(int i, int j)
            //{
            //    return i + j;
            //});
            
            //第二种写法：匿名委托
            //Action<string> print = new Action<string>(delegate(string msg)
            //{
            //    Console.WriteLine(msg);
            //});
            //print(add(1, 2).ToString());   

            //Func<int, int, int> add = delegate(int i, int j)
            //{
            //    return i + j;
            //};
            //Action<string> print = delegate(string msg)
            //{
            //    Console.WriteLine(msg);
            //};
            //print(add(1, 2).ToString());
            
            //第三种写法：Lambda表达式 
            Func<int, int, int> add = (i, j) =>
            {
                return i + j;
            };
            Action<string> print = (msg) =>
            {
                Console.WriteLine(msg);
            };
            print(add(1, 2).ToString());

            //第一种写法
            //return this.Find(new Predicate<Student>(delegate(Student target)
            //{
            //    if (target.Name == name)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}));
            //第二种写法
            //return this.Find(new Predicate<Student>((target) =>
            //    {
            //        if (target.Name == name)
            //        {
            //            return true;
            //        }
            //        else
            //        {
            //            return false;
            //        }
            //    }));
            //第三种写法
            //return this.Find((target) =>
            //    {
            //        if (target.Name == name)
            //        {
            //            return true;
            //        }
            //        else
            //        {
            //            return false;
            //        }
            //    });
            //第四种写法
            //return this.Find( target => target.Name == name );

        }

        static int Add(int i, int j)
        {
            return i + j;
        }

        static void Print(string msg)
        {
            Console.WriteLine(msg);
        }

    }
}

```



**Lambda表达式操作符“=>”的左侧是方法的参数，右侧是方法体，本质是匿名方法。**



### 建议38：小心闭包中的陷阱

注意局部变量的添加

### 建议39：了解委托的本质

* 委托是方法指针

* 委托是一个类，当对其进行实例化的时候，要将引用方法作为它的构造方法的参数

###  建议40：使用event关键字为委托施加保护

### 建议41：实现标准的事件模型

### 建议42：使用泛型参数兼容泛型接口的不可变性

### 建议43：让接口中的泛型参数支持协变

```
interface ISalary<out T>
{
 void Pay();
}
```

### 建议44：理解委托中的协变

### 建议45：为泛型类型参数指定逆变

逆变是指方法的参数可以是委托或泛型接口的参数类型的基类

支持逆变的常用委托：

```
Func<in T,out TResult>
Predicate<in T>
```

常用泛型接口：

```
IComparer<in T>
```



  