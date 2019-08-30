# Time时间体系

![1330649-20180319051453639-1984876622](C:\Users\徐钒鑫\Desktop\工作\Unity学习\Time学习\1330649-20180319051453639-1984876622.jpg)

图中红色为只读值，绿色为可读可写

- - - Time.time 表示从游戏开发到现在的时间，会随着游戏的暂停而停止计算。

    - Time.timeSinceLevelLoad 表示从当前Scene开始到目前为止的时间，也会随着暂停操作而停止。

    - **Time.deltaTime** 表示从上一帧到当前帧时间，以秒为单位。又称增量时间

    - Time.fixedTime 表示以秒计游戏开始的时间，固定时间以定期间隔更新（相当于fixedDeltaTime）直到达到time属性。

    - Time.fixedDeltaTime 表示以秒计间隔，在物理和其他固定帧率进行更新，在Edit->ProjectSettings->Time的Fixed Timestep可以自行设置。

    - Time.SmoothDeltaTime 表示一个平稳的deltaTime，根据前 
      N帧的时间加权平均的值。

    - Time.timeScale 时间缩放，默认值为1，若设置<1，表示时间减慢，若设置>1,表示时间加快，可以用来加速和减速游戏，非常有用。

    - Time.frameCount 总帧数

    - Time.realtimeSinceStartup 表示自游戏开始后的总时间，即使暂停也会不断的增加。

    - Time.captureFramerate 表示设置每秒的帧率，然后不考虑真实时间。

    - Time.unscaledDeltaTime 不考虑timescale时候与deltaTime相同，若timescale被设置，则无效。

    - Time.unscaledTime 不考虑timescale时候与time相同，若timescale被设置，则无效。

      

      

      1、 UnityEngine.Time.captureFramerate： 
      一旦设置了这个值(非0)，每一帧会以1.0f/captureFramerate的时间更新（相对于Time.time，每一帧执行的真实时间还是不变的,其实这里再乘以Time.timeScale更合适），说白了就是改变每一帧所用的时间。这个属性并不改变Time.timeScale和Application.targetFrameRate

      2、UnityEngine.Time.deltaTime： 
      时间增量，依据Time.time，在Update里调用返回的是完成上一帧的时间，在FixedUpdate里调用返回的是FixedTimeStep的值。

      3、UnityEngine.Time.fixedDeltaTime ： 
      固定增量时间，返回FixedTimeStep。FixedUpdate执行的时间间隔和物理检测的时间间隔。 
      注意一下，这个是依据的是Time.time，也就是当Time.time累加的值等于了FixedTimeStep，那么FixedUpdate和物理检测就会执行，可以理解成当时间被加速，和此时间有关的会被更频繁的执行，所以当Time.timeScale为0时，FixedUpdate不会被执行。

      4、UnityEngine.Time.fixedTime : 
      固定时间，上一次FixedUpdate开始执行的时间，从程序开始计时。

      5、UnityEngine.Time.frameCount ： 
      帧计数器，返回游戏一共经过了多少帧。

      6、UnityEngine.Time.maximumDeltaTime ： 
      一帧所需的最大时间，如果一帧所需的时间可能大于这个值，那么一些物理检测和其他一些固定帧的更新将会减少执行。

      7、UnityEngine.Time.realtimeSinceStartup ： 
      从程序启动到现在的时间，依据系统时间，不受Time.timeScale影响，当程序处于后台时，这个时间依然有效，不会停止计时，不管程序可不可以在后台运行。

      8、UnityEngine.Time.renderedFrameCount ： 
      这个没有找到任何官方文档，比较奇怪。从字面上理解，就是被渲染帧的次数。尝试在Update（还有FixedUpdate和LateUpdate，这两个和Update的值是一样的）里输出一下，会发现这个次数每次都是增加2，而不是增加1，这就很奇怪吧，Update是每一帧都要执行的，这个是肯定的，也就是再每一帧其实是渲染了两次的。想了一下，在一帧中，还有可能被执行的还有OnGUI，结果在里面输出一下发现，多增加的1果然是在这里面。这个应该用的比较少。

      9、UnityEngine.Time.smoothDeltaTime ： 
      一个平滑淡出Time.deltaTime的时间。在Update里和Time.deltaTime输出比较一下就会发下，这个值是当前的Time.deltaTime和上一帧的Time.smoothDeltaTime的一个差值的中间值。

      10、UnityEngine.Time.time ： 
      程序内部的一个时间，返回当前帧开始的时间，受Time.timaScale影响。在FixedUpdate里调用，将返回Time.fixedTime。当程序处于后台时，如果程序不可以在后台运行，这个时间将失效，不会再计时了。

      11、UnityEngine.Time.timeScale ： 
      时间缩放，影响一切基于Time.time的行为。

      12、UnityEngine.Time.timeSinceLevelLoad ： 
      从场景加载完到现在的时间，基于Time.time。

      13、UnityEngine.Time.unscaledDeltaTime ： 
      忽略Time.timeScale的Time.deltaTime。在刚开始的两帧貌似不太准

      14、UnityEngine.Time.unscaledTime ： 
      把每一帧的Time.unscaledDeltaTime 加起来就是这个属性的值，虽然说理解功能上Time.realtimeSinceStartup 有点相似，当时两者并不想等，就是因为Time.unscaledDeltaTime在程序开始不太准确的原因，导致和 realtimeSinceStartup 会有误差，这个要注意一下。