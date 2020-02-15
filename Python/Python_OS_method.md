# Python_OS_method

## Python_os

| Method                     | usage                                                  |
| -------------------------- | ------------------------------------------------------ |
| os.chdir(path)             | 改变当前工作目录                                       |
| os.chroot(path)            | 改变当前进程的根目录                                   |
| os.close(fd)               | 关闭文件描述符fd                                       |
| os.dup(fd)                 | 复制文件描述符fd                                       |
| os.dup2(fd,fd2)            | 将一个文件描述符fd复制到另一个fd2                      |
| os.link(src,dst)           | 创建硬链接，名为参数dst，指向参数src                   |
| os.listdir(path)           | 返回path指定文件夹中包含的文件或文件夹的名字的列表     |
| os.open(file,flags[,mode]) | 打开一个文件，并且设置需要的打开选项，mode参数是可选的 |
| os.pipe()                  | 创建一个管道，返回一对文件描述符(r,w)分别为读和写      |
| os.readlink(path)          | 返回软链接所指向的文件                                 |
| os.remove(path)            | 删除路径为path的文件                                   |
| os.removedirs(path)        | 递归删除目录                                           |
| os.rename(src,dst)         | 重命名文件或目录，从src到dst                           |
| os.rmdir(path)             | 删除path指定的空目录，若非空，则抛出一个OSError异常    |
| os.symlink(src,dst)        | 创建一个软链接                                         |
|                            |                                                        |
|                            |                                                        |
|                            |                                                        |
|                            |                                                        |

## os.path()模块

| Method                        | usage                                                        |
| ----------------------------- | ------------------------------------------------------------ |
| os.path.abspath(path)         | 返回绝对路径                                                 |
| os.path.basename(path)        | 返回文件名                                                   |
| os.path.dirname(path)         | 返回文件路径                                                 |
| os.path.exists(path)          | 如果路径path存在，返回True;反之返回False                     |
| os.path.getatime(path)        | 返回最近访问时间                                             |
| os.path.getmtime(path)        | 返回最近文件修改时间                                         |
| os.path.getsize(size)         | 返回文件大小                                                 |
| os.path.isabs(path)           | 判断是否为绝对路径                                           |
| os.path.isfile(path)          | 判断路径是否为文件                                           |
| os.path.isdir(path)           | 判断路径是否为目录                                           |
| os.path.islink(path)          | 判断路径是否为链接                                           |
| os.path.join(path1,path2,...) | 把目录和文件名合成一个路径                                   |
| os.path.realpath(path)        | 返回path的真实路径                                           |
| os.path.relpath(path,start)   | 从start开始计算相对路径                                      |
| os.path.sameopenfile(fp1,fp2) | 判断fp1和fp2是否指向同一文件                                 |
| os.path.split(path)           | 把路径分割成dirname和basename，返回一个元组                  |
| os.path.splitdrive(path)      | 返回驱动器名和路径组成的元组                                 |
| os.path.splitext(path)        | 返回路径名和文件扩展名的元组                                 |
| os.path.walk(path,visit, arg) | 遍历path,进入每个目录都调用visit函数，visit函数必须有3个参数(arg,dirname,names)，dirname表示当前目录的目录名，names代表当前目录下的所有文件名，args则为walk的第三个参数 |

