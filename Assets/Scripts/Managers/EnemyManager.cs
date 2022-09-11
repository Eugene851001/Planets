using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject planet;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject shootingEnemyPrefab;

    private List<(Vector2, GameObject)> spawnPoints;

    private List<Enemy> enemies = new List<Enemy>();

    private void Awake()
    {
        spawnPoints = new List<(Vector2, GameObject)>()
        {
           // (new Vector2(90, 80), enemyPrefab),
            //(new Vector2(20, 100), shootingEnemyPrefab),
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        //_spawn = new NoSpamAction(5000, () => Spawn());
    }

    public void Spawn()
    {
        foreach (var spawnPoint in spawnPoints)
        {
            SpawnEnemy(spawnPoint.Item1.x, spawnPoint.Item1.y, spawnPoint.Item2);
        }
    }

    private Enemy SpawnEnemy(float zenit, float azimut, GameObject prefab)
    {
        var enemyObj = Instantiate(prefab);
        var enemy = enemyObj.GetComponent<Enemy>();

        enemy.InitPlanet(planet);
        enemy.InitLocation(zenit, azimut);

        enemies.Add(enemy);

        return enemy;
    }
}
