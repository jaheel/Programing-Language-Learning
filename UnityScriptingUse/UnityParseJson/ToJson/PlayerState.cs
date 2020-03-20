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
}
