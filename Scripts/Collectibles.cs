/*
 * Author: Bontha John Aparanjan
 * Date: 17 May 2024
 * Description: This script handles collectible items in a game. 
 *              When collected by the player, it provides points and 
 *              destroys itself upon collection.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a collectible item that can be collected by the player.
/// </summary>
public class Collectible : MonoBehaviour
{
    /// <summary>
    /// The number of points this collectible awards to the player.
    /// </summary>
    public int coin = 10;

    /// <summary>
    /// Destroys the game object when it is collected.
    /// </summary>
    public void Collected()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Handles the collision event when the player collides with this collectible.
    /// </summary>
    /// <param name="collision">The collision data associated with the collision.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().UpdateCollectible(this);
        }
    }

    /// <summary>
    /// Handles the exit event when the player stops colliding with this collectible.
    /// </summary>
    /// <param name="collision">The collision data associated with the exit.</param>
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().UpdateCollectible(null);
        }
    }
}
