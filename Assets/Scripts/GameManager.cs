using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Run,
    Inventory,
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryPanel;

    public static GameManager Instance;

    public GameState State { get; private set; }

    private void Awake()
    {
        Instance = this;
        State = GameState.Run;

        UpdateState(State);
    }

    public void UpdateState(GameState newState)
    {
        State = newState;
        _inventoryPanel.SetActive(State == GameState.Inventory);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
