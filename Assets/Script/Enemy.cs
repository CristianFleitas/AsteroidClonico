using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
    public int size = 3;
    public EnemyManager enemyManager;

    private float counter;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Start()
    {
        transform.localScale = 0.5f * size * Vector3.one;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Random.value * size, Random.value).normalized;
        float spawnSpeed = Random.Range(4f - size, 5f - size);
        rb.AddForce(direction * spawnSpeed, ForceMode2D.Impulse);

    }

    void Update()
    {
        //transform.LookAt(target.transform);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);

            Destroy(gameObject);
        }
    }
}
