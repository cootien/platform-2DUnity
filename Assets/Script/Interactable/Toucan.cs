using UnityEngine;

public class Toucan : MonoBehaviour
{ 
    public DialogueTrigger trigger;
    public Animator anim;
    public string triggerAnimState;
    public string triggerExitAnimState;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.Play(triggerAnimState);
        }
    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            anim.Play(triggerExitAnimState);
        }
    }
}
