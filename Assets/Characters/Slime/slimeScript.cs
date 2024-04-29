using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeScript : MonoBehaviour
{
    Rigidbody2D rb;

    public ContactFilter2D movementFilter;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    public float collisionOffset = 0.05f;

    GameObject player;
    public Transform target;
    bool canMove = true;
    public int slimeDmg = 1;
    public float slimeSpeed = 0.75f;
    public float minDist = 0.16f;
    private float distance;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.Find("Player");
      if (player != null) {
        target = player.GetComponent<Transform>();
      }
      rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      if (gameManager.Instance.currentState == gameManager.gameStates.RUNNING && player != null) {
        pathFind();
      }
    }

    private bool TryMove(Vector2 direction) {
        if (direction != Vector2.zero) {
            // count for potential collisions
            int count = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                slimeSpeed * Time.fixedDeltaTime
            );

            // if there are no collisions
            if (count == 0) {
                rb.MovePosition(rb.position + direction * slimeSpeed * Time.fixedDeltaTime);
                return true;
            }
            else {
                return false;
            }
        }
    else {
        return false;
    }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
      if (collision.name == "Player") {
          collision.GetComponent<characterHealth>().changeHealth(slimeDmg);
      }
    }

  void pathFind() {
      distance = Vector2.Distance(transform.position, target.transform.position);

      direction = target.transform.position - transform.position;
      direction.Normalize();

      if (canMove) {
            // move if movement is not 0
            if (direction != Vector2.zero) {
                bool canMove = TryMove(direction);

                // if there are collisions, check x and y directions separately
                if (!canMove) {
                    // try to move with x direction
                    canMove = TryMove(new Vector2(direction.x, 0));
                }
                if (!canMove) {
                    // try to move with y direction
                        canMove = TryMove(new Vector2(0, direction.y));
                    }
            }
      }
  }
}