using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 StartPosition;

    private void Start()
    {
        StartPosition = transform.position; 
    }
    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if(transform.position.x < -8.85f)
        {
            transform.position = StartPosition;
        }
    }
}
