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
}
