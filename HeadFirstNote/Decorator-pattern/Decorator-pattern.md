##  装饰者模式

**“给爱用继承的人一个全新的设计眼界”**

1. 开放-关闭原则

   > 类应该对扩展开放，对修改关闭
   >
   > 开放：能用想要的行为来扩展类
   >
   > 关闭：防止代码被修改
   >
   > 
   >
   > 目标：允许类容易扩展，在不修改现有代码的情况下，就可搭配新的行为



例子：

### 1 认识装饰者模式

以饮料为主体，然后在运行时以调料来“装饰”（decorate）饮料。比方说，如果顾客想要摩卡和奶泡深焙咖啡，那么，要做的是：

1. 拿一个深焙咖啡（DarkRoast）对象
2. 以摩卡（Mocha）对象装饰它
3. 以奶泡（Whip）对象装饰它
4. 调用cost()方法，并依赖委托(delegate)将调料的价钱加上去

### 2 以装饰者构造饮料订单

1. 以DarkRoast对象开始

   > DarkRoast继承自Beverage，且有一个用来计算饮料价钱的cost()

2. 顾客想要摩卡(Mocha)，所以建立一个Mocha对象，并用它将DarkRoast对象包（wrap）起来。

   > Mocha对象是一个装饰者
   >
   > Mocha也有一个cost()方法。通过多态，也可以把Mocha所包裹的任何Beverage当成是Beverage（因为Mocha是Beverage的子类型）。

3. 顾客也想要奶泡（Whip），所以需要建立一个Whip装饰者，并用它将Mocha对象包起来。别忘了，DarkRoast继承自Beverage，且有一个cost()方法，用来计算饮料价钱。

   > Whip是一个装饰者，它反映了DarkRoast类型，并包括一个cost()方法
   >
   > 被Mocha和Whip包起来的DarkRoast对象仍然是一个Beverage，仍然可以具有DarkRoast的一切行为，包括调用它的cost()方法

4. 现在，该是为顾客算钱的时候了。通过调用最外圈装饰者（Whip)的cost()就可以办得到。Whip的cost()会先委托它装饰的对象（也就是Mocha)计算出价钱，然后再加上奶泡的价钱。



理解点：

* 装饰者和被装饰对象有相同的超类型
* 可以用一个或多个装饰者包装一个对象
* 既然装饰者和被装饰对象有相同的超类型，所以在任何需要原始对象（被包装的）的场合，可以用装饰过的对象代替它。
* **装饰者可以在所委托被装饰者的行为之前与/或之后，加上自己的行为，以达到特定的目的。**

* 对象可以在任何时候被装饰，所以可以在运行时动态地、不限量地用你喜欢的装饰者来装饰对象。

通常装饰者模式是采用抽象类（在Java中可以使用接口）

### 3 代码实现

#### 3.1 抽象类代码

Beverage类：

```java
//Beverage是一个抽象类，有两个方法：setDescription()及cost()
public abstract class Beverage{
    String description="Unknown Beverage";
    public String getDescription()
    {
        return description;
    }
    
    public abstract double cost();
}



```

实现Condiment（调料）抽象类（装饰者类）：

```java
//首先，必须让CondimentDecorator能够取代Beverage，所以将CondimentDecorator扩展自Beverage类。

public abstract class CondimentDecorator extends Beverage{
    public abstract String getDescription();
}
```

#### 3.2 饮料代码

有了基类，实现饮料，并且为具体饮料设置描述，而且还必须实现cost()方法。

浓缩咖啡(Espresso)：

首先，让Espresso扩展自Beverage类，因为Espresso是一种饮料

```java
public class Espresso extends Beverage{
    public Espresso()
    {
        description="Espresso";
    }
    public double cost()
    {
        return 1.99;
    }
}
```



```java
public class HouseBlend extends Beverage{
    public HouseBlend()
    {
        description="House Blend Coffee";
    }
    public double cost()
    {
        return 0.89;
    }
}

public class DarkRoast extends Beverage{
    public DarkRoast(){
        description="Dark Roast";
    }
    public double cost()
    {
        return 0.99;
    }
}

public class Decat extends Beverage{
    public Decat(){
        description="Decat";
    }
    public double cost(){
        return 1.05;
    }
}
```

#### 3.3 调料代码

已经完成了抽象组件（Beverage），有了具体组件（HouseBlend），也有了抽象装饰者（CondimentDecorator）。现在实现具体装饰者。

摩卡（Mocha）：

```java
public class Mocha extends CondimentDecorator{
    Beverage beverage;
    public Mocha(Beverage beverage)
    {
        this.beverage=beverage;
    }
    
    public String getDescription()
    {
        return beverage.getDescription()+",Mocha";
    }
    
    public double cost()
    {
        return 0.20+beverage.cost();
    }
}
```



#### 3.4 供应咖啡（测试代码）

```java
public class StarbuzzCoffee{
    public static void main(String args[])
    {
        //定一杯Espresso，不需要调料，打印出它的描述和价钱
        Beverage beverage=new Espresso();
        System.out.println(beverage.getDescription()+" $"+beverage.cost());
        
        //制造一个DarkRoast对象
        Beverage beverage2=new DarkRoast();
        beverage2=new Mocha(beverage2);//用Mocha装饰它
        beverage2=new Mocha(beverage2);//用第二个Mocha装饰它
        beverage2=new Whip(beverage2);//用Whip装饰它
        System.out.println(beverage2.getDescription()+" $"+beverage2.cost());
        
        //最后，再来一杯调料为豆浆、摩卡、奶泡的HouseBlend咖啡
        Beverage beverage3=new HouseBlend();
        beverage3=new Soy(beverage3);
        beverage3=new Mocha(beverage3);
        beverage3=new Whip(beverage3);
        System.out.println(beverage3.getDescription()+" $"+beverage3.cost());        
    }
}
```