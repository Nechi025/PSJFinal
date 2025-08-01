using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private bool isGrounded = true;
    private Vector2 moveDirection = Vector2.zero;

    private Vector2 lastDirection = Vector2.right;

    public GameObject attackZone;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }

    public void Move(Vector2 direction)
    {
        moveDirection = new Vector2(direction.x, 0); // solo mover eje X
        if (direction != Vector2.zero)
            lastDirection = direction.normalized;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    public void Parry()
    {
        StartCoroutine(DoAttack());
    }

    // Detecta la colisión con el suelo para reactivar salto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    IEnumerator DoAttack()
    {
        // Posicionar zona de ataque en la dirección actual
        if (attackZone != null)
        {
            Vector3 offset = new Vector3(lastDirection.x, lastDirection.y, 0f);
            attackZone.transform.localPosition = offset.normalized * 0.5f; // distancia frente al jugador
            attackZone.SetActive(true);
        }

        yield return new WaitForSeconds(0.2f);

        if (attackZone != null)
        {
            attackZone.SetActive(false);
        }
    }
}
