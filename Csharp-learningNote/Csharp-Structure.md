# Dictionary

字典序集合，提供一组关键字到一组值得映射

| 方法和属性                  | 说明                                              |
| --------------------------- | ------------------------------------------------- |
| Add(Key,Value)              | 添加                                              |
| TryGetValue(Key, out value) | 取值：若有，返回true,value存放结果；否则返回false |
| ContainsKey(Key)            | 判断是否包含该关键字：是，返回true;否则，false    |
| Remove(Key)                 | 移除某个元素                                      |
| Clear()                     | 清除该集合所有元素                                |
| DictionaryValueName[Key]    | 通过关键字访问                                    |
| DictionaryValueName.Keys    | 取关键字Key集合                                   |
| DictionaryValueName.Values  | 取Value集合                                       |
| DictionaryValueName.Count   | 集合元素个数                                      |

