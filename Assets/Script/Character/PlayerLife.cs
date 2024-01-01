using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //load Scene

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] private AudioSource deathEffect; 

    public bool isDead { get; private set; }
    public GameManager gameManager;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isDead = false; 
    }
    private void Update()
    {
        if (isDead)
        {
            return;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Check") || collision.gameObject.CompareTag("Trap"))
        {
            Debug.Log($"{collision.gameObject.name}"); // export gameObject name
            Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") )
        {
            //Debug.Log($"{collision.gameObject.name}"); // export gameObject name
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return; // if isDead is true, return

        rb.bodyType = RigidbodyType2D.Static; // Disable the Rigidbody2D component
        isDead = true;

        float animationLength = anim.GetCurrentAnimatorClipInfo(0)[0].clip.length;


        Debug.Log($"waiting for: {animationLength}");
        deathEffect.Play();
        anim.Play("PlayerDeath");
         
        Invoke("Reload", animationLength + 1f);
    }

    private void Reload()
    {
        Debug.Log("Reloading");
        Scene currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;
        SceneManager.LoadScene(currentSceneName);
    }


}
