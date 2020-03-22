# 常用方法

## 1 Json中string型数据转换成enum型数据

```c#
public class ItemData
    {
        public int id;
        public string name;
        public string type;
        public string quality;
        public string description;
        public int capacity;
        public int buyPrice;
        public int sellPrice;
        public int hp;
        public int mp;
        public string sprite;
        public int strength;
        public int intellect;
        public int agility;
        public int stamina;
        public string equipType;
    }

public enum ItemType
    {
        ConsumableItem,
        EquipmentItem,
        TaskItem,
        WeaponItem,
        MaterialItem
    }


ItemType type=(ItemType)System.Enum.Parse(typeof(ItemType),JSONObject.string);


```

