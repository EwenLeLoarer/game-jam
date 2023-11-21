using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public Dictionary<InventoryItemData, int> Items = new();

    public Transform itemContent;
    public GameObject inventoryItem;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        Instance = this;
    }

    public void Add(InventoryItemData item)
    {
        if (Items.ContainsKey(item))
            Items[item] += 1;
        else
            Items.Add(item, 1);
    }

    public void Remove(InventoryItemData item)
    {
        if (Items[item] == 1)
            Items.Remove(item);
        if (Items[item] != 1)
            Items[item] -= 1;
    }

    public void ListItems()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in Items)
        {
            var obj = Instantiate(inventoryItem, itemContent);
            var itemName = obj.transform.Find("ItemName").gameObject.GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").gameObject.GetComponent<Image>();

            itemName.text = item.Key.ItemName;
            itemName.text += " x" + item.Value;
            itemIcon.sprite = item.Key.ItemIcon;
        }
    }


}
