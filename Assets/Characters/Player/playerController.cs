using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    public bool canAOE = true;
    public bool canMove = true;
    public float moveSpeed = 2.5f;
    public ContactFilter2D movementFilter;
    public float collisionOffset = 0.05f;
    public Vector2 lastDirection;

    public Vector2 movementInput;
    public Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (gameManager.Instance.currentState == gameManager.gameStates.RUNNING) {
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
                    rb.velocity = new Vector2(0, 0);
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
            else {
                animator.SetBool("isMoving", false);
                rb.velocity = new Vector2(0, 0);

            }
        }
        else {
            animator.SetBool("isMoving", false);
            rb.velocity = new Vector2(0, 0);
        }
    }

    private bool TryMove(Vector2 direction) {
        if (direction != Vector2.zero) {
            // count for potential collisions
            int count = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime
            );

            // if there are no collisions
            if (count == 0) {
                // rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                rb.velocity = direction * moveSpeed;
                lastDirection = direction;
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
        if (gameManager.Instance.currentState == gameManager.gameStates.RUNNING) {
            animator.SetTrigger("swordAttack");
        }
    }

    public void lockMovement() {
        canMove = false;
    }

    public void unlockMovement() {
        canMove = true;
    }
}
