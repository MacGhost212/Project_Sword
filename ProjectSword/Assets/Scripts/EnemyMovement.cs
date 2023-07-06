using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;

    public int StartHealth = 100;
    private float health;

    public int valueOfTarget = 50;

    private Transform target;
    private int wavepointIndex = 0;

    [Header("Unity Stuff")]
    public Image healthBar;

    void Start()
    {
        target = Waypoints.points[0];
        health = StartHealth;
    }

    public void takeDamage(int amount)
    {
        health -= amount;

        healthBar.fillAmount = health / StartHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += valueOfTarget;
        Destroy(gameObject);

        WaveSpawner.EnemiesAlive--;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if(wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
