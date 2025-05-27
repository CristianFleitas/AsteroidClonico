using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int bulletCount = 12;
    public float bulletSpeed = 5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Explode();
            Destroy(gameObject);
        }
    }

    void Explode()
    {
        float angleStep = 360f / bulletCount;

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;

            // Spawn con pequeño desplazamiento
            Vector2 spawnPos = (Vector2)transform.position + direction * 0.2f;
            GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * bulletSpeed;
            }
        }
    }
}
