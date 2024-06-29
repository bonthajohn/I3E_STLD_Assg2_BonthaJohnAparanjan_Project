using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Gun : MonoBehaviour
{
    private StarterAssetsInputs _input;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject bulletPoint;
    public float bulletSpeed;
    public float bulletUp;


    void Start()
    {
        
        _input = GetComponentInParent<StarterAssetsInputs>();

    }

    void Update()
    {
        
        if (_input != null && _input.shoot)
        {
            Shoot();
            _input.shoot = false;
        }
    }

    void Shoot()
    {
        Debug.Log("shoot!");
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        bullet.GetComponent<Rigidbody>().AddForce(transform.up * bulletUp);
        Destroy(bullet, 1);
    }
}
