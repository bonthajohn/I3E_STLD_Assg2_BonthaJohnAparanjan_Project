/*
 * Author: Bontha John Aparanjan
 * Date: 30 June 2024
 * Description: This script handles the navigation to the next level/scene in a game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the navigation to the next level/scene.
/// </summary>
public class NextLevel : MonoBehaviour
{
    /// <summary>
    /// Loads the next level/scene asynchronously.
    /// </summary>
    public void NewLevel()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
