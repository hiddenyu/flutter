using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    bool canMove = true;
    public float moveSpeed = 1f;
    public ContactFilter2D movementFilter;
    public float collisionOffset = 0.05f;

    public Vector2 movementInput;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {
        if (canMove) {

            // move player if movement is not 0
            if (movementInput != Vector2.zero) {
                bool canMove = TryMove(movementInput);

                // if there are collisions, check x and y directions separately
                if (!canMove) {
                    // try to move with x direction
                    canMove = TryMove(new Vector2(movementInput.x, 0));
                }
                if (!canMove) {
                    // try to move with y direction
                        canMove = TryMove(new Vector2(0, movementInput.y));
                    }

                animator.SetBool("isMoving", canMove);
            }
            
            else {
                animator.SetBool("isMoving", false);
            }

            // set the sprite direction
            // if going left, flip the sprite
            if (movementInput.x < 0) {
                spriteRenderer.flipX = true;
            }
            else if (movementInput.x > 0) {
                spriteRenderer.flipX = false;
            }
        }
        
    }

    private bool TryMove(Vector2 direction) {
        if (direction != Vector2.zero) {
            // count for potential collisions
            int count = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset
            );

            // if there are no collisions
            if (count == 0) {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
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

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire() {
        animator.SetTrigger("swordAttack");
    }

    public void lockMovement() {
        canMove = false;
    }

    public void unlockMovement() {
        canMove = true;
    }
}
