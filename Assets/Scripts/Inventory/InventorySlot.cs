using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI StackSize;
    public Image Icon;

    public void Draw(InventoryItem item)
    {
        SetEnable(true);
                      
        Name.text = item.ItemData.Name;
        StackSize.text = item.StackSize.ToString();
        Icon.sprite = item.ItemData.Icon;
    }

    public void Clear()
    {
        SetEnable(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetEnable(bool enable)
    {
        Name.enabled = enable;
        StackSize.enabled = enable;
        Icon.enabled = enable;
    }
}
