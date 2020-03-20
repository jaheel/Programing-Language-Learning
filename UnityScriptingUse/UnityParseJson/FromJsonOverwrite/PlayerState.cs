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
        string itemJson = File.ReadAllText("Assets\\Test.json");
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
}
