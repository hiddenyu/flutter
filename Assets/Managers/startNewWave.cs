using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startNewWave : MonoBehaviour
{
    public void goNextWave() {
        gameManager.Instance.curWave += 1;
        gameManager.Instance.waveEnemyCount = gameManager.Instance.getEnemyCount();
        gameManager.Instance.currentState = gameManager.gameStates.RUNNING;
        gameManager.Instance.nextWaveStarted = true;

        GameObject player = GameObject.Find("Player");
        player.transform.position = new Vector2(2, -1);

        enemyManager em = GameObject.Find("EnemyManager").GetComponent<enemyManager>();
        em.enemyCount = gameManager.Instance.getEnemyCount();
        _ = StartCoroutine(em.spawnRoutine());
        gameManager.Instance.nextWaveStarted = false;
    }
}
