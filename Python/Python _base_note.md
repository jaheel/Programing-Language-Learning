

# Python_base_note

## 1 内置函数

### 1.1 Python自带

| 内置函数      |             |              |              |                |
| ------------- | ----------- | ------------ | ------------ | -------------- |
| abs()         | delattr()   | hash()       | memoryview() | set()          |
| all()         | dict()      | help()       | min()        | setattr()      |
| any()         | dir()       | hex()        | next()       | slicea()       |
| ascii()       | divmod()    | id()         | object()     | sorted()       |
| bin()         | enumerate() | input()      | oct()        | staticmethod() |
| bool()        | eval()      | int()        | open()       | str()          |
| breakpoint()  | exec()      | isinstance() | ord()        | sum()          |
| bytearray()   | filter()    | issubclass() | pow()        | super()        |
| bytes()       | float()     | iter()       | print()      | tuple()        |
| callable()    | format()    | len()        | property()   | type()         |
| chr()         | frozenset() | list()       | range()      | vars()         |
| classmethod() | getattr()   | locals()     | repr()       | zip()          |
| compile()     | globals()   | map()        | reversed()   | \__import__()  |
| complex()     | hasattr()   | max()        | round()      |                |

### 1.2 序列相关

| 函数        | 功能                                                         |
| ----------- | ------------------------------------------------------------ |
| len()       | 计算序列的长度，即返回序列中包含多少个元素。                 |
| max()       | 找出序列中的最大元素。注意，对序列使用 sum() 函数时，做加和操作的必须都是数字，不能是字符或字符串，否则该函数将抛出异常，因为解释器无法判定是要做连接操作（+ 运算符可以连接两个序列），还是做加和操作。 |
| min()       | 找出序列中的最小元素。                                       |
| list()      | 将序列转换为列表。                                           |
| str()       | 将序列转换为字符串。                                         |
| sum()       | 计算元素和。                                                 |
| sorted()    | 对元素进行排序。                                             |
| reversed()  | 反向序列中的元素。                                           |
| enumerate() | 将序列组合为一个索引序列，多用在 for 循环中。                |

## 2 结构体

### 2.1 列表(list)

```python
#初始化
listname = [element1 , element2 , element3 , ... , elementn]


num = [1, 2, 3, 4, 5, 6, 7]
name = ["C语言中文网", "http://c.biancheng.net"]
program = ["C语言", "Python", "Java"]

#访问列表元素
listname[i]
listname[start:end:step]#listname 表示列表名字，start 表示起始索引，end 表示结束索引，step 表示步长。

#删除列表元素
del listname

#添加列表元素
listname.append(obj)
listname.extend(obj)#不会把列表或者元组视为一个整体，而是逐个加入
listname.insert(index,obj)

#删除列表元素
del listname[index]
del listname[start:end]
listname.pop(index)#删除指定位置
listname.pop()#删除最后一个
listname.remove()
listname.clear()#删除列表所有元素

#查找元素
listname.index(obj,start,end)#查找元素所在位置
listname.count(obj)#统计某个元素在列表中出现的次数
```

### 2.2元组(tuple)

元组一旦被创建，它的元素就不可更改了，所以元组是不可变序列

```python
#创建元组
tuplename = (element1, element2, ..., elementn)

#使用tuple()函数创建元组
tuple(data)
```

### 2.3 字典(dict)

无序的、可变的序列

Key-value形式存储

形似散列表

```python
#创建字典
dictname = {'key':'value1', 'key2':'value2', ..., 'keyn':valuen}

dictname = dict.fromkeys(list，value=None)
#例子
knowledge = {'语文', '数学', '英语'}
scores = dict.fromkeys(knowledge, 60)
print(scores)
#输出：{'语文': 60, '英语': 60, '数学': 60}

#访问字典
dictname[key]
dictname.get(key[,default])

#添加键值对
dictname[key]=value

#删除字典
del dictname
del dictname[key]

#方法
dictname.keys()#返回字典中的所有键(key)
dictname.values()#返回字典中所有键对应的值(value)
dictname.items()#返回字典中所有的键值对(key-value)

dictname.copy()#返回一个字典的拷贝，即一个具有相同键值对的新字典
dictname.update()#使用一个字典所包含的键值对来更新已有的字典

dictname.pop(key)#删除指定键值对
dictname.popitem()#删除最后一个

dictname.setdefault(key,defaultvalue)#key存在，返回value;反之，返回defaultvalue

```

### 2.4 集合(set)

格式：

```python 
{element1,element2,...,elementn}
```

PS:

* 数据必须保证唯一，集合对于每种数据元素，只会保留一份

```python
#test
>>> {1,2,1,(1,2,3),'c','c'}
{1, 2, 'c', (1, 2, 3)}
```

基本操作

```python
#创建
setname={element1,element2,...,elementn}
setname=set(iteration)#字符串、列表、元组、range对象等数据

#访问元素
a = {1,'c',1,(1,2,3),'c'}
for ele in a:
    print(ele,end=' ')

   
#添加元素
setname.add(element)

#删除元素
setname.remove(element)

```


