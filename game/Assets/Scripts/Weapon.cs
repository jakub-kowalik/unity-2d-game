using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioClip sound;
    public AudioSource audio;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !GlobalVariables.isMenuOpen)
        {
            audio.volume = GlobalVariables.volume / 4;
            audio.PlayOneShot(sound);
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
