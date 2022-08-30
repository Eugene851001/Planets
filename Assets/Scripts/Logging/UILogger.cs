using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class UILogger : MonoBehaviour, ILogger
{
    private const int MessagesShow = 2;
    [SerializeField] private TextMeshProUGUI _logText;

    private List<string> messages = new List<string>();

    public void InvalidateText()
    {
        var result = new StringBuilder();
        for (int i = 0; i < MessagesShow && i< messages.Count; i++)
        {
            result.AppendLine(messages[messages.Count - 1 - i]);
        }

        _logText.text = result.ToString();
    }

    public void Log(string message)
    {
        messages.Add(message);

        InvalidateText();
    }
}
