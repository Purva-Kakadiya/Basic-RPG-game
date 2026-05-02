using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour {

    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Transform inventoryGrid;
    [SerializeField] private GameObject itemSlotPrefab;

    private Inventory inventory;

    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    public void AddItemToInventory() {
        Instantiate(itemPrefab, inventoryGrid);
    }

    public void RefreshInventoryItems() { 
        foreach(Item item in inventory.GetItemList()) {
            RectTransform itemRect = Instantiate(itemSlotPrefab, inventoryGrid).GetComponent<RectTransform>();
            inventoryGrid.gameObject.SetActive(true);
        } 
    }

}