using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    // The speed at which the enemy will move
    public float speed = 1.0f;

    // The distance that the enemy will move before turning around
    public float distance = 1.0f;

    // The direction that the enemy is currently moving in
    private int direction = 1;

    void FixedUpdate()
    {
        // Move the enemy forward or backward
        transform.position += transform.right * speed * direction * Time.deltaTime;

        // Check if the enemy has reached the turning point
        if (direction == 1 && transform.position.x >= distance)
        {
            direction = -1;
        }
        else if (direction == -1 && transform.position.x <= -distance)
        {
            direction = 1;
        }
    }
}

