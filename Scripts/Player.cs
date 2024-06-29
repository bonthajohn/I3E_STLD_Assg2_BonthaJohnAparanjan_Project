/*
* Author: Bontha John Aparanjan
* Date: 17 May 2024
* Description: This script controls the player character, including score management and interaction with doors and collectibles.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Controls the player character.
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>
    /// Displays the player's score.
    /// </summary>
    public TextMeshProUGUI scoreText;

    /// <summary>
    /// Displays messages to the player.
    /// </summary>
    public TextMeshProUGUI Text;

    /// <summary>
    /// Image used for messages.
    /// </summary>
    [SerializeField] GameObject TextImage;

    /// <summary>
    /// The player's current score.
    /// </summary>
    int currentScore = 0;

    /// <summary>
    /// The door the player is currently interacting with.
    /// </summary>
    door currentDoor;

    /// <summary>
    /// The collectible the player is currently interacting with.
    /// </summary>
    Collectible currentCollectible;

    /// <summary>
    /// Whether the player can score.
    /// </summary>
    bool canScore = true;

    /// <summary>
    /// The speed of the player's movement.
    /// </summary>
    public float moveSpeed = 5f;

    /// <summary>
    /// The player's character controller.
    /// </summary>
    private CharacterController characterController;

    /// <summary>
    /// Initializes the player.
    /// </summary>
    void Start()
    {
        TextImage.SetActive(false);
        characterController = GetComponent<CharacterController>();
    }

    /// <summary>
    /// Adds points to the player's score.
    /// </summary>
    public void IncreaseScore(int scoreToAdd)
    {
        if (canScore)
        {
            currentScore += scoreToAdd;
            scoreText.text = "Points:" + currentScore.ToString();

            if (currentScore >= 200)
            {
                currentScore = 200; // Cap the score at 200
                canScore = false; // Disable further scoring
                DisplayCongratsMessage();
            }
        }
    }

    /// <summary>
    /// Shows a congratulatory message.
    /// </summary>
    void DisplayCongratsMessage()
    {
        Text.text = "Congratulations, you've completed the game!";
        TextImage.SetActive(true); // Show congratulatory message
    }

    /// <summary>
    /// Updates the current door the player is interacting with.
    /// </summary>
    public void UpdateDoor(door newDoor)
    {
        currentDoor = newDoor;
    }

    /// <summary>
    /// Updates the current collectible the player is interacting with.
    /// </summary>
    public void UpdateCollectible(Collectible newCollectible)
    {
        currentCollectible = newCollectible;
    }

    /// <summary>
    /// Handles interaction with doors and collectibles.
    /// </summary>
    void OnInteract()
    {
        if (currentDoor != null)
        {
            currentDoor.OpenDoor();
            currentDoor = null;
        }

        if (currentCollectible != null)
        {
            IncreaseScore(currentCollectible.coin);
            currentCollectible.Collected();
        }
    }

    /// <summary>
    /// Displays a loss message when touching fire.
    /// </summary>
    /// <param name="other">The other collider involved in the collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            canScore = false;
            Text.text = "You lost the game!";
            TextImage.SetActive(true);
        }
    }
}
