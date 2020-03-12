# babun issues

## 1 download

网址：http://babun.github.io/



自定义安装路径（cmd中执行）：

```
Babun.bat /t c:\Babun
```



babun启动默认路径：

```
’%userprofile%.Babun\cygwin\home\username’
```

## 2 Font setting

### 2.1 download fonts

```
# clone(克隆git)git clone https://github.com/powerline/fonts.git --depth=1
# install(运行安装脚本)
cd fonts
./install.sh
# clean-up a bit(清楚克隆git文件)_
cd ..
rm -rf fonts
```

### 2.2 setup fonts

step:

1. 在`~\.local\share\fonts`目录下找到`DejaVu Sans Mono for Powerline`字体
2. 右击-->安装

### 2.3 set babun

step:

1. 打开.minttyrc文件

2. 复制进去

   ```
   BoldAsFont=no
   Columns=150
   Rows=55
   Font=DejaVu Sans Mono for Powerline
   FontHeight=10
   Transparency=low
   ForegroundColour=#A0A0A0
   BackgroundColour=#1B1D1E
   CursorColour=#A0A0A0
   Black=#1B1D1E
   Red=#F92672
   Green=#82B414
   Yellow=#FD971F
   Blue=#268BD2
   Magenta=#8C54FE
   Cyan=#56C2D6
   White=#CCCCC6
   BoldRed=#FF5995
   BoldBlack=#505354
   BoldGreen=#B7EB46
   BoldYellow=#FEED6C
   BoldBlue=#62ADE3
   BoldMagenta=#BFA0FE
   BoldCyan=#94D8E5
   BoldWhite=#F8F8F2
   ```

### 2.5 restart babun

## 3 Python配置

Babun默认Python是python2

step:

1. 删除babun与python的连接
2. 绑定自己系统中Python所在文件夹创建python连接

```
cd /usr/bin
rm -rf python #解除原版绑定
ln -s /cygdrive/d/.../python.exe /usr/bin/python #绑定python路径
python -i #在Babun中，需要加上-i参数，才能正常启动python
```



## 4 babun配置git

step:

1. 生成ssh

   ```bash
   ssh-keygen -t rsa -C "xxx@xxx.com"
   ```

2. 将ssh添加到github中

   > rsa文件位于 .babun/cygwin/home/username/.ssh

3. 首次添加需要在babun中添加信任

   ```bash
   ssh -T username@github.com
   ```

4. 添加成功后即可使用