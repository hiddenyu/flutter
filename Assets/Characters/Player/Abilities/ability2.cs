using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ability2 : MonoBehaviour
{
    GameObject player;
    playerController pc;
    public float dashSpeed = 3f;

    public float dashTime = 0.1f;
    float curDashTime;
    bool canDash = true;

    void Start() {
        player = GameObject.Find("Player");
        pc = player.GetComponent<playerController>();
    }

    void Update() {
        if (gameManager.Instance.currentState == gameManager.gameStates.RUNNING) {
            tryDash();
        }
    }

    void tryDash() {
        if (canDash) {
            if (Keyboard.current.spaceKey.wasPressedThisFrame) {
                Vector2 direction = pc.movementInput;
                StartCoroutine(Dash(direction));
            }
        }
    }

    IEnumerator Dash(Vector2 direction) {
        canDash = false;
        curDashTime = dashTime;

        // start dashing
        while (curDashTime > 0f) {
            curDashTime -= Time.deltaTime;
            if (direction == new Vector2(0, 0)) {
                direction = pc.lastDirection;
            }
            pc.rb.velocity = direction * dashSpeed;

            yield return null;
        }

        // stop dashing
        pc.rb.velocity = new Vector2(0, 0);
        canDash = true;
    }

}
