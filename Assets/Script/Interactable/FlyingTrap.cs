using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class FlyingTrap : MonoBehaviour
{
    public float speed = .8f; // Speed of the movement
    public float height = 10.0f; // Height the object will move to
    private bool isMoving = false; // flag to check if the object has moved

    // fly up when Up key is press
    // fly down when Down key is press
    // fly left when Left key is press
    void Update()
    {
        if (!isMoving && Input.GetKeyDown(KeyCode.Space))
        {
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
        isMoving = true; // Set the flag to true, so we know we are moving

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
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 1 * Time.deltaTime);

            // Wait for the next frame
            yield return null;
        }

        isMoving = false; // Set the flag to false, so we know we are not moving
    }
}
