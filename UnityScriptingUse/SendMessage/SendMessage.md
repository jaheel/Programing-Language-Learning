# SendMessage()

```c#
SendMessage("函数名",参数,SendMessageOptions)//GameObject自身的Script
```

# BroadcastMessage()

```c#
BroadcastMessage("函数名",参数,SendMessageOptions)//自身和子Object的Script
```

# SendMessageUpwards()

```c#
SendMessageUpwards("函数名",参数,SendMessageOptions)//自身和父Object的Scripts
```

# SendMessageOptions参数值

```c#
SendMessageOptions.RequireReceiver//如果没有找到相应函数，会报错
SendMessageOptions.DontRequireReceiver//即使没有找到相应函数，也不会报错，自动忽略
```

