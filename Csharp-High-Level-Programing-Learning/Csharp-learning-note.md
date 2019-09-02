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