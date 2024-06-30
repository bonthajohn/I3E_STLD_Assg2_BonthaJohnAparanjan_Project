/*
 * Author: Bontha John Aparanjan
 * Date: 30 June 2024
 * Description: This script handles enemy behavior in a game. 
 *              The enemy follows the player and takes damage when hit by bullets.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Represents an enemy that follows the player and can take damage.
/// </summary>
public class Enemy : MonoBehaviour
{
    /// <summary>
    /// The NavMeshAgent component used for pathfinding.
    /// </summary>
    public NavMeshAgent enemy;

    /// <summary>
    /// The player's transform that the enemy will follow.
    /// </summary>
    public Transform Player;

    /// <summary>
    /// The health of the enemy.
    /// </summary>
    private int health = 1;

    /// <summary>
    /// Called on the frame when a script is enabled just before any of the Update methods are called the first time.
    /// </summary>
    void Start()
    {
    }

    /// <summary>
    /// Called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        enemy.SetDestination(Player.position);
    }

    /// <summary>
    /// Handles the collision event when the enemy collides with another object.
    /// </summary>
    /// <param name="collision">The collision data associated with the collision.</param>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject); // Destroy the bullet on impact
        }
    }

    /// <summary>
    /// Applies damage to the enemy and destroys it if health is depleted.
    /// </summary>
    /// <param name="damage">The amount of damage to apply.</param>
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
