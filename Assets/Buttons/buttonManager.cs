using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonManager : MonoBehaviour
{
    GameObject player;
    GameObject rb;

    void Start() {
        player = GameObject.Find("Player");
        rb = GameObject.Find("RespawnButton");
    }

    void Update()
    {
        checkRespawnState();
        updateRespawnButton();
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
}
