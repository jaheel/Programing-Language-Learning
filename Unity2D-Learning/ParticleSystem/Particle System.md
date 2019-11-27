# Particle System

## Paritcle System Module

 Duration：粒子发射周期，如图的意思就是在发射3.32秒以后进入下一个粒子发射周期。如果没有勾选looping的话，3.32秒之后粒子会停止发射。 
- Looping:粒子按照周期循环发射。 
- Prewarm：预热系统，比如说我有一个空间大小的粒子系统，但是粒子发射速度有限，我想在最开始的时候让粒子充满空间，此时就应该勾选Prewarm。 
- StartDelay：粒子延时发射，勾选后，延长一段时间才开始发射。 
- StartLifeTime：粒子从发生到消失的时间长短。 
- StartSpeed：粒子初始发生时候的速度。 
- 3DStartSize：这个属性是当你需要把粒子在某一个方向上扩大的时候使用。 
- StartSize:粒子初始的大小。 
- 3DStartRotation：需要在一个方向旋转了子的时候可以使用。 
- StartRotation：粒子初始旋转。 
- RandomizeRotation：随机旋转粒子方向，感觉在3D粒子的情况下，尤其是圆形的没什么用。 
- StartColor：粒子初始颜色，可以调整加上渐变色。 
- GravityModifier：重力修正。 
- SimulationSpace：a.Local,此时粒子会跟随父级物体移动。b.World，此时粒子不会跟随父级移动。c.Custom，粒子会跟着指定的物体移动。 
- SimulationSpeed：根据Update模拟的速度。 
- DeltaTime：一版的DeltaTime都是1，如果需要用到Sacled是在游戏需要暂停的时候，根据TimeManager来定。如果选择UnScale的话，就会忽略时间的影响。 
- ScalingMode：Local：粒子系统的缩放和自己Transform的一样会忽略父级的缩放。Hierarchy：粒子缩放跟随父级。Shape：将粒子系统跟随初始位置，但是不会影响粒子系统的大小。 
- EmitterVelocity： 
- MaxParticles：粒子系统可以同时存在的最大粒子数量。如果粒子书数量超过最大值粒子系统会销毁一部分粒子。 
- AutonRandomSeed：随机种子，如果勾选会生成完全不同不重复的粒子效果，如果勾选即为可重复。


## Emission Module

RateOverTime:随单位时间生成粒子的数量。
RateOverDistance：随着移动距离产生的粒子数量。只有当粒子系统移动时，才发射粒子。
Bursts： 
Time：从第几秒开始。
Min：最小粒子数量。
Max：最大的粒子数量，粒子的数量会在Min和Max之间随机。
Cycles：在一个周期中循环的次数。
Interval：两次两次Cycles的间隔时间。

## Trailer Module

如果使用Trails模块的话，必须在Renderer中给TrailMaterial赋值。 
- Ratio：分配给某个粒子拖尾的几率。 
- Lifetime：拖尾存在的时间。 
- MinimumVertexDistance：定义粒子在其Trail接收到新顶点之前必须行进的距离。接受新顶点以为重新定位Trail。 
- TextureMode： 
- WorldSpace：如果选用，即使应用LocalSimulationSpace，Trail顶点也不会随着粒子系统的物体移动。并且，Trail会进入世界坐标系，并且忽略任何粒子系统的移动。 
- DieWithParticle：Trail跟随粒子系统销毁。 
- SizeAffectsWidth：如果勾选的话，Trail的宽度会乘粒子系统的尺寸。 
- SizeAffectsLifetime：Trail的Lifetime乘以粒子系统的尺寸。 
- InheritParticleColor：Trail的颜色会根据粒子的颜色调整。 
- ColorOverTrail：用于控制Trail在曲线上的颜色。 
- WidthOverTrail：用于控制Trail在曲线上的宽度。


## Texture Sheet Animation Module

Mode: 
Grid：用网格来实现。
Sprite：通过相同尺寸的Sprite实现粒子动画。
Tiles：网格的行列数。
Animation： 
WholeSheet：动画作用于整个表格。
SingleRow：动画只用于单独一行。有一个随机的选项可以选择或者是选择单独的一行来做动画。
FrameOverTime：根据时间来播放帧，横坐标是1s，纵坐标是帧数。
StartFrame：开始的帧是哪一帧。
Cycles：在1秒之内循环播放的次数。
FlipU：翻转U。
FlipV：翻转V。
EnabledUVChannels：

## Renderer Module

RenderMode： 
Billboard：粒子总是面对相机。
StretchedBillboard：伸展板，可以根据相机，速度，长度来调节粒子的缩放。
HorizontalBillboard：粒子平面平行于Floor平面。
VerticalBillboard：粒子平面平行于世界坐标的Y轴，但是面向相机。
Mesh：将粒子渲染到网格上去。
TrailMaterial：需要使用拖尾效果的时候，才附材质。
Material：用于渲染粒子的材质。
SortMode： 
ByDistance：根据粒子离相机的距离渲染。
OldestInFront：先渲染出来的在最上层。
YoungestInFront：后渲染出来的在最上层。
SortingFudge：排序容差，仅影响整个系统在场景中出现的位置。Sorting值越小，就越容易粒子系统在其它透明的GameObjects上绘制的机会。
Pivot：修改粒子渲染的轴点。
VisualizePivot：可视化轴点。
Masking：
CustomVertexStreams：在材质的顶点着色器中配置哪些粒子属性可用。
CastShadows：使用阴影。
ReceiveShadows：规定阴影是否可以投射到粒子上，只有Opaque（不透明）的材质可以接受阴影。
MotionVectors：

## Color Over Lifetime Module

Color: 可设置多个渐变颜色点，多个透明度转移点

## Velocity over LifeTime Module

**Linear****（**线性）：粒子朝X，Y，Z轴的方向匀速移动。曲线时间轴是Duration时间。

​         **Space**（空间）：可设置为是世界空间world或自身空间local。

**Orbital**（轨道）：可以使粒子绕着某个轴自行旋转。数值是可以快旋转的速度。观察到，值为1时，粒子绕行一周所需粒子生命大致为6.28s。是pi*2。

**Offset**（偏移）：在Orbital旋转的过程中在施加一个轴方向的速度。能使粒子不在绕着中心自转，而是形成一个圆环，适合模拟星系。这个速度和上面linear施加其上，效果看是差不多的，但是计算方式是完全不同，这里不做深究，只要注意Orbital所旋转的轴，这个轴方向是无法施力的就行。增加值，可以是圆环范围扩大。值为1时，半径是1m。

  **Radial**（半径）：这个值增加整个粒子的运动形成一个螺旋线。值越大，范围越大。默认是0，就是一个圆。还是深究下，这里的Orbital、Offset其实用到的是一个渐开线，而半径是指基圆的半径。

**SpeedModifier**（速度修正）：如果上面的各项值都调好了，忽然想在增加下粒子运动速度时，可以修正性的调节。效果上是和Orbital轴上的值是一样的。

