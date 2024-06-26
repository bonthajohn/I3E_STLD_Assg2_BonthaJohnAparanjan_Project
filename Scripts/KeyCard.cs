/*
* Author: Bontha John Aparanjan
* Date: 17 May 2024
* Description: This script handles the keycard functionality, including locking and unlocking a door when collected by the player.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Keycard that can unlock a door.
/// </summary>
public class KeyCard : MonoBehaviour
{
    /// <summary>
    /// The door this keycard can unlock.
    /// </summary>
    public door linkedDoor;

    /// <summary>
    /// Sets the linked door to locked at the start.
    /// </summary>
    private void Start()
    {
        if (linkedDoor != null)
        {
            linkedDoor.SetLock(true);
        }
    }

    /// <summary>
    /// Unlocks the door when the player collides with the keycard.
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            linkedDoor.SetLock(false);
            Destroy(gameObject);
        }
    }
}
