using UnityEngine;

public class ItemWorld : MonoBehaviour {

    [SerializeField] private Item.ItemType itemType;

    private Item item;

    private void Awake() {
        item = new Item { itemType = itemType, amount = 1 };
    }

    public Item GetItem() {
        return item;
    }

}