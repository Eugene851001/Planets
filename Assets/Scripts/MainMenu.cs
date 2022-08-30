using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnButtonStart()
    {
        GameManager.Instance.UpdateState(GameState.Run);
    }

    public void OnHelp()
    {
        GameManager.Instance.UpdateState(GameState.Tutorial);
    }

    public void OnReturn()
    {
        GameManager.Instance.UpdateState(GameState.MainMenu);
    }

    public void OnQuit()
    {
        Application.Quit(0);
    }
}
