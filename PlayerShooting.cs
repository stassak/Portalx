using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public AudioClip shootSound;  // Assign this in Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Debug.Log("Paused:Player shooting ");
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1")) // Left Click / Controller Trigger
        {
            Shoot();
        }


       
    }

    void Shoot()
    {
        Debug.Log(" Bang! Barrett fired!");

        // Play shoot sound
        audioSource.PlayOneShot(shootSound);

        // Your shooting logic (instantiate bullets, etc.)
    }
}
