/*
 * Author: Bontha John Aparanjan
 * Date: 30 June 2024
 * Description: This script handles the navigation back to the main page/scene in a game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the navigation back to the main page/scene.
/// </summary>
public class MainPage : MonoBehaviour
{
    /// <summary>
    /// Loads the main page/scene asynchronously.
    /// </summary>
    public void BackToMainPage()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
