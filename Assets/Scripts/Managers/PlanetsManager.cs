using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts;

public class PlanetsManager : MonoBehaviour
{
    [SerializeField] private GameObject earth;
    [SerializeField] private GameObject mars;

    private Dictionary<string, GameObject> planetsDict;
    private string activePlanetName;

    public string ActivePlanetName => activePlanetName;
    public GameObject ActivePlanet => planetsDict[activePlanetName];

    public static PlanetsManager Instance { get; private set; }

    public static event Action<GameObject, GameObject> OnPlanetChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        planetsDict = new Dictionary<string, GameObject>()
        {
            [Constants.Planets.Earth] = earth,
            [Constants.Planets.Mars] = mars,
        };

        activePlanetName = Constants.Planets.Earth;
    }

    public void ChangePlanet(string planetName)
    {
        if (planetsDict.ContainsKey(planetName) && planetName != activePlanetName)
        {
            string oldPlanetName = activePlanetName;
            activePlanetName = planetName;
            OnPlanetChanged?.Invoke(planetsDict[oldPlanetName], planetsDict[activePlanetName]);
        }
    }
}
