using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonManager : MonoBehaviour
{
    GameObject player;
    GameObject rb;
    GameObject enemyMother;
    GameObject nwb;
    int prevWave = 1;

    void Start() {
        player = GameObject.Find("Player");
        rb = GameObject.Find("RespawnButton");
        enemyMother = GameObject.Find("EnemyMother");
        nwb = GameObject.Find("NewWaveButton");
    }

    void Update()
    {
        print(gameManager.Instance.curWave);
        print(gameManager.Instance.getEnemyCount());
        checkRespawnState();
        updateRespawnButton();
        checkWaveState();
        updateNewWaveButton();
    }

    void checkRespawnState() {
        if (player == null) {
            gameManager.Instance.currentState = gameManager.gameStates.RESPAWN;
        }
    }

    void updateRespawnButton() {
        if (gameManager.Instance.currentState == gameManager.gameStates.RESPAWN) {
            rb.SetActive(true);
        }
    }

    void checkWaveState() {
        if (enemyMother.transform.childCount == 0 && gameManager.Instance.nextWaveStarted != true) {
            gameManager.Instance.currentState = gameManager.gameStates.NEWWAVE;
        }
    }

    void updateNewWaveButton() {
        if (gameManager.Instance.currentState == gameManager.gameStates.NEWWAVE) {
            nwb.SetActive(true);
        }
    }
}
