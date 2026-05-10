using NUnit.Framework.Constraints;
using UnityEngine;

public class Item {

    public enum ItemType {
        Sword,
        Dagger,
        Potion,
        Armor,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite() {
        switch (itemType) {
            default:
            case ItemType.Sword:
                return ItemAssets.Instance.swordSprite;
            case ItemType.Potion:
                return ItemAssets.Instance.potionSprite;
            case ItemType.Armor:
                return ItemAssets.Instance.armorSprite;
            case ItemType.Dagger:
                return ItemAssets.Instance.daggerSprite;

        }
    }

}