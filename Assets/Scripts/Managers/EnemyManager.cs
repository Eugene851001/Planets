using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject planet;
    [SerializeField] private GameObject enemyPrefab;

    private List<Enemy> enemies = new List<Enemy>();

    private NoSpamAction _spawn;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        //_spawn = new NoSpamAction(5000, () => Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        _spawn?.Run();
    }

    private Enemy Spawn()
    {
        var enemyObj = Instantiate(enemyPrefab);
        var enemy = enemyObj.GetComponent<Enemy>();

        float zenit = 90;
        float azimut = 80;

        enemy.InitPlanet(planet);
        enemy.InitLocation(zenit, azimut);

        enemies.Add(enemy);

        return enemy;
    }
}
