using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float startSpeed = 10;
    [HideInInspector]
    public float speed;
    public float startHealth = 100f;
    private float health;
    public int worth = 50;
    public int atk = 10;
    public float fireCountdown = 0f;
    public float fireRate = 1f;


    public GameObject deathEffect;

    public Image healthbar;

    private bool isDead = false;

    public void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDammage(float amount)
    {
        health -= amount;

        healthbar.fillAmount = health / startHealth;

        if(health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }

    private void Die()
    {
        isDead = true;

        PlayerStats.money += worth;

        GameObject deathParticles = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deathParticles, 2f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

}
