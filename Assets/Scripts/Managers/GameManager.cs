using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Run,
    Inventory,
    GameOver,
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private GameObject _gameOverPanel;

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
        _gameOverPanel.SetActive(State == GameState.GameOver);
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
