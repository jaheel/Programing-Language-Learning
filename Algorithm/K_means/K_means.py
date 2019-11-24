import scipy.io as scio
import numpy as np
from numpy import *
from matplotlib import pyplot as plt  
#欧式距离
def distEclud(vecA,vecB):
    return sqrt(sum(power(vecA-vecB,2)))

#随机质心
def randCent(dataMat,k):
    
    n=shape(dataMat)[1]
    #初始化质心，创建(k,n)个以零填充的矩阵
    centroids=mat(zeros((k,n)))
    #循环遍历特征值
    for j in range(n):
        minJ=min(dataMat[:,j])
        rangeJ=float(max(array(dataMat)[:,j])-minJ)
        centroids[:,j]=minJ+rangeJ*random.rand(k,1)
    #返回质心
    print ('randCent:')
    print (centroids)
    return centroids

def DefiniteCent():
    centroids=mat(zeros((3,2)))
    centroids[0,0]=3
    centroids[0,1]=3
    centroids[1,0]=6
    centroids[1,1]=2
    centroids[2,0]=8
    centroids[2,1]=5
    print ('DefiniteCent:')
    print (centroids)
    return centroids

def KMeans(dataMat, k,max_times=10, distMeas=distEclud, createCent=DefiniteCent):
    # 获取样本数和特征数
    m= shape(dataMat)[0]
    # 初始化一个矩阵来存储每个点的簇分配结果
    # clusterAssment包含两个列:一列记录簇索引值,第二列存储误差(误差是指当前点到簇质心的距离,后面会使用该误差来评价聚类的效果)
    clusterAssment = mat(zeros((m, 2)))
    # 创建质心,随机K个质心
    centroids = createCent()
    # 初始化标志变量,用于判断迭代是否继续,如果True,则继续迭代
    clusterChanged = True
    while clusterChanged or max_times<0:
        max_times-=1
        clusterChanged = False
        # 遍历所有数据找到距离每个点最近的质心,
        # 可以通过对每个点遍历所有质心并计算点到每个质心的距离来完成
        for i in range(m):
            minDist = inf # 正无穷
            minIndex = -1
            for j in range(k):
                # 计算数据点到质心的距离
                # 计算距离是使用distMeas参数给出的距离公式,默认距离函数是distEclud
                distJI = distMeas(centroids[j, :], dataMat[i, :])
                # 如果距离比minDist(最小距离)还小,更新minDist(最小距离)和最小质心的index(索引)
                if distJI < minDist:
                    minDist = distJI
                    minIndex = j
            # 如果任一点的簇分配结果发生改变,则更新clusterChanged标志
            if clusterAssment[i, 0] != minIndex:
                # print(clusterAssment[i, 0],minIndex)
                clusterChanged = True
            # 更新簇分配结果为最小质心的index(索引),minDist(最小距离)的平方
            clusterAssment[i, :] = minIndex, minDist ** 2
        # print(centroids)
        # 遍历所有质心并更新它们的取值
        for cent in range(k):
            # 通过数据过滤来获得给定簇的所有点
            ptsInClust = dataMat[nonzero(clusterAssment[:, 0].A == cent)[0]]
            # 计算所有点的均值,axis=0表示沿矩阵的列方向进行均值计算
            centroids[cent, :] = mean(ptsInClust, axis=0)# axis=0列方向
    
    print ('centroids:')
    print (centroids)
    print ('clusterAssment:')
    print (clusterAssment)

    # 返回所有的类质心与点分配结果
    return centroids, clusterAssment


def KMeansShow(dataMat,centers,clusterAssment):
    plt.scatter(np.array(dataMat)[:,0],np.array(dataMat)[:,1],c=np.array(clusterAssment)[:, 0].T)
    plt.scatter(centers[:, 0].tolist(), centers[:, 1].tolist(), c="r")
    plt.show()

data=scio.loadmat('ex7data2.mat')
X=data['X']
Mycentroids,MyClusterAssment=KMeans(X,3)
KMeansShow(X,Mycentroids,MyClusterAssment)




