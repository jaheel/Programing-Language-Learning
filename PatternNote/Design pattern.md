# 设计原则

## 开闭原则

Open Closed Principle

当应用需求变更时，在不修改软件实体的源代码或者二进制代码的前提下，可以扩展模块的功能，使其满足新的要求。



实现方法：”抽象约束，封装变化“

> 通过接口或者抽象类为软件实体定义一个相对稳定的抽象层，而将相同的可变因素封装在相同的具体实现类中。



## 里氏替换原则

Liskov Substitution Principle

继承复用的基础，反映了基类与子类之间的关系，是对实现抽象化的具体步骤的规范。



子类可以扩展父类的功能，但不能改变父类原有的功能

## 依赖倒置原则

Dependence Inversion Principle

高层模块不应该依赖低层模块，两者都应该依赖其抽象；抽象不应该依赖细节，细节应该依赖抽象



实现方法：通过面向接口编程来降低类间的耦合性

1. 每个类尽量提供接口或者抽象类，或者两者都具备
2. 变量的声明类型尽量是接口或者抽象类
3. 任何类都不应该从具体类派生
4. 使用继承时尽量遵循里氏替换原则

## 单一职责原则

Single Responsibility Principle

一个类应该有且仅有一个引起它变化的原因，否则类应该被拆分

控制类的粒度大小、将对象解耦、提高其内聚性



实现方法：需要设计人员发现类的不同职责并将其分离，再封装到不同的类或模块中（需要较强分析设计能力、重构经验）

## 接口隔离原则

Interface Segregation Principle

为各个类建立它们需要的专用接口，而不试图建立一个很庞大的接口供所有依赖它的类去调用

## 迪米特法则

Law of Demeter

如果两个软件实体无须直接通信，那么就不应当发生直接的相互调用，可以通过第三方转发该调用。降低类之间的耦合度，提高模块的相对独立性。

## 合成复用原则

Composite Reuse Principle

在软件复用时，尽量使用组合或聚合等关联关系实现，其次才考虑使用继承关系实现