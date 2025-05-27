using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject grenadePrefab;
    public float shootForce = 10f;
    public KeyCode shootKey = KeyCode.Space;

    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Lanza la granada hacia la derecha
            rb.AddForce(transform.right * shootForce, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogError("El prefab de granada no tiene Rigidbody2D");
        }
    }
}
