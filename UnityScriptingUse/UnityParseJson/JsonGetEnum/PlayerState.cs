using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public ItemDataSet ItemDataSet;

    public void ParseJson()
    {
        string itemJson = File.ReadAllText("Assets\\Test.json");
        ItemDataSet = JsonUtility.FromJson<ItemDataSet>(itemJson);
        for (int i = 0; i < ItemDataSet.items.Length; i++)
        {
            ItemType type=(ItemType)System.Enum.Parse(typeof(ItemType),ItemDataSet.items[i].type);
            
            switch (type)
            {
                case ItemType.ConsumableItem:
                    Debug.Log(ItemDataSet.items[i].id + "\n"
                                                      + ItemDataSet.items[i].name + "\n"
                                                      + ItemDataSet.items[i].type + "\n"
                                                      + ItemDataSet.items[i].quality + "\n"
                                                      + ItemDataSet.items[i].description + "\n"
                                                      + ItemDataSet.items[i].capacity + "\n"
                                                      + ItemDataSet.items[i].buyPrice + "\n"
                                                      + ItemDataSet.items[i].sellPrice + "\n"
                                                      + ItemDataSet.items[i].hp + "\n"
                                                      + ItemDataSet.items[i].mp + "\n"
                                                      + ItemDataSet.items[i].sprite + "\n");
                    break;
                default:
                    break;
            }
        }
    }
    

    

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        ParseJson();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
