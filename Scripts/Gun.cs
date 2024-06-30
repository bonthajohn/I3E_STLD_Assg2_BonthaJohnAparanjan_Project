/*
 * Author: Bontha John Aparanjan
 * Date: 30 June 2024
 * Description: This script handles the shooting mechanics for a gun in a game. 
 *              When the shoot input is triggered, it spawns and fires a bullet.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

/// <summary>
/// Represents a gun that can shoot bullets when the shoot input is triggered.
/// </summary>
public class Gun : MonoBehaviour
{
    /// <summary>
    /// Reference to the input handling script.
    /// </summary>
    private StarterAssetsInputs _input;

    /// <summary>
    /// Prefab of the bullet to be instantiated.
    /// </summary>
    [SerializeField]
    private GameObject bulletPrefab;

    /// <summary>
    /// The point from where the bullet is instantiated.
    /// </summary>
    [SerializeField]
    private GameObject bulletPoint;

    /// <summary>
    /// Speed of the bullet when shot.
    /// </summary>
    public float bulletSpeed;

    /// <summary>
    /// Upward force applied to the bullet when shot.
    /// </summary>
    public float bulletUp;

    /// <summary>
    /// Called on the frame when a script is enabled just before any of the Update methods are called the first time.
    /// </summary>
    void Start()
    {
        _input = GetComponentInParent<StarterAssetsInputs>();
    }

    /// <summary>
    /// Called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (_input != null && _input.shoot)
        {
            Shoot();
            _input.shoot = false;
        }
    }

    /// <summary>
    /// Handles the shooting logic by instantiating and firing a bullet.
    /// </summary>
    void Shoot()
    {
        Debug.Log("shoot!");
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        bullet.GetComponent<Rigidbody>().AddForce(transform.up * bulletUp);
        Destroy(bullet, 1);
    }
}
