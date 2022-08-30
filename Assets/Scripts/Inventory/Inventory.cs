using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public static event Action<IEnumerable<InventoryItem>> OnInventoryChanged;
    public Dictionary<ItemData, InventoryItem> _itemsDict = 
        new Dictionary<ItemData, InventoryItem>();

    private ILogger logger;

    private void Awake()
    {
        ColletableItem.OnCollect += Add;
        logger = LoggerFactory.Instance.GetLogger();
    }

    private void OnDestroy()
    {
        ColletableItem.OnCollect -= Add;
    }

    public void Add(ItemData item)
    {
        logger.Log($"Added item to inventory: {item.Name}");

        if (_itemsDict.ContainsKey(item))
        {
            _itemsDict[item].Add();
        }
        else
        {
            _itemsDict.Add(item, new InventoryItem(item));
        }

        OnInventoryChanged?.Invoke(_itemsDict.Values);
    }
}
