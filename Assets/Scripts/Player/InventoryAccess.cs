using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAccess : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.gameObject.CompareTag("Collectable"))
            return;
        var item = collision.gameObject.GetComponent<ItemController>();  
        Inventory.Instance.Add(item.item);
        Inventory.Instance.ListItems();
        
        Destroy(collision.gameObject);
    }
}
