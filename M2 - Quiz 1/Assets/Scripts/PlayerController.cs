using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffSet = 0.05f;
    public ContactFilter2D movementFilter;

    Vector2 MovementInput;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (MovementInput != Vector2.zero)
        {   
            bool success = TryMove(MovementInput);
            if (!success)
            {
                success = TryMove(new Vector2(MovementInput.x, 0));
                if (!success)
                {
                    success = TryMove(new Vector2(0, MovementInput.y));
                }

            }
            animator.SetBool("isMoving", success);
            if (success)
            {
                AudioManager.instance.PlayFootsteps();
            }
            else
            {
                AudioManager.instance.StopFootsteps();
            }
        }
        else
        {
            animator.SetBool("isMoving", false);
            AudioManager.instance.StopFootsteps();
        }

        if (MovementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }else if (MovementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    private bool TryMove(Vector2 direction)
    {
        int count = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffSet);
        if (count == 0)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        } else
        {
            return false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        MovementInput = movementValue.Get<Vector2>();
    }

}
