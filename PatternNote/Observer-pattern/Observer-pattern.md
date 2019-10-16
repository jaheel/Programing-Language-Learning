## 观察者模式

让你的对象知悉现状（**出版者+订阅者**）

### 1 气象监测应用的概况

系统分三个部分：气象站（获取实际气象数据的物理装置）、WeatherData对象（追踪来自气象站的数据，并更新布告板）和布告板（显示目前天气状况给用户看）

我们的工作是建立一个应用，利用WeatherData对象取得数据，并更新三个布告板：目前状况、气象统计和天气预报。

#### 1.1 WeatherData类

含有方法：

getTemperature()

getHumidity()

getPressure()

measurementsChanged()

//其他方法

```java

/*
*一旦气象测量更新，此方法会被调用
*/
public void measurementsChanged()
{
    //你的代码加在这里
}
```

我们的工作是实现measurementsChanged()，好让它更新目前状况、气象统计、天气预报的显示布告板。

### 2 认识观察者模式

1. 报社的业务就是出版报纸

2. 向某家报社订阅报纸，只要他们有新报纸出版，就会给你送来，只要你是他们的订户，你就会一直收到新报纸。

3. 当你不想再看报纸的时候，取消订阅，他们就不会再送新报纸来

4. 只要报社还在运营，就会一直有人（或单位）向他们订阅报纸或取消订阅报纸

### 3 出版者+订阅者=观察者模式

出版者（Subject)，订阅者（Observer）

### 4 定义观察者模式

定义了对象之间的一对多依赖，这样一来，当一个对象改变状态时，它的所有依赖者都会收到通知并自动更新。

> 观察者模式定义了一系列对象之间的一对多关系。
>
> 当一个对象改变状态，其他依赖者都会收到通知。

**观察者模式提供了一种对象设计，让主题和观察者之间松耦合。**

**设计原则：为了交互对象之间的松耦合设计而努力**

### 5 实现气象站代码

#### 5.1 建立接口

```java
public interface Subject{
    //这两个方法用来注册和删除观察者
    public void registerObserver(Observer o);
    public void removeObserver(Observer o);
    //当主题状态改变时，这个方法会被调用，以通知所有的观察者
    public void notifyObservers();
}

public interface Observer{
    //当气象观测值发生改变时，主题会把这些状态值当作方法的参数，传递给观察者
    public void update(float temp,float humidity,float pressure);
}

//DisplayElement接口只包含了一个方法，也就是display()。当布告板需要显示时，调用此方法
public interface DisplayElement{
    public void display();
}
```

#### 5.2 在WeatherData中实现主题接口

```java
public class WeatherData implements Subject{
    private ArrayList observers;
    private float temperature;
    private float humidity;
    private float pressure;
    
    public WeatherData()
    {
        observers=new ArrayList();
    }
    
    public void registerObserver(Observer o)
    {
        observers.add(o);
    }
    public void removeObserver(Observer o)
    {
        int i=observers.indexOf(o);
        if(i>=0)
        {
            observers.remove(i);
        }
    }
    
    public void notifyObservers()
    {
        for(int i=0;i<observers.size();i++)
        {
            Observer observer=(Observer)observers.get(i);
            observer.update(temperature,humidity,pressure);
        }
    }
    //当从气象站得到更新观测值时，我们通知观察者
    public void measurementsChanged()
    {
        notifyObservers();
    }
    
    public void setMeasurements(float temperature, float humidity, float pressure)
    {
        this.temperature=temperature;
        this.humidity=humidity;
        this.pressure=pressure;
        measurementsChanged();
    }
    // WeatherData的其他方法
}
```

#### 5.3 建立布告板

Weather-O-Rama气象站订购了三个布告板：目前状况布告板、统计布告板和预测布告板。

目前状况布告板代码如下：

```java
public class CurrentConditionsDisplay implements Observer,DisplayElement{
    private float temperature;
    private float humidity;
    private Subject weatherData;
    
    public CurrentConditionsDisplay(Subject weatherData)
    {
        this.weatherData=weatherData;
        weatherData.registerObserver(this);
    }
    
    public void update(float temperature,float humidity,float pressure)
    {
        this.temperature=temperature;
        this.humidity=humidity;
        display();
    }
    
    public void display()
    {
        System.out.println("Current conditions: "+temperature+"F degrees and "+humidity+"% humidity");
    }
}
```

#### 5.4 启动气象站（测试代码）

```java
public class WeatherStation{
    public static void main(String[] args)
    {
        WeatherData weatherData=new WeatherData();
        
        CurrentConditionsDisplay currentDisplay=new CurrentConditionsDisplay(weatherData);
       //这两个布告板构造和上面一个类似
        StatisticsDisplay statisticsDisplay=new StatisticsDisplay(weatherData);
        ForecastDisplay forecastDisplay=new ForecastDisplay(weatherData);
        
        //模拟新的气象测量
        weatherData.setMeasurements(80,65,30.4f);
        weatherData.setMeasurements(82,70,29.2f);
        weatherData.setMeasurements(78,90,29.2f);
    }
}
```