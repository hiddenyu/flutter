using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aoe1 : MonoBehaviour
{
    public int damage = 3;
    public float distance;

    // GameObject player;
    // void Start() {
    //     player = GameObject.Find("Player");
    // }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name != "Player") {
            if (collision.GetComponent<characterHealth>() != null) {
                collision.GetComponent<characterHealth>().changeHealth(damage);
                }
            }
        }
}
