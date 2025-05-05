using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float lifetime = 1.5f;
    private void Awake()
    {
        Destroy(gameObject, lifetime);
    }
}
