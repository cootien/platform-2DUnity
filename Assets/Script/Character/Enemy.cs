using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider) // isTrigger 
    {
        Debug.Log(collider.gameObject.name);

        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("playerEnter");
            anim.Play("enemyAttack");
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("playerExit");
            anim.Play("enemyIdle");
        }
    }

}
