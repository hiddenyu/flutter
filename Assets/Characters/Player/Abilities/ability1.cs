using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ability1 : MonoBehaviour
{
    playerController pc;
    public GameObject projectile;
    public int projectileForce;

    void Start() {
        pc = GetComponent<playerController>();
    }

    void OnFire() {
        if (gameManager.Instance.currentState == gameManager.gameStates.RUNNING) {
            pc.canMove = false;
            GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 curPosition = transform.position;
            Vector2 direction = (mousePosition - curPosition).normalized;
            proj.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
        }
    }
}
