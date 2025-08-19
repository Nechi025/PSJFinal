using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private Vector2 moveDirection = Vector2.zero;

    private Vector2 lastDirection = Vector2.right;

    public GameObject attackZone;

    private int jumpsRemaining = 1;
    public int maxJumps = 2;

    public Animator animator;
    private bool Falling;
    private float currentSpeed;
    private bool Grounded;
    private SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteRendererSwipe;

    private bool isStunned = false;
    public float stunDuration = 1.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        Collider2D playerCollider = GetComponent<Collider2D>();
        Collider2D attackCollider = attackZone.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(playerCollider, attackCollider, true);
    }

    void Update()
    {
        //Si esta stunneado cancela todo movimiento
        if (isStunned) return;

        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);

        currentSpeed = Mathf.Abs(rb.velocity.x);
        Falling = rb.velocity.y < -0.01f && !Grounded; 

        if (animator != null)
        {
            animator.SetFloat("currentSpeed", currentSpeed);
            animator.SetBool("Falling", Falling);
            animator.SetBool("Grounded", Grounded);

           
            if (Grounded)
            {
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsDoubleJumping", false);
            }
        }
    }

    public void Move(Vector2 direction)
    {
        if (isStunned) return;

        moveDirection = new Vector2(direction.x, 0); //Solo se mueve en el eje X
        if (direction != Vector2.zero)
            lastDirection = direction.normalized;

        if (direction.x != 0)
        {
            lastDirection = direction.normalized;

            if (spriteRenderer != null)
                spriteRenderer.flipX = (direction.x < 0);
            if (spriteRendererSwipe != null)
                spriteRendererSwipe.flipX = (direction.x < 0);
        }

    }

    public void Jump()
    {
        if (isStunned) return;

        if (jumpsRemaining > 0)
        {
            bool wasGrounded = Grounded;

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            if (animator != null)
            {
                if (wasGrounded) //Salta   
                {
                    animator.SetBool("IsJumping", true);
                    animator.SetBool("IsDoubleJumping", false);
                }
                else if (!wasGrounded && jumpsRemaining == 1) //Segundo Salto
                {
                    animator.SetBool("IsDoubleJumping", true);
                    animator.SetBool("IsJumping", false);
                }
                if (Falling || Grounded)
                {   
                    animator.SetBool("IsDoubleJumping", false); 
                }

            }

            jumpsRemaining--;
            Grounded = false;
        }
    }

    public void Parry()
    {
        if (isStunned) return;

        if (animator != null)
            animator.SetTrigger("Attack");
        StartCoroutine(DoAttack());
    }
    public void ParryBoost()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce * 0.8f);
    }

    //Detecta la colisión con el suelo para reactivar salto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            jumpsRemaining = maxJumps;
            Grounded = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(ApplyStun());
            animator.SetBool("Stunned", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Grounded = false;
        }
    }

    IEnumerator ApplyStun()
    {
        isStunned = true;
        rb.velocity = Vector2.zero;

        yield return new WaitForSeconds(stunDuration);
        animator.SetBool("Stunned", false);
        isStunned = false;
    }

    IEnumerator DoAttack()
    {
        //Aparece la zona de ataque delante del player
        if (attackZone != null)
        {
            Vector3 offset = new Vector3(lastDirection.x, lastDirection.y, 0f);
            attackZone.transform.localPosition = offset.normalized * 0.7f;
            attackZone.GetComponent<SpriteRenderer>().enabled = true;
            attackZone.GetComponent<Collider2D>().enabled = true;
        }

        yield return new WaitForSeconds(0.2f);

        if (attackZone != null)
        {
            attackZone.GetComponent<SpriteRenderer>().enabled = false;
            attackZone.GetComponent<Collider2D>().enabled = false;
        }
    }
}
