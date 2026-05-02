using UnityEngine;
using System.Collections.Generic;

public class Inventory {

    private List<Item> itemList;

    public Inventory() {
        itemList = new List<Item>();

    }

    public void AddItem(Item item) {
        itemList.Add(item);
    }

    public int GetItemCount() {
        return itemList.Count;
    }

    public List<Item> GetItemList() {
        return itemList;
    }

}