using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class enemyManager : MonoBehaviour
{
    public int enemyCount;
    float spawnRate = 0.5f;
    int spawnedCount = 0;
    public GameObject enemyPrefab;
    public GameObject enemyMother;
    public GameObject player;
    public Tilemap map;
    Vector3 mapSize;
    gameManager gm;

    void Start()
    {
        gm = gameManager.Instance;
        if (gm.currentState == gameManager.gameStates.RUNNING) {
            enemyCount = gm.getEnemyCount();

            map.CompressBounds();
            mapSize = map.size;
            StartCoroutine(spawnRoutine());
        }
    }

    public IEnumerator spawnRoutine() {
        spawnedCount = 0;
        while (spawnedCount < enemyCount) {
            spawnEnemy();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    public void spawnEnemy() {
        GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(0, 0.16f*(mapSize.x-5)), Random.Range(-0.16f*(mapSize.y-5), 0), 0), Quaternion.identity);
        newEnemy.transform.parent = enemyMother.transform;
        spawnedCount += 1;
    }
}
