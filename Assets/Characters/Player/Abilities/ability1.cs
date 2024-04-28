using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ability1 : MonoBehaviour
{
    public GameObject projectile1;
    public int damage;
    public int projectileForce;

    void Start() {
    }

    void OnFire() {
        GameObject projectile = Instantiate(projectile1, transform.position, Quaternion.identity);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 curPosition = transform.position;
        Vector2 direction = (mousePosition - curPosition).normalized;
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
    }
}
