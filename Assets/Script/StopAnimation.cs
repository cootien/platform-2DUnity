using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame 
    void Update()
    {

    }


    public void StopPlaying()
    {
        Animator anim = GetComponent<Animator>();
        anim.enabled = false;
    }
}