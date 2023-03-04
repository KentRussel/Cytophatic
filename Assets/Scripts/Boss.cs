using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // The character that the enemy should follow and attack
    public GameObject target;

    // The distance at which the enemy will start attacking the target
    public float attackRange = 1.5f;

    // The amount of damage the enemy will do when it attacks
    public int attackDamage = 10;

    // The frequency at which the enemy will attack (in seconds)
    public float attackFrequency = 1.0f;

    // The amount of time that has passed since the last attack
    private float timeSinceLastAttack = 0;

    void Update()
    {
        // Make the enemy follow the target
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 0.1f);

        // Check if the enemy is within attack range of the target
        float distanceToTarget = Vector2.Distance(transform.position, target.transform.position);
        if (distanceToTarget <= attackRange)
        {
            // Attack the target if enough time has passed since the last attack
            timeSinceLastAttack += Time.deltaTime;
            if (timeSinceLastAttack >= attackFrequency)
            {
                timeSinceLastAttack = 0;
                Attack();
            }
        }
    }

    void Attack()
    {
        // Deal damage to the target
        target.GetComponent<Player>().TakeDamage(attackDamage);
    }
}

