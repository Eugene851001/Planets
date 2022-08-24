using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    private const int CellsCount = 4;
    [SerializeField] private GameObject _slotPrefab;
    private List<InventorySlot> _slots = new List<InventorySlot>();

    private void Awake()
    {
        Inventory.OnInventoryChanged += Draw;
    }

    private void OnDestroy()
    {
        Inventory.OnInventoryChanged -= Draw;
    }

    private void Start()
    {
        Reset();
        for (int i = 0; i < CellsCount; i++)
        {
            var slot = CreateSlot();
            _slots.Add(slot);
        }
    }

    public void Reset()
    {
        foreach (var slot in _slots)
        {
            Destroy(slot.gameObject);
        }

        _slots = new List<InventorySlot>(CellsCount);
    }

    public void Draw(IEnumerable<InventoryItem> items)
    {
        Reset();
        for (int i = 0; i < CellsCount; i++)
        {
            var slot = CreateSlot();
            _slots.Add(slot);
            if (i < items.Count())
            {
                slot.Draw(items.ElementAt(i));
            }
        }
    }

    private InventorySlot CreateSlot()
    {
        var slotObject = Instantiate(_slotPrefab);
        slotObject.transform.SetParent(this.transform);
        var slot = slotObject.GetComponent<InventorySlot>();

        slot.Clear();
        return slot;
    }
}
