using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class respawnButton : MonoBehaviour
{
    // Button rb;
    void Start()
    {
        // rb = GetComponent<Button>();
    }

    void Update() {
        if (gameManager.Instance.currentState == gameManager.gameStates.RESPAWN) {
            gameObject.SetActive(true);
        }
        else {
            gameObject.SetActive(false);
        }
    }
}
