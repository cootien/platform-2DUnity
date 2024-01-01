using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingTrapTest : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private float dirX = 0;
    private float dirY = 0;

    private float jumpForce = 15f;

    private Animator anim;
    private string currentAnimation;

    private bool isJumpable = true;
    private bool isGrounded = true;
    private bool isJumping= false;

    //private void Awake()
    //{
    //    GameManager.LevelLoaded += OnLevelLoaded;
    //}

    //private void OnDestroy()
    //{
    //    GameManager.LevelLoaded -= OnLevelLoaded;
    //}

    private void Start()
    {
        Debug.Log("Jump start");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    //---------------------------
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            Debug.Log("OnCollisionStay2D is Grounded");
            isGrounded = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log($"collided with {collision.gameObject.name}");
        if (!collision.transform.CompareTag("Ground"))
        {
            Debug.Log("OnCollisionEnter2D is Grounded");
            isGrounded = true;
            return;
        }

        isJumping = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            Debug.Log("OnCollisionExit2D is Grounded");

            isGrounded = false;
        }
    }
    //------------------------
    private void Jump()
    {
        if (!isJumpable)
        {
            Debug.Log("not Jumpable");
            return;
        }

        anim.Play("SpikeJump");
        isGrounded = false;
        isJumping = true;
        rb.AddForce(new Vector2(0, 1f) * jumpForce, ForceMode2D.Impulse);
        Debug.Log("Already Jump");
    }

    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"Space pressed - Spike is Grounded : {isGrounded}, is Jumping : {isJumping}");
            if (isGrounded && !isJumping)
            {
                Debug.Log("Is jumping");
                Jump();

            }

        }

        //private void OnLevelLoaded(int level)
        //{
        //    if (level == 2)
        //    {
        //        isJumpable = true;
        //    }
        //    else
        //    {
        //        isJumpable = false;
        //    }
        //}
    }
}
