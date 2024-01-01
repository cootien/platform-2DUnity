using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingTrap : MonoBehaviour
{
    public float speed = 1.0f; // Speed of the movement
    public float height = 10.0f; // Height the object will move to
    private bool hasMoved = false; // flag to check if the object has moved

    // fly up when Up key is press
    // fly down when Down key is press
    // fly left when Left key is press
    void Update()
    {
        if (!hasMoved && Input.GetKeyDown(KeyCode.Space) )
        {
            hasMoved = true;
            StartCoroutine(FlyUp());
        }


    }


    void OnTriggerEnter2D(Collider2D other)
    {

    }

    IEnumerator FlyUp()
    {
        // Calculate the target position
        Vector3 targetPosition = transform.position + new Vector3(0, height, 0);
        Vector3 startPosition = transform.position; // Remember the start position

        float t = 0; // This will be used in the Lerp function

        // While the object is still below the target position
        while (transform.position.y < targetPosition.y)
        {
            // Move the object upwards
            t += Time.deltaTime * speed; // Increase t based on time and speed
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            // Wait for the next frame
            yield return null;
        }

        // then fall down
        StartCoroutine(FallDown());

    }

    IEnumerator FallDown()
    {
        // Calculate the target position
        Vector3 targetPosition = transform.position - new Vector3(0, height, 0);

        // While the object is still above the start position
        while (transform.position.y > targetPosition.y)
        {
            // Move the object downwards
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 12 * Time.deltaTime);

            // Wait for the next frame
            yield return null;
        }
    }
}
