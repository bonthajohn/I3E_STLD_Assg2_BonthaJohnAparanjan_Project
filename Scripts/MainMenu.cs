/*
 * Author: Bontha John Aparanjan
 * Date: 30 June 2024
 * Description: This script handles the main menu functionality, including starting the game and quitting the application.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the main menu functionality.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Starts the game by loading the first scene asynchronously.
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    /// <summary>
    /// Quits the game application.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
