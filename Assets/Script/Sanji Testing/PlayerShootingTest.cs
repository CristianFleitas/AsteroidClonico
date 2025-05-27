using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingTest : MonoBehaviour
{

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("h")) //Disparar
            { 
            audioManager.PlaySFX(audioManager.Shoot);
            print("Shooting");
            }

        if (Input.GetKeyDown("j")) //Disparar
        {
            audioManager.PlaySFX(audioManager.Explosion);
            print("Explosion");
        }
    }
}
