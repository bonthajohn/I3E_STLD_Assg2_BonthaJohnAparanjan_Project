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

    void Start()
    {
        TextImage.SetActive(false);
        LoseTextImage.SetActive(false);
        characterController = GetComponent<CharacterController>();
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
            DisplayCrystalMessage();
        }
    }

    void DisplayLoseMessage()
    {
        loseText.text = "You lost the game! You can either:";
        LoseTextImage.SetActive(true);
    }

    void DisplayCrystalMessage()
    {
        Text.text = "Let's head back to your spaceship!";
        TextImage.SetActive(true);
    }
}
