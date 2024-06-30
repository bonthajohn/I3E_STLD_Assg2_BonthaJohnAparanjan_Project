/*
 * Author: Bontha John Aparanjan
 * Date: 30 June 2024
 * Description: This script manages player interactions and gameplay mechanics in the game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Manages player interactions and gameplay mechanics.
/// </summary>
public class Player : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI Text;
    [SerializeField] GameObject TextImage;
    public TextMeshProUGUI loseText;
    [SerializeField] GameObject LoseTextImage;

    int currentScore = 0;
    Collectible currentCollectible;
    bool canScore = true;
    public float moveSpeed = 5f;
    private CharacterController characterController;
    bool hasCollectedGun = false;

    bool isNearCrystal = false; 

    void Start()
    {
        TextImage.SetActive(false);
        LoseTextImage.SetActive(false);
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isNearCrystal && Input.GetKeyDown(KeyCode.E)) 
        {
            DisplayCrystalMessage();
        }
    }

    /// <summary>
    /// Increases the player's score by the specified amount.
    /// </summary>
    /// <param name="scoreToAdd">The score to add.</param>
    public void IncreaseScore(int scoreToAdd)
    {
        if (canScore)
        {
            currentScore += scoreToAdd;
            scoreText.text = "Points: " + currentScore.ToString();

            if (currentScore >= 200)
            {
                currentScore = 200;
                canScore = false;
                CheckForCongrats();
            }
        }
    }

    /// <summary>
    /// Checks if the player has earned enough points and collected the gun to display a congratulatory message.
    /// </summary>
    void CheckForCongrats()
    {
        if (currentScore == 200 && hasCollectedGun)
        {
            DisplayCongratsMessage();
        }
    }

    /// <summary>
    /// Displays a congratulatory message when conditions are met.
    /// </summary>
    void DisplayCongratsMessage()
    {
        Text.text = "Congrats, you've earned enough coins to teleport to the next area of this planet to complete your mission!";
        TextImage.SetActive(true);
    }

    /// <summary>
    /// Updates the current collectible item that the player can interact with.
    /// </summary>
    /// <param name="newCollectible">The new collectible item.</param>
    public void UpdateCollectible(Collectible newCollectible)
    {
        currentCollectible = newCollectible;
    }

    /// <summary>
    /// Handles interaction with the current collectible item.
    /// </summary>
    void OnInteract()
    {
        if (currentCollectible != null)
        {
            IncreaseScore(currentCollectible.coin);
            currentCollectible.Collected();
        }
    }

    /// <summary>
    /// Marks that the player has collected the gun and checks for congratulatory message.
    /// </summary>
    public void CollectGun()
    {
        hasCollectedGun = true;
        CheckForCongrats();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            canScore = false;
            loseText.text = "You lost the game! You can either:";
            LoseTextImage.SetActive(true);
        }
        else if (other.CompareTag("Enemy"))
        {
            DisplayLoseMessage();
        }
        else if (other.CompareTag("Crystal")) 
        {
            isNearCrystal = true; 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Crystal"))
        {
            isNearCrystal = false; 
        }
    }

    /// <summary>
    /// Displays a message indicating the player has lost the game.
    /// </summary>
    void DisplayLoseMessage()
    {
        loseText.text = "You lost the game! You can either:";
        LoseTextImage.SetActive(true);
    }

    /// <summary>
    /// Displays a message indicating the player has collected a crystal.
    /// </summary>
    void DisplayCrystalMessage()
    {
        Text.text = "You've collected the crystal, let's head back to your spaceship!";
        TextImage.SetActive(true);

        
        GameObject crystalObject = GameObject.FindGameObjectWithTag("Crystal");
        if (crystalObject != null)
        {
            Destroy(crystalObject);
        }
    }
}
