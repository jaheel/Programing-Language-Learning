# Unity查找游戏对象

## 1 当前物体上找其他物体 GameObject.Find()

```c#
GameObject.Find("GameObject");
GameObject.Find("GameObject/ChildGameObject");
```

PS：

1. **无法查找隐藏对象**

   > 隐藏对象包括查找路径的任何一个父节点隐藏(active=false)

2. 有完全的路径使用路径查找

   > 减少查找范围，减少查找时间

3. 路径查找中的任何一个父节点active=false，这个对象将查不到



相当于递归遍历查询生效的Object，在Start()中查找对象并保存引用

避免在Update()中动态查找

## 2 当前物体上找自己的子物体 Transform.Find()

PS:

1. 可以查找隐藏对象

2. 查找子物体，查找孙或孙孙物体要用绝对路径

3. 支持路径查找

4. 查找隐藏对象的前提是transform所在的根节点必须可见（即acitve=true）

   ```c#
   GameObject root=GameObject.Find("root");
   root.SetActive(false);//根节点为空
   //总是查找失败
   root.transform.Find("root/AnyChildObjectName");
   ```

## 3 当前物体上找组件 GetComponent\<T>()

```c#
GetComponent<T>();//T为组件名称
GetComponents<T>();
```

## 4 GameObject.FindGameObjectsWithTag()

```c#
GameObject.FindGameObjectsWithTag();//通过Tag标签查找到一组物体，返回一个数组
GameObject.FindGameObjectWithTag();//查找到这类tag标签，自上而下第一个物体
```

## 5 FindObjectsOfType()

```c#
GameObject.FindObjectOfType();//按类型查找对象
GameObject.FindObjectsOfType();//按类型查找对象列表
```

