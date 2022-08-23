using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    private const int MaxStackSize = 16;

    public ItemData ItemData;
    public int StackSize;

    public InventoryItem(ItemData itemData)
    {
        this.ItemData = itemData;
        StackSize = 1;
    }

    public void Add()
    {
        if (StackSize < MaxStackSize)
        {
            StackSize++;
        }
    }

    public void Remove()
    {
        if (StackSize > 0)
        {
            StackSize--;
        }
    }

    public void Add(int count)
    {
        if (StackSize + count <= MaxStackSize)
        {
            StackSize += count;
        }
    }

    public void Remove(int count)
    {
        if (StackSize - count >= 0)
        {
            StackSize -= count;
        }
    }
}
