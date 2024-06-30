/*
 * Author: Bontha John Aparanjan
 * Date: 30 June 2024
 * Description: This script handles the navigation to the last page/scene in a game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the navigation to the last page/scene.
/// </summary>
public class LastPage : MonoBehaviour
{
    /// <summary>
    /// Loads the last page/scene asynchronously.
    /// </summary>
    public void GoToLastPage()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
