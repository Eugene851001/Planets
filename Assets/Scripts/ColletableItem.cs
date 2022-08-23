using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColletableItem : MonoBehaviour
{
    public static event Action<ItemData> OnCollect;

    [SerializeField] private ItemData _itemData;

    public void Collect()
    {
        Destroy(gameObject);
        OnCollect?.Invoke(_itemData);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Collect();
        }
    }
}
