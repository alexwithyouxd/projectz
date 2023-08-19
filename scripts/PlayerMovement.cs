using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 13f, jumpForce = 90f, jumpForces = 131f, jumpleft = 1f;
    public Animator animator;
    
    public TMP_Text scoretext;
    public TMP_Text jumptxt;

    private Rigidbody2D rb;
    private bool isFacingRight = true;
    private float score;
    private bool isAlive = true;
    private int sjumpcollide;

    public AudioSource jumpsound;
    private void Awake()
    {
        score = 0;
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void Start()
    {
        Cursor.visible = false;
        jumpsound = GetComponent<AudioSource>();
      


    }

    void Update()
    {
        if (isAlive)
        {
            score += Time.deltaTime * 4;
            scoretext.text = "SCORE: " + score.ToString("F");
            PlayerPrefs.SetFloat("score", score);
        }

        // Mobile controls
        if (Input.touchCount > 0)
        {
            Touch[] touches = Input.touches;
            bool leftSideTouched = false;
            bool rightSideTouched = false;

            foreach (Touch touch in touches)
            {
                if (touch.position.x < Screen.width * 0.5f)
                    leftSideTouched = true;
                else if (touch.position.x > Screen.width * 0.5f)
                    rightSideTouched = true;
            }

            if (leftSideTouched && rightSideTouched)
            {
                Jump();
                
            }
                

            else if (leftSideTouched)
            {
                MovePlayer(-1);
            }

            else if (rightSideTouched)
            {
                MovePlayer(1);
            }


        }
        else
        {
            // PC controls
            float horizontalInput = Input.GetAxis("Horizontal");
            MovePlayer(horizontalInput);

            if (Input.GetKeyDown(KeyCode.Space))
                Jump();
        }

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if ((rb.velocity.x < 0 && isFacingRight) || (rb.velocity.x > 0 && !isFacingRight))
        {
            Flip();
        }

        if (sjumpcollide > 20 && jumpleft < 1)
        {
            Handheld.Vibrate();
            jumpleft++;
            jumptxt.text = "SUPER JUMP: RECHARGED";
            jumptxt.color = Color.cyan;
            sjumpcollide = 0;
        }

        if (sjumpcollide > 10 && jumpleft == 1)
        {
            sjumpcollide = 0;
        }
    }

    void MovePlayer(float direction)
    {
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        if (jumpleft > 0)
        {
            Handheld.Vibrate();
            rb.AddForce(new Vector2(0, jumpForces), ForceMode2D.Impulse);
            jumpleft--;
            jumptxt.text = "SUPER JUMP: DISCHARGED";
            jumptxt.color = Color.black;
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isjumping", false);
            jumpsound.Play();
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            sjumpcollide++;
        }
    }
}
