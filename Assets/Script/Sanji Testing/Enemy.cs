using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Bullets Parameters")]
    [SerializeField] private float bulletSpeed = 12f; 

    [Header("Object References")]
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private GameObject bulletContainer;
    [SerializeField] private GameObject target;

    private float counter;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        counter += Time.deltaTime;
        if(counter >= 1)
        {
            shooting();
            counter = 0;
        }
    }
    private void shooting()
    {
            Rigidbody2D bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity, bulletContainer.transform);

            bullet.AddForce(bulletSpeed * transform.up, ForceMode2D.Impulse);    
    }
}
