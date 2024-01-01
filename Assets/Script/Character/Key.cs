using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    //[SerializeField] private AudioSource collectItem;

    //public static event 
    public bool hasTriggered { get; private set; }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !hasTriggered)
        {
           // collectItem.Play();
            hasTriggered = true;
            // given object to inventory
            Destroy(gameObject); 
        }
    }
}
