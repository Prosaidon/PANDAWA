using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 7;
    private float jumpPower = 13;
    private bool isGrounded;
    private Animator animator;
    private bool isJumping = false;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(x, 0);

        if (x != 0 && !isJumping)
        {
            SetAnimParam(true, false);
        }
        if (x == 0 && !isJumping)
        {
            SetAnimParam(false, false);
        }
        transform.Translate(direction * Time.deltaTime * speed);

        if (x < 0)
        {
            FaceDirection(false);
        }
        if (x > 0)
        {
            FaceDirection(true);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isJumping)
        {
            SetAnimParam(false, true);
            Vector2 direction = new Vector2(0, 1);
            rb.velocity = direction * jumpPower;
            isJumping = true;  // tambahkan ini untuk mengendalikan isJumping
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGrounded = true;
            Debug.Log("isGrounded");
            isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGrounded = false;
            Debug.Log("isNotGrounded");
        }
    }

    private void FaceDirection(bool isFacingRight)
    {
        if (isFacingRight)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void SetAnimParam(bool isRunning, bool isJumping)
    {
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);
    }
}
