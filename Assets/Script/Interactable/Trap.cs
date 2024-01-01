using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private bool trapActivated = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;

        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Trap");
            if (!trapActivated)
            {
                spriteRenderer.enabled = true;
                trapActivated = true;
                anim.Play("spikeMoveUp");

            }
        }
    }

}