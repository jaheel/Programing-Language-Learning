# 封装算法

将茶和咖啡的共同方法进行封装

![TemplateExample](G:\github\Programing-Language-Learning\HeadFirstNote\Template-method-pattern\TemplateExample.png)



步骤实现：

1. 首先，一个茶对象

   Tea myTea = new Tea();

2. 调用模板方法

   myTea.prepareRecipe();

3. 把水煮沸（在咖啡因饮料类（超类）中实现）

   boilWater();

4. 泡茶，子类实现

   brew();

5. 茶倒进茶杯（超类中）

   pourInCup();

6. 加调料

   addCondiments();

## 模板方法模式

在一个方法中定义一个算法的骨架，而将一些步骤延迟到子类中。模板方法使得子类可以在不改变算法结构的情况下，重新定义算法中的某些步骤。

## 注意

1. 为了防止子类改变模板方法中的算法，可以将模板方法声明为final
2. 抽象方法由子类实现
3. 模板方法模式：代码复用
4. 好莱坞原则告诉我们：将决策权放在高层模块中，以便决定如何以及何时调用底层模块
5. 工厂方法是模式方法的一种特殊版本

## 模板方法、策略、工厂方法区别

模板方法：子类决定如何实现算法中的某些步骤

策略：封装可互换的行为，然后使用委托来决定要采用哪一个行为

工厂方法：由子类决定实例化哪个具体类

