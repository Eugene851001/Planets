using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private NoSpamAction _handleInventory;

    private void Awake()
    {
        _handleInventory = new NoSpamAction(200, HandleInventory);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            HandleInventory(); 
        }
    }

    void HandleInventory()
    {
        if (GameManager.Instance.State == GameState.Run)
        {
            GameManager.Instance.UpdateState(GameState.Inventory);
        }
        else
        {
            GameManager.Instance.UpdateState(GameState.Run);
        }
    }
}
