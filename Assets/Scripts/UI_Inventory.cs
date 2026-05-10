using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UI_Inventory : MonoBehaviour {

    [SerializeField] private Transform itemSlotContainer;
    [SerializeField] private Transform itemSlotTemplete;

    private Inventory inventory;
    private const int maxInventorySlots = 32;

    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    public void AddItemToInventory(Item item) {
        itemSlotRectTransform = Instantiate(itemSlotTemplete, itemSlotContainer);
        itemSlotRectTransform.gameObject.SetActive(true);
    }

    public void RefreshInventoryItems() { 
        foreach(Item item in inventory.itemList) {
            itemSlotRectTransform = Instantiate(itemSlotTemplete, itemSlotContainer);
            itemSlotRectTransform.gameObject.SetActive(true);

            Transform imageTransform = itemSlotRectTransform.Find("Image");
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            Sprite sprite = item.GetSprite();
            image.sprite = sprite;
        }
    }
}

