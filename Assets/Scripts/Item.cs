using UnityEngine;

public class Item {

    public enum ItemType {
        Weapon,
        Potion,
        Armor,
    }

    public ItemType itemType;
    public int amount;

}