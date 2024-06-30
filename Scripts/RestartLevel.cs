/*
 * Author: Bontha John Aparanjan
 * Date: 30 June 2024
 * Description: This script handles the restarting of a specific level in a game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the restarting of a specific level.
/// </summary>
public class RestartLevel : MonoBehaviour
{
    /// <summary>
    /// Restarts the level by loading the scene asynchronously.
    /// </summary>
    public void LevelRestart()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
