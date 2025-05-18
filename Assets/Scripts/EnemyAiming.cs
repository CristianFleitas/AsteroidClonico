using UnityEngine;

public class EnemyAiming : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform enemyBulletSpawn;

    void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("No se encontró al jugador con el tag 'Player'.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = player.position - enemyBulletSpawn.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            enemyBulletSpawn.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
