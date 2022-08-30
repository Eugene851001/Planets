using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Debug.Log(message);
    }
}
