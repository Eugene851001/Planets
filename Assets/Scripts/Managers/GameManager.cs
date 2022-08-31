using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

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
    [SerializeField] private GameObject _playerInfoPanel;

    public static GameManager Instance;

    public GameState State { get; private set; }

    public static Action<GameState, GameState> OnStateChanged;

    private void Awake()
    {
        Instance = this;
        State = GameState.MainMenu;

        UpdateState(State);
    }

    public void UpdateState(GameState newState)
    {

        if (newState == GameState.MainMenu && State == GameState.GameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        var oldState = State;
        State = newState;

        Time.timeScale = State == GameState.Run ? 1 : 0;

        _playerInfoPanel.SetActive(State == GameState.Run);
        _mainMenuPanel.SetActive(State == GameState.MainMenu);
        _helpPanel.SetActive(State == GameState.Tutorial);
        _inventoryPanel.SetActive(State == GameState.Inventory);
        _gameOverPanel.SetActive(State == GameState.GameOver);

        OnStateChanged?.Invoke(oldState, State);
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
