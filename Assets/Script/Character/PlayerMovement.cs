using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private float dirX = 0;
    private float dirY = 0;
    [SerializeField] private float moveSpeed = 8f;
    private float jumpForce = 15f ;


    private bool isGrounded;
    private bool isJumping;
    private bool hasAppeared = false;
    private bool isJumpable; 

    public PlayerLife playerLife; 

    private string currentAnimation;

    const string idle = "PlayerIdle";
    const string running = "PlayerRun";
    const string jumping = "PlayerJump";
    const string falling = "PlayerFall";
    const string winning = "PlayerCheckPoint";
    const string appear = "PlayerAppear";

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource collectEffect;
    [SerializeField] private AudioSource appearEffect;


    private Animator anim;

    //    [SerializeField] private AndioSource jumpSoundEffect;

    private void Awake()
    {
        GameManager.LevelLoaded += OnLevelLoaded;
    }

    private void OnDestroy()
    {
        GameManager.LevelLoaded -= OnLevelLoaded;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    //-------------------------------------------------
    private void ChangeAnimationState(string newState)
    {
        if (playerLife.isDead)
        {
           // Debug.Log("Isdead = true");
            return;
        }
        if (newState == idle && !hasAppeared)
        {
            return;
        }

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName(appear))
        {
            appearEffect.Play();
            // Don't change the animation if PlayerAppear is playing
            return;
        }
        else
        {
            hasAppeared = true;
        }
        //stop the same anim from interrupting itself
        if (currentAnimation == newState) return;

        //Debug.Log($"Changing animation state to : {newState}");
        //play the new anim
        anim.Play(newState);


        //reassign the current
        currentAnimation = newState;
    }
    //---------------------------------------------------
    // function is called once per frame for every collider that touching another
    // used for continuous collision detection 
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isGrounded = true; 
        }
    }
    // function is called when this collider has begun touching another collider
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        //Debug.Log($"collided with {collision.gameObject.name}");
        if (!collision.transform.CompareTag("Ground"))
        {
            return; 
        }
        //Debug.Log($"setting is Jumping:False");
        isJumping = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isGrounded = false; 
        }
    }
    //----------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            collectEffect.Play();
            
        }
    }
    //-------------------------------------------------------

    private void Flip()
    {
        //move right -> left
        if (dirX < 0f)
        {
            //sprite.flipX = true;
            transform.localScale = new Vector2(-1, 1);
        }
        //move left => right 
        else if (dirX > 0f)
        {
            // sprite.flipX = false;
            transform.localScale = new Vector2(1, 1);
        }
    }

    private void Jump()
    {
        if (!isJumpable)
        {
            return;
        }

        ChangeAnimationState(jumping);
        isGrounded = false;
        isJumping = true;
        jumpSoundEffect.Play();
        rb.AddForce(new Vector2(0, 1f) * jumpForce, ForceMode2D.Impulse);
    }

    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxis("Vertical");
    }

    private void FixedUpdate() // tinh toan vat li - co dinh theo tung frame
    {
        if (playerLife.isDead)
        {
            //Debug.Log("IsDead is true");
            return; 
        }
        dirX = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            //Debug.Log($"Space pressed - Player is Grounded : { isGrounded}, is Jumping : {isJumping}"); 
            if( isGrounded && !isJumping)
            {
                Jump();
            }
        
        }

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);


        if (rb.velocity.y < 0)
        {
            ChangeAnimationState(falling);
        }
        else if (dirX != 0)
        {
            Flip();
            ChangeAnimationState(running);
        }
        else 
        {
            ChangeAnimationState(idle);
        }
    }

    private void OnLevelLoaded(int level)
    {
        Debug.Log("OnSceneLoaded");
        if (level == 3)
        {
            //Debug.Log("Player can't jump");
            isJumpable = false; 
        }
        else
        {
            //Debug.Log("Player can jump");
            isJumpable = true;
        }
    }
}