交集、并集、差集运算

| 运算操作 | Python运算符 | 含义                              | 例子                                        |
| -------- | ------------ | --------------------------------- | ------------------------------------------- |
| 交集     | &            | 取两集合公共的元素                | >>> set1 & set2 {3}                         |
| 并集     | \|           | 取两集合全部的元素                | >>> set1 \| set2 {1,2,3,4,5}                |
| 差集     | -            | 取一个集合中另一集合没有的元素    | >>> set1 - set2 {1,2} >>> set2 - set1 {4,5} |
| 对称差集 | ^            | 取集合 A 和 B 中不属于 A&B 的元素 | >>> set1 ^ set2 {1,2,4,5}                   |



set方法汇总：

| 方法名                        | 语法格式                               | 功能                                                         | 实例                                                         |
| ----------------------------- | -------------------------------------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| add()                         | set1.add()                             | 向 set1 集合中添加数字、字符串、元组或者布尔类型             | >>> set1 = {1,2,3} >>> set1.add((1,2)) >>> set1 {(1, 2), 1, 2, 3} |
| clear()                       | set1.clear()                           | 清空 set1 集合中所有元素                                     | >>> set1 = {1,2,3} >>> set1.clear() >>> set1 set()  set()才表示空集合，{}表示的是空字典 |
| copy()                        | set2 = set1.copy()                     | 拷贝 set1 集合给 set2                                        | >>> set1 = {1,2,3} >>> set2 = set1.copy() >>> set1.add(4) >>> set1 {1, 2, 3, 4} >>> set1 {1, 2, 3} |
| difference()                  | set3 = set1.difference(set2)           | 将 set1 中有而 set2 没有的元素给 set3                        | >>> set1 = {1,2,3} >>> set2 = {3,4} >>> set3 = set1.difference(set2) >>> set3 {1, 2} |
| difference_update()           | set1.difference_update(set2)           | 从 set1 中删除与 set2 相同的元素                             | >>> set1 = {1,2,3} >>> set2 = {3,4} >>> set1.difference_update(set2) >>> set1 {1, 2} |
| discard()                     | set1.discard(elem)                     | 删除 set1 中的 elem 元素                                     | >>> set1 = {1,2,3} >>> set1.discard(2) >>> set1 {1, 3} >>> set1.discard(4) {1, 3} |
| intersection()                | set3 = set1.intersection(set2)         | 取 set1 和 set2 的交集给 set3                                | >>> set1 = {1,2,3} >>> set2 = {3,4} >>> set3 = set1.intersection(set2) >>> set3 {3} |
| intersection_update()         | set1.intersection_update(set2)         | 取 set1和 set2 的交集，并更新给 set1                         | >>> set1 = {1,2,3} >>> set2 = {3,4} >>> set1.intersection_update(set2) >>> set1 {3} |
| isdisjoint()                  | set1.isdisjoint(set2)                  | 判断 set1 和 set2 是否没有交集，有交集返回 False；没有交集返回 True | >>> set1 = {1,2,3} >>> set2 = {3,4} >>> set1.isdisjoint(set2) False |
| issubset()                    | set1.issubset(set2)                    | 判断 set1 是否是 set2 的子集                                 | >>> set1 = {1,2,3} >>> set2 = {1,2} >>> set1.issubset(set2) False |
| issuperset()                  | set1.issuperset(set2)                  | 判断 set2 是否是 set1 的子集                                 | >>> set1 = {1,2,3} >>> set2 = {1,2} >>> set1.issuperset(set2) True |
| pop()                         | a = set1.pop()                         | 取 set1 中一个元素，并赋值给 a                               | >>> set1 = {1,2,3} >>> a = set1.pop() >>> set1 {2,3} >>> a 1 |
| remove()                      | set1.remove(elem)                      | 移除 set1 中的 elem 元素                                     | >>> set1 = {1,2,3} >>> set1.remove(2) >>> set1 {1, 3} >>> set1.remove(4) Traceback (most recent call last):   File "<pyshell#90>", line 1, in <module>     set1.remove(4) KeyError: 4 |
| symmetric_difference()        | set3 = set1.symmetric_difference(set2) | 取 set1 和 set2 中互不相同的元素，给 set3                    | >>> set1 = {1,2,3} >>> set2 = {3,4} >>> set3 = set1.symmetric_difference(set2) >>> set3 {1, 2, 4} |
| symmetric_difference_update() | set1.symmetric_difference_update(set2) | 取 set1 和 set2 中互不相同的元素，并更新给 set1              | >>> set1 = {1,2,3} >>> set2 = {3,4} >>> set1.symmetric_difference_update(set2) >>> set1 {1, 2, 4} |
| union()                       | set3 = set1.union(set2)                | 取 set1 和 set2 的并集，赋给 set3                            | >>> set1 = {1,2,3} >>> set2 = {3,4} >>> set3=set1.union(set2) >>> set3 {1, 2, 3, 4} |
| update()                      | set1.update(elem)                      | 添加列表或集合中的元素到 set1                                | >>> set1 = {1,2,3} >>> set1.update([3,4]) >>> set1 {1,2,3,4} |

