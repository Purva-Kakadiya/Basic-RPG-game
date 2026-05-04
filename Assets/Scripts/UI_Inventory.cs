using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour {

    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Transform inventoryGrid;
    [SerializeField] private GameObject itemSlotPrefab;

    private Inventory inventory;
    private const int MAX_INVENTORY_SLOTS = 32;

    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    public void AddItemToInventory() {
        Instantiate(itemPrefab, inventoryGrid);
    }

    public void RefreshInventoryItems() { 
        for(int i = 1; i <= MAX_INVENTORY_SLOTS; i++) {
            RectTransform itemRect = Instantiate(itemSlotPrefab, inventoryGrid).GetComponent<RectTransform>();
            inventoryGrid.gameObject.SetActive(true);
        }
        //foreach(Item item in inventory.GetItemList()) {
        //    RectTransform itemRect = Instantiate(itemSlotPrefab, inventoryGrid).GetComponent<RectTransform>();
        //    inventoryGrid.gameObject.SetActive(true);
        //} 
    }

}