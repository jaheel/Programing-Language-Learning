# Docker

## 1 image

```bash
docker image pull hello-world#拉取hello-world实例

docker image ls #查看本地image


```

## 2 container

```bash
#列出本机正在运行的容器
docker container ls 

#列出本机所有容器，包括终止运行的容器
docker container ls --all

#本地运行hello-world实例
docker container run hello-world 

#手动终止实例(针对不会自动终止的容器)
docker container kill [containID] 

#删除容器文件(终止的同时连带本地文件一并删除)
docker container rm [containerID]
```

