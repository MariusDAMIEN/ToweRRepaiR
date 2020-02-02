using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

    private Transform target;
    private int waypointIndex = 0;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    public void EnnemyAttack()
    {
        // Waypoints w = GetComponent<Waypoints>();
        enemy.speed = 0;
        if (enemy.fireCountdown <= 0f)
        {
            // Waypoints.health -= enemy.atk;
            Debug.Log("DEGAT + 10");
            Debug.Log(Waypoints.health);
            Waypoints.TakeDammage(enemy.atk);
            enemy.fireCountdown = 1 / enemy.fireRate;
        }
        enemy.fireCountdown -= Time.deltaTime;
        // EndPath();
    }

    private void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            EnnemyAttack();
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    private void EndPath()
    {
        PlayerStats.lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

}
