using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    private const int CellsCount = 5;
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private GameObject _slotPrefab;
    private List<InventorySlot> _slots = new List<InventorySlot>();
    private List<InventoryItem> _inventoryItems = new List<InventoryItem>();

    private void Awake()
    {
        Inventory.OnInventoryChanged += Draw;
        GameManager.OnStateChanged += HandleShowInventory;
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
        _inventoryItems = new List<InventoryItem>();
    }

    private void HandleShowInventory(GameState oldState, GameState newState)
    {
        if (oldState == GameState.Run && newState == GameState.Inventory)
        {
            DrawLast();
        }
    }

    public void DrawLast()
    {
        Draw(_inventoryItems);
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
                _inventoryItems.Add(items.ElementAt(i));
            }
        }
    }

    private InventorySlot CreateSlot()
    {
        var slotObject = Instantiate(_slotPrefab);
        slotObject.transform.SetParent(_inventoryPanel.transform);
        var slot = slotObject.GetComponent<InventorySlot>();

        slot.Clear();
        return slot;
    }
}
