using System.Drawing;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem destroyedParticles;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform enemyBulletSpawn;
    [SerializeField] private float bulletSpeed = 8f;
    [SerializeField] private float fireRate = 1f;

    public EnemyManager enemyManager;
    private Rigidbody2D enemyRigibody;
    private float nextFireTime;

    public int size = 3;

    void Start()
    {
        enemyRigibody = GetComponent<Rigidbody2D>();
        transform.localScale = 0.5f * size * Vector3.one;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Random.value, Random.value).normalized;
        float spawnSpeed = Random.Range(4f - size, 5f - size);
        rb.AddForce(direction * spawnSpeed, ForceMode2D.Impulse);
    }

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, enemyBulletSpawn.position, enemyBulletSpawn.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = enemyBulletSpawn.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);

            Instantiate(destroyedParticles, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
