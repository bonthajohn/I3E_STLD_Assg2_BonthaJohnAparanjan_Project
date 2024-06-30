/*
 * Author: Bontha John Aparanjan
 * Date: 30 June 2024
 * Description: This script handles the restarting of a level in a game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the restarting of the level.
/// </summary>
public class LevelRestart : MonoBehaviour
{
    /// <summary>
    /// Restarts the level by loading the scene asynchronously.
    /// </summary>
    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
