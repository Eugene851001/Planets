using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggerFactory : MonoBehaviour
{
    [SerializeField] private GameObject logger;

    public static LoggerFactory Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public ILogger GetLogger()
    {
        return logger.GetComponent<ILogger>();
    }
}
