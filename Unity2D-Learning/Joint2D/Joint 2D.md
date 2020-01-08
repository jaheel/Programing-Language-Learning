# Distance Joint 2D

属性：

Enable Collision: 启用以后连接的两个物体能够产生碰撞，关闭两个刚体无法产生碰撞，会直接穿过。

Connected Rigid Body: 连接的那一个刚体

Auto Configure Connected Anchor: 自动计算连接的锚

Anchor:含有Joint属性的刚体连接另一个物体的锚点（相对自身物体中心的位移点）

Connected Anchor:被连接的刚体的锚点（同样也是相对自身物体中心的位移点）

（将两个锚点连成一条线，即为两个刚体的Distance）



Distance：两个物体之间的距离

Max Distance Only: 勾选以后，被连接的物体能够自由移动，但不能超过最大Distance，Distance可变，有固定范围；没有勾选，两者的Distance就是固定不变的，不能相对位移，但能以圆的形式旋转

Break Force：意味相连的两物体承受了多大的拉力以后该Joint被破坏，Infinity代表无限，也就是无法被破坏



# Fixed Joint 2D

Damping Ratio：阻尼比，要抑制弹簧振动的程度：在0到1的范围内，值越高，运动越少。(阻尼系数越大，阻力就越大，弹簧的效果就越不明显，在这里这个值的范围是[0, 1]。)

Frequency：当物体接近你想要的分离距离时，弹簧发生振荡的频率（以每秒周期数测量）：在1到1,000,000的范围内，数值越高，弹簧越硬。 请注意，如果频率设置为0，则弹簧将完全变硬。

Break Torque：两者分离的扭力大小，Infinity代表无限



# Friction Joint 2D

Max Force：设置连接对象之间的线性（或直线）移动 - 高值可抵抗对象之间的线性移动。
Max Torque：设置连接对象之间的角度（或旋转）移动 - 高值可抵抗对象之间的旋转移动。



# Hinge Joint 2D

（主要是为了让一个刚体围绕一个固定点旋转）

Use Motor：是否使用马达。如果勾选了，那么这个关节就会有一个持续的力来转动这个关节来使其保持一个稳定的转速（仅当没有外力的时候是稳定的），当有外力作用时，速度会有增减。
Motor Speed：马达速度。
Maximum Motor Force：马达给的最大的力，使刚体达到motor speed速度。
Use Limits：是否使用旋转角度限制。
Lower Angle：限制最小旋转角度。
Upper Angle：限制最大旋转角度。

# Spring Joint 2D

Enable Collision：允许连接的两个物体发生碰撞。
Connected Rigid Body：指定连接的刚体。
Auto Configure Connected Anchor：自动计算锚点。
Anchor：自身锚点。
Connected Anchor：连接物体的锚点。
Auto Configure Distance：选中此框可自动检测两个物体之间的距离，并将其设置为两个物体之间接缝保持的距离。
Distance：手动设置两物体间距离。
Damping Ratio：要抑制弹簧振动的程度：在0到1范围内，值越高，运动越少。
Frequency：当物体接近你想要的分离距离时，弹簧发生振荡的频率（以每秒周期数衡量）：在0到1,000,000的范围内 - 数值越高，弹簧越硬。
Break Force：打断铰链并删除关节所需的力。 Infinity 意味着不可打断。



# Slider Joint 2D

Enable Collision：允许连接的两个物体发生碰撞。
Connected Rigid Body：指定连接的刚体。
Auto Configure Connected Anchor：自动计算锚点。
Anchor：自身锚点。
Connected Anchor：连接物体的锚点。
Auto Configure Angle：选中此框可自动检测两个物体之间的角度，并将其设置为两个物体之间接缝保持的角度。 （通过选择这个，你不需要手动指定角度。）
Angle：手动设置两个物体间角度。
Use Motor：是否使用马达
Motor Speed：马达速度
Maximum Motor Force：使物体达到motor speed的最大力。
Use Limits：是否使用滑动位置限制
Lower Translation：位置限制最低点。
Upper Translation：位置限制最高点。
Break Force：打断铰链并删除关节所需的力。 Infinity 意味着不可打断。
Break Torque：打断铰链并删除关节所需的扭矩。 Infinity 意味着不可打断。



# Relative Joint 2D

Enable Collision：允许连接的两个物体发生碰撞。
Connected Rigid Body：指定连接的刚体。
Max Force：设置连接对象之间的线性（直线）偏移量 - 高值（高达1,000）使用高强度来保持偏移量。
Max Torque：设置连接物体之间的角度（旋转）移动 - 高值（高达1,000）使用较高的力量来保持偏移量。
Correction Scale：调整关节以确保其行为符合要求。 （增加最大力量或最大力矩可能会影响行为，使关节不能达到目标，使用此设置来纠正它。）默认设置0.3通常是合适的，但它可能需要调整0和1之间的范围。
Auto Configure Offset：自动设置和保持连接对象之间的距离和角度。 （选择此选项意味着您不需要手动输入线性偏移和角度偏移。）
Linear Offset：线性偏移。
Angular Offset：角度偏移。
Break Force：打断铰链并删除关节所需的力。 Infinity 意味着不可打断。
Break Torque：打断铰链并删除关节所需的扭矩。 Infinity 意味着不可打断。

# Wheel Joint 2D

Enable Collision：允许连接的两个物体发生碰撞。
Connected Rigid Body：指定连接的刚体。
Auto Configure Connected Anchor：自动计算锚点。
Anchor：自身锚点。
Connected Anchor：连接物体的锚点。
Damping Ratio：要抑制弹簧振动的程度：在0到1范围内，值越高，运动越少。
Frequency：当物体接近所需的分离距离时，弹簧发生振荡的频率（以每秒周期数测量）：在0至1,000,000范围内，数值越高，弹簧越硬。
Angle：针对悬架的旋转角度
Use Motor：在车轮上施加电机力量？
Motor Speed：电机使目标到达速度（每秒度数）。
Maximum Motor Force：施加在物体上的最大力量以达到所需的速度。
Break Force：打断铰链并删除关节所需的力。 Infinity 意味着不可打断。
Break Torque：打断铰链并删除关节所需的扭矩。 Infinity 意味着不可打断。

# Target Joint 2D



