# UnityParseJson

## JsonUtility

### JsonUtility.FromJsonOverwrite

PS:

1. Loads the JSON data into an existing object.
2. Update the values stored in classes or objects without any allocations.
3. Using the Unity serializer, Supoort MonoBehaviour, ScriptableObject, or plain class/struct with the Serializable attribute applied
4.  Unsupport private fields, static fields, and fields with the NonSerialized attribute applied
5. Unsupport Property

```c#
public static void FromJsonOverwrite(string json,object objectToOverwrite);
/* json: The JSON representation of the object
 * objectToOverwrite: The object that should be overwritten
 */
```

#### Test

测试公有属性的更改情况

```c#
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public string PlayerName;
    public int Lives;
    public float Health;

    

    public void ParseItemJson()
    {
        string itemJson = File.ReadAllText("Assets\\Test.json");//从项目根目录开始加载
        JsonUtility.FromJsonOverwrite(itemJson,this);
    }

    private void Awake()
    {
        ParseItemJson();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Lives:"+Lives);
        Debug.Log("Health:"+Health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Given JSON input:
    // {"Lives":3, "Health":0.8}
    // the Load function will change the object on which it is called such that
    // Lives == 3 and Health == 0.8
    // the 'playerName' field will be left unchanged
}

```

### JsonUtility.FromJson

PS:

1. Create an object from its JSON representation.
2. Using the Unity serializer.
3. A plain class/struct marked with the Serializable attribute.
4. Unsupport private fields or fields marked with the NonSerialized attribute.
5. Unsupport classes derived from UnityEngine.Object(such as MonoBehaviour or ScriptableObject)

```c#
public static T FromJson(string json);
/*
 * json: The JSON representation of the object
 * <return> T An instance of the object
 */
```

#### Test

Data Structure:

```c#

[System.Serializable]
public class MyData
{
    public MyDataItem[] Items;
}

[System.Serializable]
public class MyDataItem
{
    public int Lives;
    public float Health;
}

```

Data Test Class:

```c#
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public string ShowText;
    public string PlayerName;
    private MyData _loadedData;
    public int Lives;

    public float Health;

    

    public void ParseItemJson()
    {
        string itemJson = File.ReadAllText("Assets\\Test.json");
        _loadedData = JsonUtility.FromJson<MyData>(itemJson);
    }

    public void ShowAllJsonData()
    {
        ShowText = "";
        for (int i = 0; i < _loadedData.Items.Length; ++i)
        {
            ShowText += _loadedData.Items[i].Lives + ":" + _loadedData.Items[i].Health + "\n";
        }
        Debug.Log(ShowText);    
    }

    private void Awake()
    {
        ParseItemJson();
    }

    // Start is called before the first frame update
    void Start()
    {
        ShowAllJsonData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
 /* Given JSON input:
    {
  "Items": [
    {
      "Lives": 3,
      "Health": 0.8
    },
    {
      "Lives": 5,
      "Health": 7.1
    }
  ]
  */
}
}

```

### JsonUtility.ToJson

PS:

1. Generate a JSON representation of the public fields of an object.
2. Using the Unity serializer.
3. Must be a MonoBehaviour, ScriptableObject, or plain class/struct with the Serializable attribute applied.
4. Unsupport private fields, static fields, and fields with the NonSerialized attribute applied.

```C#
public static string ToJson(object obj);
public static string ToJson(object obj,bool prettyPrint);

/*
	obj: The object to convert to JSON form
	prettyPrint: If true,the output for readability. If false, format the output for minimum size. Default is false.
	
	<return> string (The object's data in JSON format)
*/
```



#### Test

```c#
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public string PlayerName="中文测试";
    public int Lives=5;
    public float Health=6.0f;
    public string Name="English Test";

    public string SaveToString()
    {
        return JsonUtility.ToJson(this,true);
    }
    

    

    private void Awake()
    {
        PlayerName="中文测试";
        Lives=5;
        Health=6.0f;
        Name="English Test";
    }

    // Start is called before the first frame update
    void Start()
    {
        
        string temp= SaveToString();
        File.WriteAllText("Assets\\Test.json",temp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /*
    JSON output:
    {
    "PlayerName": "中文测试",
    "Lives": 5,
    "Health": 6.0,
    "Name": "English Test"
	}
    
    */
}

```

