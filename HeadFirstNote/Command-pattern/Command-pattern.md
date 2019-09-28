# Command Pattern

**封装调用**

把方法调用（method invocation）封装起来

命令模式可将“动作的请求者”从“动作的执行者”对象中解耦。

## 1 第一个命令对象

遥控器的代码

### 1.1 实现命令接口

```java
//简单！只需要一个方法：execute()
public interface Command{
    public void execute();
}
```

### 1.2 实现一个打开电灯的命令

```java
public class LightOnCommand implements Command{
    Light light;
    public LightOnCommand(Light light)
    {
        this.light=light;
    }
    public void execute()
    {
        light.on();
    }
}
```

### 1.3 使用命令对象

假设我们有一个遥控器，它只有一个按钮和对应的插槽，可以控制一个装置：

```java
public class SimpleRemoteControl{
    Command slot;
    public SimpleRemoteControl(){}
    
    //用来设置插槽控制的命令。如果这段代码的客户想要改变遥控器按钮的行为，可以多次调用这个方法
    public void setCommand(Command command){
        slot=command;
    }
    //当按下按钮时，这个方法就会被调用，使得当前命令衔接插槽，并调用它的execute()方法
    public void buttonWasPressed()
    {
        slot.execute();
    }
}
```

### 1.4 遥控器使用的简单测试

```java
//命令模式的客户
public class RemoteControlTest{
    public static void main(String[] args)
    {
        //遥控器就是调用者，会传入一个命令对象，可以用来发出请求
        SimpleRemoteControl remote=new SimpleRemoteControl();
        //电灯对象，请求的接收者
        Light light=new Light();
        //创建一个命令，然后将接受者传给它
        LightOnCommand lighton=new LightOnCommand(light);
        //命令传给调用者
        remote.setCommand(lighton);
        //模拟按下按钮
        remote.buttonWasPressed();
    }
}
```

## 2 定义命令模式

将“请求”封装成对象，以便使用不同的请求、队列或者日志来参数化其他对象。命令模式也支持可撤销的操作。

## 3 实现遥控器

```java
public class RemoteControl{
    Command[] onCommands;
    Command[] offCommands;
    
    public RemoteControl(){
        onCommands[]=new Command[7];
        offCommands[]=new Command[7];
        
        Command noCommand=new NoCommand();
        for(int i=0;i<7;i++)
        {
            onCommands[i]=noCommand;
            offCommands[i]=noCommand;
        }
    }
    //3个参数：插槽位置、开的命令、关的命令
    public void setCommand(int slot, Command onCommand,Command offCommand)
    {
        onCommands[slot]=onCommand;
        offCommands[slot]=offCommand;
    }
    
    public void onButtonWasPushed(int slot)
    {
        onCommands[slot].execute();
    }
    
    public void offButtonWasPushed(int slot)
    {
        offCommands[slot].execute();
    }
    
    public String toString()
    {
        StringBuffer stringBuff=new StringBuffer();
        stringBuff.append("\n------- Remote Control ------\n");
        for(int i=0;i<onCommands.length;i++)
        {
            stringBuff.append("[slot "+i+"] "+onCommands[i].getClass().getName()+"  "+offCommands[i].getClass().getName()+"\n");
        }
        return stringBuff.toString();
    }
}
```



## 4 实现命令

音响(Stereo)：

```java
public class StereoOnWithCDCommand implements Commend{
    Stereo stereo;
    public SteroOnWithCDCommand(Stereo stereo)
    {
        this.stereo=stereo;
    }
    public void execute(){
        stereo.on();
        stereo.setCD();
        stereo.setVolume(11);
    }
}
```

实现NoCommand:

```java
public class NoCommand implements Command{
    public void execute(){}
}
```

