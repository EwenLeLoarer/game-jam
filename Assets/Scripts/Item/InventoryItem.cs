using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class InventoryItem : MonoBehaviour
{
    public InventoryItemData Data { get; private set; }
    public int StackSize { get; private set; }

    public InventoryItem(InventoryItemData source)
    {
        Data = source;
    }

   public void AddToStack()
    {
        StackSize++;    
    }

    public void RemoveFromStack()
    {
        StackSize--;
    }
}
