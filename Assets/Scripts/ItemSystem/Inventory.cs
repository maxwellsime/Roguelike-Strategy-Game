using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ScriptableObject, IItemContainer
{
    public Item AddItem(Item item)
    {
        throw new System.NotImplementedException();
    }

    public bool HasItem(Item item)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveItem(Item item)
    {
        throw new System.NotImplementedException();
    }

    public void Swap(int indexOne, int indexTwo)
    {
        throw new System.NotImplementedException();
    }
}
