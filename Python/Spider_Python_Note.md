# Spider_Python Note

## 1 基础

### 1.1 登陆网页

```python
from urllib.request import urlopen
url="xxxxxx"
html = urlopen(url).read().decode('utf-8')#decode()转换文字编码
#html即是往往也所有信息
```

### 1.2 匹配网页内容

假设找网页的title:

```python
import re #正则表达式模块
result=re.findall(r"<title>(.+?)</title>",html)
print("\nPage title is:",result[0])
```

找<p>:

```python
res =re.findall(r"<p>(.+?)</p>",html,flags=re.DOTALL)# flags设置对tab等不敏感
```

## 2 BeautifulSoup

### 2.1 用处

BeautifulSoup包简化匹配方式，方便查询

### 2.2 下载

```bash
pip install beautifulsoup4
```

### 2.3 使用

```python
from bs4 import BeautifulSoup

soup = BeautifulSoup(html, features='lxml') # html是上文读取的内容
print(soup.h1)
print('\n',soup.p)#读取特定tag内容
```

### 2.4 官方文档

https://www.crummy.com/software/BeautifulSoup/bs4/doc.zh/

### 2.5  解析器

| 解析器          | 使用方法                             | 优势                                                      |
| --------------- | ------------------------------------ | --------------------------------------------------------- |
| Python标准库    | BeautifulSoup(markup, "html.parser") | 1. Python的内置标准库 2. 执行速度适中 3.文档容错能力强    |
| lxml HTML解析器 | BeautifulSoup(markup, "lxml")        | 速度快、文档容错能力强                                    |
| lxml XML解析器  | BeautifulSoup(markup, "xml")         | 速度快、唯一支持XML的解析器                               |
| html5lib        | BeautifulSoup(markup, "html5lib")    | 最好的容错性、以浏览器的方式解析文档、生成HTML5格式的文档 |

https://morvanzhou.github.io/tutorials/data-manipulation/scraping/3-01-requests/