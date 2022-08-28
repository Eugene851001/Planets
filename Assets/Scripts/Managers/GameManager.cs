using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MainMenu,
    Tutorial,
    Run,
    Inventory,
    GameOver,
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _helpPanel;
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private GameObject _gameOverPanel;

    public static GameManager Instance;

    public GameState State { get; private set; }

    private void Awake()
    {
        Instance = this;
        State = GameState.MainMenu;

        UpdateState(State);
    }

    public void UpdateState(GameState newState)
    {
        State = newState;

        Time.timeScale = State == GameState.Run ? 1 : 0;

        _mainMenuPanel.SetActive(State == GameState.MainMenu);
        _helpPanel.SetActive(State == GameState.Tutorial);
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
