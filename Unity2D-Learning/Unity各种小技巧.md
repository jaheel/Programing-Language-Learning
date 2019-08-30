# Debug测试

​        Debug.Log("普通信息");

​        Debug.LogWarning("警告信息");

​        Debug.LogError("错误信息");

# Scene切换

​      1.添加：using UnityEngine.SceneManagement;

​      2.调用：SceneManager.LoadScene("__",LoadSceneMode.Single);

​                    "__" 可以是场景名字，也可以是数字（Build&Setting里排序）。

　 3.单纯转换场景用 SceneManager.LoadScene("__");

# 退出游戏

调用：Application.Quit();

# 获取当前场景的名称、编号

​        //获取编号
​        int index = SceneManager.GetActiveScene().buildIndex;
​        //获取名称 
​        string name = SceneManager.GetActiveScene().name;

# 物体移动

### 第一种方法（坐标变换）

API：  Transform.Translate()  

直接对坐标进行操作

### 第二种方法（刚体速度变换）

API： 

3D: Rigidbody.velocity=new Vector3(Speed.x,Speed.y,Speed.z);

2D: Rigidbody.velocity=new Vector2(Speed.x,Speed.y);

对刚体速度进行操作

### 第三种方法（刚体力的添加）

API：

2D: Rigidbody.AddForce(new Vector2(Force.x,Force.y));

3D: Rigidbody.AddForce(new Vector3(Force.x,Force.y,Force.z));

在刚体上添加不同方向的力，从而实现物体的移动，还可以添加力的方式，如下所示：

Rigidbody.AddForce(Vector2,ForceMode2D); //2D中ForceMode2D只有Force和Impulse

Rigidbody.AddForce(Vector3,ForceMode);//3D中有Force、Acceleration、Impulse和VelocityChange





# Csharp代码中将参数传给状态转换机

参数值设置为bool、float、int都行，参数名字为String类型，以下方法效率比直接传递效率更高一点

在C#中：

### （先将参数名Hash成int型数字）

// replace string names with hash codes
    private static readonly int Run = Animator.StringToHash("Run");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int JumpDown = Animator.StringToHash("JumpDown");
    private static readonly int Hurt = Animator.StringToHash("Hurt");
    private static readonly int Crouch = Animator.StringToHash("Crouch");
    private static readonly int Climb1 = Animator.StringToHash("Climb");
    private static readonly int ClimbStop = Animator.StringToHash("ClimbStop");

 

### 再将参数传给Hash函数中的代号

  _animator.SetBool(Run, false);



# 平台自动移动

Angel能够调整360度中任意角度的方向，然后在此方向进行移动



第一步：加入一个自动移动的点，在这个空物体上加入Slider Joint2D和Rigidbody2D属性，将Rigidbody2D设置为Kinematic

第二步：将想自动移动的物体加入刚体，然后把该物体拖到Slider Joint2D中的Connected Rigid Body中去

第三步：在点上加入发动机，发动机速度设置为任意值，加入脚本，我们将自动移动转换的时间为任意值，修改Angle即可实现反方向移动，不需要更改发动机速度，代码如下所示：

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveCeiling : MonoBehaviour
{
    private SliderJoint2D _SliderJoint;
    private float _Time;//设置自动时间为2s

    private void Awake()
    {
        _SliderJoint = GetComponent<SliderJoint2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _Time = 2f;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        _Time -= Time.deltaTime;
        if(_Time<=0)
        {
            _Time = 2f;
            _SliderJoint.angle= (_SliderJoint.angle+180)%360;
        }
    }

}
```

