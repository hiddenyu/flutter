using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ability3 : MonoBehaviour
{
    playerController pc;
    public GameObject aoeField;
    public float spellTime = 1f;

    void Start()
    {
        pc = GetComponent<playerController>();
    }

    void OnAOE() {
        if (gameManager.Instance.currentState == gameManager.gameStates.RUNNING && pc.canAOE) {
            // pc.canMove = false;
            GameObject aoe = Instantiate(aoeField, new Vector3(transform.position.x, (float)(transform.position.y - 0.08), transform.position.z), Quaternion.identity);
            aoe.transform.parent = GameObject.Find("AbilityMother").transform;
            Destroy(aoe, spellTime);
            // Invoke("unlockMovement", spellTime);
            pc.canAOE = false;
        }
    }

    void unlockMovement() {
        pc.canMove = true;
    }
}