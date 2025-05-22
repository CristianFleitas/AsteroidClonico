using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private ParticleSystem destroyedParticles;
    public int size = 3;
    public EnemyManager enemyManager;
   
    void Start()
    {
        //Velocidad y movimiento del Asteroide
        transform.localScale = 0.5f * size * Vector3.one;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 direction =  new Vector2(Random.value, Random.value).normalized;
        float spawnSpeed = Random.Range(4f - size, 5f - size);
        rb.AddForce(direction * spawnSpeed, ForceMode2D.Impulse);

        //Sumar al contador de asteroides para saber si hay que cambiar de lvl
        enemyManager.asteroidCount++;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Detector del daño de la bala
        if (collision.CompareTag("Bullet"))
        {
            enemyManager.asteroidCount--;

            Destroy(collision.gameObject);

            //Matriosca del asteride
            if (size > 1)
            {
                for (int i = 0; i < 2; i++)
                {
                    Asteroid newAsteroid = Instantiate(this, transform.position, Quaternion.identity);
                    newAsteroid.size = size - 1;
                    newAsteroid.enemyManager = enemyManager;
                }
            }

            Instantiate(destroyedParticles, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
