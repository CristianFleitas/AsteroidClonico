using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Ship Parameters")]
    [SerializeField] private float shipAcceleration = 10f;
    [SerializeField] private float shipMaxVelocity = 10f;
    [SerializeField] private float shipRotationSpeed = 150f;

    [Header("Bullets Parameters")]
    [SerializeField] private float bulletSpeed = 12f;

    [Header("Object References")]
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private GameObject bulletContainer;

    private Rigidbody2D shipRigidbody;
    private bool isAlive = true;
    private bool isAccelerating = false;

    private void Awake()
    {
        shipRigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (isAlive)
        {
            handleShipAcceleration();
            HandleShipRotation();
            HandleShooting();
        }
    }

    private void FixedUpdate()
    {
        if(isAlive && isAccelerating)
        {
            shipRigidbody.AddForce(shipAcceleration * transform.up);
            shipRigidbody.velocity = Vector2.ClampMagnitude(shipRigidbody.velocity, shipMaxVelocity);
        }
    }
    private void handleShipAcceleration()
    {
        isAccelerating = Input.GetKey(KeyCode.UpArrow);
    }
    private void HandleShipRotation()
    {
            if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(shipRotationSpeed * Time.deltaTime * transform.forward);
        } else if (Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(-shipRotationSpeed * Time.deltaTime * transform.forward);
        }
    }
    private void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity, bulletContainer.transform);

            Vector2 shipVelocity = shipRigidbody.velocity;
            Vector2 shipDirection = transform.up;
            float shipForwardSpeed = Vector2.Dot(shipVelocity, shipDirection);

            //Para segurarnos de que no hayan balas paradas
            if(shipForwardSpeed < 0){
                shipForwardSpeed = 0;
            }

            bullet.velocity = shipDirection * shipForwardSpeed;

            bullet.AddForce(bulletSpeed * transform.up, ForceMode2D.Impulse);
        }
    }
}
