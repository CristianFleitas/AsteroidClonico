using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject playerPrefab;   // arrastra tu prefab del jugador aqu�
    public Transform spawnPoint;      // arrastra el SpawnPoint aqu�

    void Start()
    {
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
