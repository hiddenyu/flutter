using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newWaveButton : MonoBehaviour
{
    void Update() {
        if (gameManager.Instance.currentState == gameManager.gameStates.NEWWAVE) {
            gameObject.SetActive(true);
        }
        else {
            gameObject.SetActive(false);
        }
    }
}
