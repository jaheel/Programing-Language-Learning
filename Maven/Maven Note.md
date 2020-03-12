# Maven Note

## 1 目录结构

* src文件夹

  > - src\main\java:存放项目的Java源代码
  > - src\main\resources:存放项目相关的资源文件（比如配置文件）
  > - src\test\java:存放项目的测试Java源代码
  > - src\test\resources:存放运行测试代码时所依赖的资源文件

* target文件夹

* pom.xml

  > 配置Maven管理的所有内容

## 2 编译、测试

CMD切换到工程目录

 ```bash 
 mvn clean #清空以前编译安装过的历史结果
 mvn compile #编译源代码
 mvn test #运行测试案例进行测试
 mvn install # 当前代码打成jar包，安装到Maven的本地管理目录下，其他Maven工程只要指定坐标就可以使用
 ```

   

## 3 引入外部依赖

在pom.xml文件中

```xml
<dependencies>
    <!-- 在这里添加你的依赖 -->
    <dependency>
        <groupId>ldapjdk</groupId>  <!-- 库名称，也可以自定义 -->
        <artifactId>ldapjdk</artifactId>    <!--库名称，也可以自定义-->
        <version>1.0</version> <!--版本号-->
        <scope>system</scope> <!--作用域-->
        <systemPath>${basedir}\src\lib\ldapjdk.jar</systemPath> <!--项目根目录下的lib文件夹下-->
    </dependency> 
</dependencies>
```

