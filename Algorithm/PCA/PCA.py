import numpy as np
import scipy.io as scio
import matplotlib.pyplot as plt


data=scio.loadmat('ex7data1.mat')
print(data)
X=data['X']
x=X[:,0]
y=X[:,1]
#plt.scatter(X[:,0],X[:,1])
#plt.show()
#均值归一化
mean_x=np.mean(x)
mean_y=np.mean(y)
scaled_x=x-mean_x
scaled_y=y-mean_y
data=np.matrix([[scaled_x[i],scaled_y[i]] for i in range(len(scaled_x))])
#计算协方差矩阵
cov=np.cov(scaled_x,scaled_y)
#计算协方差矩阵的特征向量
U,sigma,VT=np.linalg.svd(cov)
#选择主成分
feature=U[0]
#降维
data_reduced=np.dot(feature,np.transpose(data))
#feature=np.transpose(feature)
feature=[U[0]]
#数据恢复
data=np.transpose(np.dot(np.transpose(feature),data_reduced))

print(data)

