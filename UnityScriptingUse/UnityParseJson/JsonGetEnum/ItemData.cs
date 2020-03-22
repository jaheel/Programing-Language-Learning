
    [System.Serializable]
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
    
    [System.Serializable]
    public class ItemDataSet
    {
        public ItemData[] items;
    }
    [System.Serializable]
    public enum ItemType
    {
        ConsumableItem,
        EquipmentItem,
        TaskItem,
        WeaponItem,
        MaterialItem
    }
    [System.Serializable]
    public enum ItemQuality
    {
        Common, //一般
        Uncommon, //不寻常
        Rare, //稀有
        Epic, //史诗
        Legendary //传奇
    }
    [System.Serializable]
    public enum EquipmentType
    {
        None,//不能装备
        Head,//头部
        Neck,//脖子
        Ring,//戒指
        Leg,//腿部
        Chest,//胸部
        Bracer,//护腕
        Boots,//鞋子
        Shoulder,//肩膀
        Belt,//腰带
        OffHand//副手
    }