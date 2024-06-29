/*
* Author: Bontha John Aparanjan
* Date: 17 May 2024
* Description: This script handles the gun collecting functionality.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Collecting gun functionality.
/// </summary>
public class GunCollect : MonoBehaviour
{
    /// <summary>
    /// Handles collision with the player.
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().CollectGun();
            Destroy(gameObject);
        }
    }
}
