using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGame : MonoBehaviour
{
    // The player character
    public GameObject player;

    // The enemy character
    public GameObject enemy;

    // The collectible items
    public GameObject[] collectibles;

    // The door that can be opened with the collectibles
    public GameObject door;

    // The number of collectibles the player has collected
    private int collectiblesCollected = 0;

    void Update()
    {
        // Make the enemy follow the player
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, player.transform.position, 0.1f);

        // Check if the player has collected all of the collectibles
        if (collectiblesCollected == collectibles.Length)
        {
            // Open the door
            door.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has collided with a collectible
        for (int i = 0; i < collectibles.Length; i++)
        {
            if (other.gameObject == collectibles[i])
            {
                // Increment the collectiblesCollected counter
                collectiblesCollected++;

                // Destroy the collectible
                Destroy(collectibles[i]);

                break;
            }
        }
    }
}
