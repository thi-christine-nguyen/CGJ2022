using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class characterBehaviour : MonoBehaviour
{
    private float horizontal;
    private float speed = 5f;
    private float jumpingPower = 7f;
    private bool isFacingRight = false;

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator anim;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            anim.SetBool("isRunning", false);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            anim.SetBool("isRunning", false);
        }

        if (rb.velocity.x > 0f || rb.velocity.x < 0f)
        {
            anim.SetBool("isRunning", true);
        }
        else if (rb.velocity.x == 0f)
        {
            anim.SetBool("isRunning", false);
        }

        if (horizontal > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (horizontal < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
      
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tree")
        {
            float valueX = collision.gameObject.transform.position.x;
            float valueY = collision.gameObject.transform.position.y;

            gameObject.transform.position = new Vector3(valueX, valueY + 1, gameObject.transform.position.z);
        }
    }
}
