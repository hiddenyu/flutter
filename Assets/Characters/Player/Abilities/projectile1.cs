using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile1 : MonoBehaviour
{
    CircleCollider2D cc;
    GameObject player;
    public int damage = 1;
    public int fallOffRange = 10;
    public float distance;

    void Start() {
        player = GameObject.Find("Player");
        cc = GetComponent<CircleCollider2D>();
        cc.isTrigger = true;
    }

    void Update() {
        checkFallOff();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        print(collision.name);
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
