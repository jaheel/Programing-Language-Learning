# Python issues

## 1 更改Python的pip install默认安装路径

step:

1. cmd中运行

   ```cassandra
   python -m site -help
   ```

2. 找到python的下载路径，打开site.py文件

3. 更改里面以下两个变量

   ```python
   
   USER_SITE = "%python安装路径%\Lib\site-packages"     #用户自定义的依赖安装包的路径
    
   USER_BASE = "%python安装路径%\Scripts"    #用户自定义的启用Python脚本的路径
   ```

4. 再次

   ```
   python -m site //检查是否更改成功
   ```




## 2 使用国内镜像修改pip源

### 2.1 临时使用国内源

```
pip install -i https://pypi.tuna.tsinghua.edu.cn/simple xxx
```

### 2.2 配置国内源默认使用

​	Windows:

​	step:

1. 建立C:\Users\xxx(用户名)\pip\pip.ini文件
2. 添加如下命令

```
 [global]
 index-url = https://pypi.tuna.tsinghua.edu.cn/simple
```

