using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class enemyManager : MonoBehaviour
{
    public int waveNumber = 1;
    int enemyCount = 0;
    float spawnRate = 1f;
    public GameObject enemyPrefab;
    public GameObject enemyMother;
    public GameObject player;
    public Tilemap map;
    Vector3 mapSize;

    // Start is called before the first frame update
    void Start()
    {
        map.CompressBounds();
        mapSize = map.size;

        enemyCount = waveNumber * 5;

        StartCoroutine(spawnRoutine());
    }

    IEnumerator spawnRoutine() {
        while (enemyMother.transform.childCount < enemyCount) {
            spawnEnemy();
            yield return new WaitForSeconds(spawnRate);
        }

    }

    void spawnEnemy() {
        GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(0, 0.16f*mapSize.x), Random.Range(-0.16f*mapSize.y, 0), 0), Quaternion.identity);
        newEnemy.transform.parent = enemyMother.transform;
    }
}
