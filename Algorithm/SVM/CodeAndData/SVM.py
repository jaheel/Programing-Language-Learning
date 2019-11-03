import scipy.io as scio
import numpy as np
from sklearn import svm
from sklearn.model_selection import train_test_split
from sklearn.metrics import accuracy_score
data=scio.loadmat('ex3data1.mat')
X=data['X']
Y=data['y'].flatten()

x_train,x_test,y_train,y_test=train_test_split(X,Y,random_state=1,test_size=0.2)

c=[0.01,0.03,0.1,0.3,1,3,10,30]
g=[0.01,0.03,0.1,0.3,1,3,10,30]


for i in range(len(c)):
    for j in range(len(g)):
        clf=svm.SVC(C=c[i],kernel='rbf', gamma=g[j])
        clf.fit(x_train,y_train)
        y_predict=clf.predict(x_test)
        print('c: %f' % c[i])
        print('gamma: %f' % g[j])
        print ('训练集准确率:')
        print(accuracy_score(y_train,clf.predict(x_train)))
        print ('测试集准确率:')
        print(accuracy_score(y_test,y_predict))