## 3 字符串

### 3.1 str()和repr()

str()和repr()函数

共同点：

* 可将数字转换成字符串

不同点：

* str()用于将数据转换成适合人类阅读的字符串形式
* repr()用于将数据转换成适合解释器阅读的字符串形式（适合开发和调试阶段使用）

### 3.2 len()

获取字符串长度或字节数

```python
len(string)
len(str1.encode('gbk'))#获取特定编码字符串长度
```

### 3.3 split()

将一个字符串按照指定的分隔符切分成多个字串，这些字串会被保存到列表中，作为方法的返回值反馈回来。

```python
str.split(sep,maxsplit)
#sep:指定分隔符
#maxsplit:分割子串个数
```

### 3.4 join()

split()方法的逆方法，用来将列表（或元组）中包含的多个字符串连接成一个字符串。

```python
newstr= str.join(iterable)
#newstr:表示合并后生成的新字符串
#str:用于指定合并时的分隔符
#iterable:做合并操作的源字符串数据，允许以列表、元组等形式提供
```

### 3.5 count()

统计字符串出现的次数

```python
str.count(sub[,start[,end]])
```

### 3.6 find()

检查字符串中是否包含某子串，如果包含，则返回第一次出现该字符串的索引；反之，则返回-1

```python
str.find(sub[,start[,end]])#从左边开始搜索
str.rfind()#从字符串右边开始检索
```

### 3.7 index()

检查字符串中是否包含指定的字符串，当指定的字符串不存在时，index()方法会抛出异常

```python
str.index(sub[,start[,end]])
#str:原字符串
#sub:检索的子字符串
#start:默认从头开始检索
#end:表示检索的结束位置，如果不指定，默认一直检索到结尾
```

### 3.8 字符串对齐

#### 3.8.1 ljust()

向指定字符串的右侧填充指定字符，从而达到左对齐

```python
S.ljust(width[,fillchar])
```

#### 3.8.2 rjust()

向字符串的左侧填充指定字符，从而达到右对齐文本

```python
S.rjust(width[,fillchar])
```

#### 3.8.3 center()

文本居中

```python
S.center(width[,fillchar])
```



### 3.9 starswith()和endswith()

* startswith()

  > 用于检索字符串是否以指定字符串开头，是就返回True；反之返回False

  ```python
  str.startswith(sub[,start[,end]])
  ```

* endswith()

  > 用于检索字符串是否以指定字符串结尾

  ```python
  str.endswith(sub[,start[,end]])
  ```

  

### 3.10 大小写转换

以下三个方法仅限于将转换后的新字符串返回，不会修改原字符串

#### 3.10.1 title()

将字符串中每个单词的首字母转为大写，其余字母全部转为小写

```python
str.title()
```

#### 3.10.2 lower()

用于将字符串中的所有大写字母转换为小写字母

```python
str.lower()
```

#### 3.10.3 upper()

用于将字符串中的所有小写字母转换为大写字母

```python
str.upper()
```

### 3.11 去除指定字符

#### 3.11.1 strip()

删除字符串前后（左右两侧）的空格或特殊字符

```python
str.strip([chars])
```



#### 3.11.2 lstrip()

去掉字符串前面的空格或特殊字符

```python
str.lstrip([chars])
```

#### 3.11.3 rstrip()

去掉字符串后面的空格或特殊字符

```python
str.rstrip([chars])
```

### 3.12 encode()和decode()

* encode()

  > 用于将str类型转换成bytes类型，这个过程叫做"编码"

  ```python
  str.encode([encoding="utf-8"][,errors="strict"])
  ```

* decode()

  > 将bytes类型的二进制数据转换为str类型，这个过程叫做"解码"

  ```python
  bytes.decode([encoding="utf-8"][,errors="strict"])
  ```

### 3.13 dir()和help()

dir()

> 用来列出某个类或者某个模块中的全部内容，包括变量、方法、函数和类等

```python
dir(obj)
```





help()

> 用来查看某个函数或者模块的帮助文档

```python
help(obj)
```



## 4 并行编程

### 4.1 创建线程

```python
import threading
#定义线程要调用的方法，*add可接收多个以非关键字方式传入的参数
def action(*add):
    for arc in add:
        #调用 getName() 方法获取当前执行该程序的线程名
        print(threading.current_thread().getName() +" "+ arc)
#定义为线程方法传入的参数
my_tuple = ("http://c.biancheng.net/python/",\
            "http://c.biancheng.net/shell/",\
            "http://c.biancheng.net/java/")
#创建线程
thread = threading.Thread(target = action,args =my_tuple)
```

