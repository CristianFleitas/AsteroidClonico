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
    [SerializeField] private float bulletSpeed = 8f;

    [Header("Object References")]
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Rigidbody2D bulletPrefab;

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
}
