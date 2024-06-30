using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI Text;
    [SerializeField] GameObject TextImage;
    public TextMeshProUGUI loseText;
    [SerializeField] GameObject LoseTextImage;

    int currentScore = 0;
    door currentDoor;
    Collectible currentCollectible;
    bool canScore = true;
    public float moveSpeed = 5f;
    private CharacterController characterController;
    bool hasCollectedGun = false;

    bool isNearCrystal = false; // Flag to track if player is near a crystal

    void Start()
    {
        TextImage.SetActive(false);
        LoseTextImage.SetActive(false);
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isNearCrystal && Input.GetKeyDown(KeyCode.E)) // Check if player is near crystal and presses 'E'
        {
            DisplayCrystalMessage();
        }
    }

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

    void CheckForCongrats()
    {
        if (currentScore == 200 && hasCollectedGun)
        {
            DisplayCongratsMessage();
        }
    }

    void DisplayCongratsMessage()
    {
        Text.text = "Congrats, you'll now get teleported to the next area of this planet to complete your mission!";
        TextImage.SetActive(true);
    }

    public void UpdateDoor(door newDoor)
    {
        currentDoor = newDoor;
    }

    public void UpdateCollectible(Collectible newCollectible)
    {
        currentCollectible = newCollectible;
    }

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
        else if (other.CompareTag("Crystal")) // Check if the player touches a crystal
        {
            isNearCrystal = true; // Player is near a crystal
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Crystal"))
        {
            isNearCrystal = false; // Player is no longer near a crystal
        }
    }

    void DisplayLoseMessage()
    {
        loseText.text = "You lost the game! You can either:";
        LoseTextImage.SetActive(true);
    }

    void DisplayCrystalMessage()
    {
        Text.text = "You've collected the crystal, let's head back to your spaceship!";
        TextImage.SetActive(true);

        // Destroy the crystal object
        GameObject crystalObject = GameObject.FindGameObjectWithTag("Crystal");
        if (crystalObject != null)
        {
            Destroy(crystalObject);
        }
    }
}
