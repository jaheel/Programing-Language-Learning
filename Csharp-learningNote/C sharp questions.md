# C sharp Questions

## 1 Difference Between Array and ArrayList

### Array 

Belongs to System.Array namespace using System

1. Strongly-typed collections of the same data type and have a fixed length that cannot changed during runtime.
2. Can access the Array elements by numeric index.
3. The array indexes start at zero.
4. Default value of numeric array elements is set to zero.
5. The reference elements are set to null.

```c#
int [] array=new int [] {10,20,30,40};
```

### ArrayList

Belongs to System.Collection namespaces using System.Collections

1. Not a strongly-typed collection.
2. Can store the values of different data types or same datatype.
3. The size of an array list increases or decreases dynamically so it can take any size of values from any data type.
4. One of the most flexible data structures from C# Collections.



  **PS** 

1. ArrayList contains a simple list of values.
2. ArrayList implements the IList interface using an array.
3. Very easily we can add, insert, delete, view etc.
4. Very flexible because we can add without any size information that is it will grow dynamically and also shrink.

```c#
ArrayList Arrlst=new ArrayList();
Arrlst.Add("Sagar");
Arrlst.Add(1);
Arrlst.Add(null);
```



## 2 Basic Concepts About LINQ In C#

Basically we can write LINQ in two ways.

* Standard syntax which is like calling methods directly.
* Query expression syntax which is similar to SQL queries.

### 1 Example 

Let’s assume we have 100 numbers in an array and we want to get the result of only odd numbers, so we can use the above two syntaxes as follows,

* Using standard syntax

  ```C#
  var res=listOfNumbers.Where(n=> n%2 !=0);
  ```

* Using query expression syntax:

  ```c#
  var res = from n in listOfNumbers where n%2!=0 select n;
  ```



### 2 Query expression syntax keyword sequence

from -> [variable name] in [source]-> where -> groupby ->orderby-> select

## 3 LINQ Query expressions

#### 3.1 Where Operator

It accepts a *Func<TSource, bool>* type parameter, which is the filtering condition.

#### 3.2 ofType Operator

```C#
var objects = new Object[] { 8, 6L, 1.54, "Hello", 1, 3 };  
var result = objects.OfType<int>();  
foreach (var item in result) {  
    System.Console.WriteLine(item);  
}
```

#### 3.3 All Operator

It determines whether all the elements in a collection satisfy a condition. It accepts a *Func<TSource, bool>* type parameter as the condition. 

```C#
var res = StudentRecords.All(s => s.Age > 18);  
System.Console.WriteLine(res);
//The above code will check in StudentRecords, for those above age 18;  if it's yes then it returns true otherwise it returns false.
```

#### 3.4 Contains Operator

It determines whether a collection contains a specified element and it returns true or false.

```C#
string[] names = { “Alex”,”Priya”,"Suresh", "Binnu", "Rafnas", "Meenakshi" };  
var res = names.Contains(“Rafnas”);  
System.Console.WriteLine(res);//OutPut: True 
```

#### 3.5 Distinct Operator

It is used to keep unique elements of the collection and removes duplicate elements.

```C#
string[] names = { "Suresh", "Binnu", "Rafnas",”Binnu”, "Meenakshi",”Rafnas” };  
var distinctResult = names.Distinct();  
Console.WriteLine(string.Join(",", distinctResult));   
  
/OutPut: Suresh, Binnu, Rafnas, Meenakshi 
```

#### 3.6 Intersect Operator

t is used to return the set intersection; that means elements appear in both collections.

```C#
string[] set1 = { "Suresh", "Rafnas", ”Alex”, "Suresh", };  
    string[] set2 = { "Ahalya", "Rafnas", "Meenakshi", ” Alex” };  
  
 var intersectResult = set1.Intersect(set2);  
 Console.WriteLine(string.Join(",",intersectResult));   
  
//OutPut: Rafnas, Alex  
```

#### 3.7 Except Operator

It is used to return the set difference; that means elements of one collection that do not appear in a second collection.

```C#
string[] set1 = { "Suresh", "Rafnas", ”Alex”, "Suresh", };  
    string[] set2 = { "Ahalya", "Rafnas", "Meenakshi", ” Alex” };  
  
 var exceptResult = set1.Except(set2);  
 Console.WriteLine(string.Join(",",exceptResult));   
  
//OutPut: Suresh, Ahalya, Meenakshi  
```

#### 3.8 Union Operator

It is used to return the set union; that means unique elements that appear in either of two collections.

```C#
 string[] set1 = { "Suresh", "Rafnas", ”Alex”, "Suresh", };  
    string[] set2 = { "Ahalya", "Rafnas", "Meenakshi", ” Alex” };  
  
 var unionResult = set1.Union(set2);  
 Console.WriteLine(string.Join(",",unionResult));   
  
//OutPut: Suresh, Rafnas, Alex, Ahalya, Meenakshi  
```



#### 3.9 Concatenation Operator

It is used to return all elements from two collections with duplicate elements.

```C#
 string[] set1 = { "Suresh", "Rafnas", ”Alex”, "Suresh", };  
    string[] set2 = { "Ahalya", "Rafnas", "Meenakshi", ” Alex” };  
  
 var concatResult = set1.Concat(set2);  
 Console.WriteLine(string.Join(",",concatResult));   
  
//OutPut: Suresh, Rafnas, Alex, Suresh, Ahalya, Rafnas, Meenakshi, Alex  
```

#### 3.10 Sorting Operators

these operators are used to order the elements of a sequence based on one or more attributes.

1. OrderBy - it is used to order the elements in ascending order
2. OrderByDescending - it is used to order the elements in descending order
3. ThenBy - it is used to perform secondary sort in ascending order
4. ThenByDescending - it is used to perform secondary sort in descending order
5. Reverse - it is used to reverse the order of elements in a collection.



## 4 强引用和弱引用区别

强引用：维持着对象的可访问性，禁止垃圾回收器清除对象所占用的内存

弱引用：不禁止对对象进行垃圾回收，但会维持一个引用。如果对象尚未被垃圾回收器清除，就可以重用。

> 弱引用为创建起来代价较高（开销很大），而且维护开销特别大的对象设计。

如果认为对象（或对象集合）应该进行弱引用，就把它赋给System.WeakReference

