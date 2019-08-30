# Platform Effector 2D

可以根据角度大小的设置，实现角色从下往上跳不与物体碰撞，但下降时能与物体碰撞，也就是说，添加该Effector以后，物体的碰撞是单方向的。



首先使用该效应器需要去除Is Trigger选项，平台效应器可以实现单向碰撞、去除边侧碰撞的效果。（需要添加Collider属性）

 Use Collider Mask：是否使用Collider Mask属性，默认状态下效应器对所有刚体都会施加力；
 Collider Mask：选择Layer，用于指定会被效应器影响的物体；
 Use One Way：应该使用单向碰撞行为吗？
 Use One Way Grouping：确保由单向行为禁用的所有联系人对所有碰撞者都起作用。 当通过平台的对象上使用多个碰撞器时，这非常有用，它们都需要作为一个组一起行动。
 Surface Arc：以“上”为中心的弧的角度定义了不允许碰撞器通过的表面。 任何超出这个弧的地方都被认为是单向碰撞。
 Use Side Friction：平台两边侧是否使用摩擦？
 Use Side Bounce：平台两边侧是否使用反弹？
 Side Arc：定义平台侧面的弧的角度以效应器的局部“左”和“右”为中心。 这个弧内的任何碰撞法线都被认为是“侧面”行为。

 Use One Way：是否允许一方通行；
 Use One Way Grouping：当多个平台效应器启用一方通行时，启用该值；
 Use Side Friction：边侧是否使用摩擦力；
 Use Side Bounde：边侧是否使用弹力；
 Side Arc：边侧的角度，只有法线与其垂直的才算是边侧。

# Surface Effector 2D

首先使用该效应器需要去除Is Trigger选项，表面效应器可以实现传送带的效果。
Force Scale：允许调整施加里的比例，最好不要设为1，不然会抵消掉跳跃移动等力。

Use Collider Mask：是否使用Collider Mask属性，默认状态下效应器对所有刚体都会施加里；
Collider Mask：选择Layer，用于指定会被效应器影响的物体；
Speed：沿着表面保持的速度。
Speed Variation：速度的随机增加（0和速度变化值之间的任意值）将应用于速度。 如果在此输入负数，则将应用速度的随机降低。
Force Scale：当效应器试图沿着表面达到指定的速度时，允许缩放施加的力。 如果为0，则不施加力，则被有效地禁用。 如果1则应用全力。 但是施加全力会轻易地抵消施加到目标物体上的任何其他力，例如跳跃或其他运动力。 建议值小于1。
Use Contact Force：是否应该在表面和碰撞器之间的接触点施加力？ 使用接触力可以导致目标物体旋转，而不使用接触力不会。
Use Friction：接触表面时应使用摩擦吗？
Use Bounce：接触表面时是否应该使用反弹？

# Point Effector 2D

以当前区域Transform的坐标为中心，产生吸引力或排斥力，可以做到类似小行星围绕地球旋转的效果。

Use Collider Mask：是否使用Collider Mask属性，默认状态下效应器对所有刚体都会施加里；
Collider Mask：选择Layer，用于指定会被效应器影响的物体；
Force Magnitude：要应用的力量的大小。
Force Variation：要施加的力的大小的变化。
Distance Scale：缩放应用于源和目标之间的距离。 在计算距离时，按照这个量来缩放，从而允许改变有效距离，从而控制施加的力的大小。
Drag：应用于刚体的线性阻力。
Angular Drag：适用于刚体的角阻力
Force Source：力量源（吸引或排斥目标物体的点）。
Collider：力量源被定义为碰撞器的位置.
Rigidbody：力量源被定义为刚体的位置.
Force Target    力量目标（效应器施加任何力量的目标物体上的点）。
Collider：目标点被定义为碰撞器的位置。 如果碰撞器没有位于质心处，在这里施加力可能会产生扭矩（导致目标旋转）。
Rigidbody：目标点被定义为刚体的当前质量中心。 在这里施加力量永远不会产生扭矩（导致目标旋转）。
Force Mode：如何计算力量。
Constant：忽略源和目标之间的距离而施加力。
Inverse Linear：该力是作为源和目标之间的距离的反线性函数而施加的。 当源和目标处于相同的位置时，将施加全力，但当它们分开时力会线性下降。
Inverse Squared：该力是作为源和目标之间的距离的反平方函数而施加的。 当源和目标处于相同位置时，将施加全部力，但当它们分开时力会平方下降。 这与真实世界的引力类似。



# Area Effector 2D

区域效应器对制定的一个2D区域施加一个力，注意区域使用Collider 2D来制定，Collider 2D上需要勾选Used By Effector和Is Trigger，否则会和其他物体发生碰撞。



Use Collider Mask：是否使用Collider Mask属性，默认状态下效应器对所有刚体都会施加里；
Collider Mask：选择Layer，用于指定会被效应器影响的物体；
Use Global Angle：勾选时，Angle属性会以全局形式进行处理；
Force Angle：力的角度；
Force Magnitude：力的大小；
Force Variation：力变化的大小，用于给力增加一个随机量；
Drag：线性力的阻力；
Angular：角速度的阻力；
Force Target：
1.Collider，目标点被定义为碰撞器的当前位置。 如果碰撞器没有位于质心处，在这里施加力可能会产生扭矩（导致目标旋转）。
2.Rigidbody：目标点被定义为刚体的当前质量中心。 在这里施加力量永远不会产生扭矩（导致目标旋转）。



# Buoyancy Effector 2D 浮力效应器

浮力效应器定义了简单的流体行为，设置流体的阻力、浮动和流动。甚至可以控制流动发生在流体下面。

Use Collider Mask：是否使用Collider Mask属性，默认状态下效应器对所有刚体都会施加里；
Collider Mask：选择Layer，用于指定会被效应器影响的物体；
Surface Level：当刚体完全小于该表面时，区域才会施加浮力；
Density：影响碰撞体行为的效应流体的密度
Linear Drag：影响物体位置移动的阻力系数 - 仅适用于流体内部。
Angular Drag：影响物体旋转运动的阻力系数 - 仅适用于流体内部。
Flow Angle：流体流动方向的世界空间角度（度）。
Flow Magnitude：流体流动力的“力量”。 结合流体角度，这指定了施加到流体内物体的力的水平。 幅度也可以是负的，在这种情况下，力以180度施加到流角。
Flow Variation：在这里输入一个值来随机改变流体力量。 您可以指定一个正或负的变化来随机添加或减少流体
