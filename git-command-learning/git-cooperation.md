# git 团队协作

##  1 思维模式

创造性思维：预见未来、另辟蹊径、头脑风暴、灵光一现、勇于质疑、保持专注

理解性思维：理解信息（分析型）、理解他人（同理心）

评估现状、阐明现状、善于组织、敏锐感知、产生共鸣、善于表达



决策性思维：分清主次、善于总结、验证结论、身体力行、价值驱动、相信直觉



## 2 常用术语

forking：派生

fork

check out：签出

stash：储藏（暂存更改、允许随后拉取刚刚储藏的工作并重新应用）

pull：抓取

fetch：拉取

merge：合并

branch：分支

tracked：跟踪

push：推送

github中的派生相当于git command 中的clone



merge conflict：合并冲突

Issues：专门板块，列出所有bug报告、功能请求和项目相关讨论（工单系统）



## 3 基本命令

### 3.1 shell

| 命令              | 用途                                  |
| ----------------- | ------------------------------------- |
| cd ~              | 转到你的home目录                      |
| mkdir             | 创建新目录                            |
| cd directory_name | 转到指定目录                          |
| ls -a             | 在OS X和基于Linux的系统下列出隐藏文件 |
| dir               | 在Windows下列出文件                   |
| touch file_name   | 使用指定名称创建新的空文件            |



### 3.2 git

| 命令                                                         | 用途                                                     |
| ------------------------------------------------------------ | -------------------------------------------------------- |
| git clone URL                                                | 下载远程仓库的副本                                       |
| git init                                                     | 将当前目录转换成一个新的Git仓库                          |
| git status                                                   | 获取仓库状态报告                                         |
| git add --all                                                | 将所有修改过的文件和新文件添加至仓库的暂存区             |
| git commit -m "message"                                      | 将所有暂存的文件提交至仓库                               |
| git log                                                      | 查看项目历史                                             |
| git log --oneline                                            | 查看压缩过的项目历史                                     |
| git branch --list                                            | 列出所有本地分支                                         |
| git branch --all                                             | 列出本地和远程分支                                       |
| git branch --remotes                                         | 列出所有远程分支                                         |
| git checkout --track remote_name/branch                      | 创建远程分支的副本，在本地使用                           |
| git checkout branch                                          | 切换到另一个本地分支                                     |
| git checkout -b branch branch_parent                         | 从指定分支创建一个新分支                                 |
| git add filename(s)                                          | 仅暂存并准备提交指定文件                                 |
| git add --patch filename                                     | 仅暂存并准备提交部分文件                                 |
| git reset HEAD filename                                      | 从在那存取移除提出的文件修改                             |
| git commit --amend                                           | 使用当前暂存的修改更新之前的提交，并提供一个新的提交消息 |
| git show commit                                              | 输出某个提交的详细信息                                   |
| git tag tag commit                                           | 为某个提交对象打上标签                                   |
| git tag                                                      | 列出所有标签                                             |
| git show tag                                                 | 输出所有带标签提交的详细信息                             |
| git remote add remote_name URL                               | 创建一个指向远程仓库的引用                               |
| git push                                                     | 将当前分支上的修改上传至远程仓库                         |
| git remote --verbose                                         | 列出所有可用远程连接中fetch和push命令使用的URL           |
| git push --set-upstream remote_name branch_local branch_remote | 将本地分支的副本推送至远程服务器                         |
| git merge branch                                             | 将当前存储在另一分支的提交并入当前分支                   |
| git push --delete remote_name branch_remote                  | 在远程服务器中移除指定名称的分支                         |



##  许可证

MIT：允许注明原作者的前提下自由使用代码，并且你不需要为衍生的软件负责

Apache：明确将原作者的专利授权给用户，并要求用户提供变更说明，描述你的作品在之前的版本上做了哪些修改。

GNU GPL：要求作品或衍生品的分发者将源码以相同协议共享



## 4 常用命令

### 4.1 初始化目录的版本控制

```git
git init
```

### 4.2 检查仓库的当前状态

```
git status	
```

### 4.3 将仓库中所有文件添加到暂存区

```
git add --all
```

### 4.4 件所有暂存的文件提交至存仓库

```
git commit -m
```

### 4.5 使用log命令查看仓库历史纪录

```
git log
```

### 4.6 查看缩短的项目历史纪录

```
git log --oneline
```

### 4.7 列出本地分支

``` 
git branch --list
```

### 4.8 列出所有分支

```
git branch --all
```

### 4.9 列出远程分支

``` 
git branch --remotes
```

### 4.10 更新远程分支列表

```
git fetch
```

### 4.11 创建新分支操作详解
#### 4.11.1 创建新分支

```
git branch 分支名称
```

#### 4.11.2 分支切换


```
git checkout 分支名称
```

#### 4.11.3 从主分支创建一个新的开发分支

```
git checkout -b 1-process_notes master
```

#### 4.11.4 将工单分支并入你的主分支

```
git checkout master
git merge 1-process_notes
```

#### 4.11.5 删除这个分支的本地副本
```
git branch --delete 1-process_notes
```

#### 4.11.6 删除不再需要的远程分支

```
git push --delete my_gitlab 1-process_notes
```





