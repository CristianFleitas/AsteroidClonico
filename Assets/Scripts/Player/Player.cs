using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Ship parameters")]
    [SerializeField] private float shipAcceleration = 10f;
    [SerializeField] private float shipMaxVelocity = 10f;
    [SerializeField] private float shipRotationSpeed = 180f;
    [SerializeField] private float bulletSpeed = 8f;

    [Header("Object references")]
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private ParticleSystem destroyParticles;

    private Rigidbody2D shipRigidbody;
    private bool isAlive = true;
    private bool isAccelerating = false;

    void Start()
    {
        shipRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive) 
        { 
        HandleShipAcceleration();
        HandleShipRotation();
        HandleShooting();
        }
    }

    private void FixedUpdate()
    {
        if (isAlive && isAccelerating)
        {
            shipRigidbody.AddForce(shipAcceleration * transform.up);
            shipRigidbody.velocity = Vector2.ClampMagnitude(shipRigidbody.velocity, shipMaxVelocity);
        }
    }

    private void HandleShipAcceleration()
    {
        isAccelerating = Input.GetKey(KeyCode.W);
    }

    private void HandleShipRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(shipRotationSpeed * Time.deltaTime * transform.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-shipRotationSpeed * Time.deltaTime * transform.forward);
        }
    }

    private void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

            Vector2 shipVelocity = shipRigidbody.velocity;
            Vector2 shipDirection = transform.up;
            float shipForwardSpeed = Vector2.Dot(shipVelocity, shipDirection);

            if (shipForwardSpeed < 0)
            {
                shipForwardSpeed = 0;
            }

            // si se a�ade la linea de velocidad de abajo se suma demasiado la velocidad diagonal
            //bullet.velocity = shipVelocity * shipForwardSpeed; 

            bullet.AddForce(bulletSpeed * transform.up, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D (Collider2D collison)
    {
        if (collison.CompareTag("Asteroid"))
        {   
            GameManager gameManager = FindAnyObjectByType<GameManager>();

            gameManager.GameOver();

            Instantiate(destroyParticles, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }

        if (collison.CompareTag("EnemyBullet"))
        {
            GameManager gameManager = FindAnyObjectByType<GameManager>();

            gameManager.GameOver();

            Instantiate(destroyParticles, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
