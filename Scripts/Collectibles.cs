/*
* Author: Bontha John Aparanjan
* Date: 17 May 2024
* Description: This script handles collectible items, including giving points to the player when collected.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a collectible item.
/// </summary>
public class Collectible : MonoBehaviour
{
    /// <summary>
    /// Points this collectible gives.
    /// </summary>
    public int coin = 10;

    /// <summary>
    /// Called when the item is collected.
    /// </summary>
    public void Collected()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Called when player collides with collectible.
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().UpdateCollectible(this);
        }
    }

    /// <summary>
    /// Called when player stops colliding collectible.
    /// </summary>
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().UpdateCollectible(null);
        }
    }
}
