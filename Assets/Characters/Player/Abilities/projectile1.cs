using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile1 : MonoBehaviour
{
    GameObject player;
    public int damage = 1;
    public float fallOffRange = 2.5f;
    public float distance;

    void Start() {
        player = GameObject.Find("Player");
    }

    void Update() {
        if (gameManager.Instance.currentState == gameManager.gameStates.RUNNING && player != null) {
            checkFallOff();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name != "Player") {
            if (collision.GetComponent<characterHealth>() != null) {
                collision.GetComponent<characterHealth>().changeHealth(damage);
                Destroy(gameObject);

            }
        }
    }

    void checkFallOff() {
        Vector2 playerPosition = player.transform.position;
        Vector2 curPosition = transform.position;
        distance = (curPosition - playerPosition).magnitude;
        if (distance >= fallOffRange) {
            Destroy(gameObject);
        }
    }
}
