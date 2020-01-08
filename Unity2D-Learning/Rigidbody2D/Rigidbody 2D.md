# Rigidbody 2D

## 1 Body Type

### 1.1 Dynamic

1. Has the full set of properties available to it such as finite mass and drag, and is affected by gravity and forces.
2. Collide with every other body type.



**Note:**

1. **Do not use the Transform component** to set the position or rotation of a Dynamic Rigidbody 2D.
2. The simulation repositions a Dynamic Rigidbody 2D according to its **velocity**; you can change this directly via **forces** applied to it by **scripts**, or indirectly via **collisions and gravity**.

| Property                | Function                                                     |
| ----------------------- | ------------------------------------------------------------ |
| **Body Type**           | 选刚体类型                                                   |
| **Material**            |                                                              |
| **Simulated**           | whether interact with the physics simulation during run time |
| **Use Auto Mass**       |                                                              |
| **Mass**                | 定义刚体质量                                                 |
| **Linear Drag**         | Affecting positional movement                                |
| **Angular Drag**        | Affecting rotational movement                                |
| **Gravity Scale**       | 定义重力对物体的影响程度                                     |
| **Collision Detection** | 定义Collider 2D碰撞检测方式                                  |
| Discrete                | （会穿过物体或重叠）                                         |
| Continuous              | （不会穿过物体）                                             |
| **Sleeping Mode**       | 休眠方式 （节约程序时间）                                    |
| Never Sleep             |                                                              |
| Start Awake             |                                                              |
| Start Asleep            |                                                              |
| **Interpolate**         |                                                              |
| None                    |                                                              |
| Interpolate             |                                                              |
| Extrapolate             |                                                              |
| **Constraints**         |                                                              |
| Freeze Position         | 是否能在X&Y轴移动                                            |
| Freeze Rotation         | 是否能在Z轴移动                                              |



### 1.2 Kinematic 

**Note:**

1. **Kinematic** Rigidbody 2D is designed to be repositioned explicitly via [Rigidbody2D.MovePosition](http://docs.unity3d.com/ScriptReference/Rigidbody2D.MovePosition.html) or [Rigidbody2D.MoveRotation](http://docs.unity3d.com/ScriptReference/Rigidbody2D.MoveRotation.html).
2. Use physics queries to detect collisions, and scripts to decide where and how the Rigidbody 2D should move.
3. **Not affected by gravity and forces**, still move via its **velocity**.
4. **Not collide with** other **Kinematic** Rigidbody 2Ds or with **Static** Rigidbody 2Ds.

| Property                        | Function                                             |
| ------------------------------- | ---------------------------------------------------- |
| **Body Type**                   |                                                      |
| **Material**                    |                                                      |
| **Simulated**                   |                                                      |
| **Use Full Kinematic Contacts** | Enabled to collide with all Rigidbody 2D Body Types. |
| **Collision Detection**         |                                                      |
| Discrete                        |                                                      |
| Continuous                      |                                                      |
| **Sleeping Mode**               |                                                      |
| Never Sleep                     |                                                      |
| Start Awake                     |                                                      |
| Start Asleep                    |                                                      |
| **Interpolate**                 |                                                      |
| None                            |                                                      |
| Interpolate                     |                                                      |
| Extrapolate                     |                                                      |
| **Constraints**                 |                                                      |
| Freeze Position                 |                                                      |
| Freeze Rotation                 |                                                      |
|                                 |                                                      |

### 1.3 Static

**Note:**

1. Only collides with **Dynamic** Rigidbody 2Ds.

There are two ways to mark a Rigidbody 2D as **Static**:

1. For the GameObject with the Collider 2D component not to have a Rigidbody 2D component at all. All such Collider 2Ds are internally considered to be attached to a single hidden **Static** Rigidbody 2D component.
2. For the GameObject to have a Rigidbody 2D and for that Rigidbody 2D to be set to **Static**.

