/*
* Author: Bontha John Aparanjan
* Date: 17 May 2024
* Description: This script controls the door functionality, including locking, unlocking, and opening the door.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Represents a door that can be locked or unlocked.
/// </summary>
public class door : MonoBehaviour
{
    /// <summary>
    /// Whether the door is open.
    /// </summary>
    bool opened = false;

    /// <summary>
    /// Whether the door is locked.
    /// </summary>
    bool locked = true; // Default the door to be locked

    /// <summary>
    /// Displays messages to the player.
    /// </summary>
    public TextMeshProUGUI Text;

    /// <summary>
    /// Image used for messages.
    /// </summary>
    [SerializeField] GameObject TextImage;

    /// <summary>
    /// Called when player enters the trigger collider.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !opened)
        {
            other.gameObject.GetComponent<Player>().UpdateDoor(this);
            TextImage.SetActive(true);

            if (!locked)
            {
                Text.text = "Press 'E' to open the door"; // Prompt to open the door
            }
            else
            {
                Text.text = "The door is locked. Find the keycard.";
            }
        }
    }

    /// <summary>
    /// Called when player exits the trigger collider.
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().UpdateDoor(null);
            Text.text = null;
            TextImage.SetActive(false);
        }
    }

    /// <summary>
    /// Opens the door if it is not locked.
    /// </summary>
    public void OpenDoor()
    {
        if (!locked && !opened)
        {
            
            Vector3 newRotation = transform.eulerAngles;

            
            newRotation.y += 90f;

            
            transform.eulerAngles = newRotation;

            opened = true;
        }
    }

    /// <summary>
    /// Locks or unlocks the door.
    /// </summary>
    public void SetLock(bool lockStatus)
    {
        locked = lockStatus;
    }

    /// <summary>
    /// Hides messages at the start.
    /// </summary>
    void Start()
    {
        Text.text = null;
        TextImage.SetActive(false);
    }
}
