# Input System

Unity2020版本出正式版

目前版本：1.0.0 preview



1. 基于Action
2. 输入设备、动作逻辑分离（配置映射处理信息）
3. UnityEngine.InputSystem



## 1 简要介绍

### 1.1 Class InputAction

响应动作逻辑，可以绑定多个物理输入

> 绑定的物理输入和得到的输入值影响同一个InputAction对象

该类只代表一种动作“逻辑”，不代表任何物理输入



每个动作逻辑每一时刻都有当前的状态阶段(Phase)

> Enum InputActionPhase
>
> > * Canceled
> > * Disabled
> > * Performed
> > * Started
> > * Waiting
>
> Started、Performed、Canceled阶段分别触发三个对应的C#事件(eventAction<InputAction.CallbackContext>)



每次动作逻辑被触发时，可通过ReadValue<TValue>()成员来获得本次触发的具体值

### 1.2 InputBindings

动作逻辑和输入设备之间的绑定关系。

每个Binding

> 1. 源输入设备(Path)
> 2. 绑定的动作逻辑(InputAction)
>
> PS：可以有输入条件限制(Interactions)限制设备的触发条件，后处理器(Processors)来进行输入源数据的后处理
>
> 绑定的合成类型(Composite Type)
>
> 1. 1D Axis 单轴输入
> 2. 2D Vector 双轴向量输入
> 3. Button 按钮输入
> 4. Button with modifier 带有条件的按钮输入
> 5. Custom composite 自定义输入数据类型

### 1.3 Asset InputActionAssets

存储动作绑定关系的资源文件

扩展名：.InputActions

数据格式：Json



Action Maps: 不同的映射列表

Actions: 

1. InputActions（绿色标签）
2. 每个InputAction可有多个InputBindings（蓝色标签）
3. 每个InputBinding类型可以有多个合成分量(Composite Bindings)（粉色标签）



可以生成指定格式的C#类，可以通过操作该类来进行相同的操作。可以根据喜好选择生成与否



### 1.4 Class PlayerInput

Actions：使用的Input Action Assets资源文件

​		Default Map：使用资源文件中的某个映射列表

UI Input Module：通过指定一个InputSystemUIInputModule对象来与UI协作

Camera：分屏游戏时指定该Player Input对应的摄像机对象

Behavior：表示当有动作逻辑触发时的相应方式

> 1. Send Messages
>
> 2. Broadcast Messages
>
> 3. Unity Events
>
> 4. CSharp Events
>
> 前两种方式：在游戏对象内实现命名为对应的On{ActionName}()函数即可接收对应触发效果
>
> Unity Events方式：需在Inspector中分配各种函数，虽然可视化，但函数和动作逻辑较多时比较麻烦
>
> C# Events方式：快、效率高，唯一的不足是所有自定义触发都共享同一个事件event Action<InputAction.CallbackContext>
>
> onActionTriggerd：需要在订阅事件之后自行比较触发的动作逻辑是否是该订阅者需要的

