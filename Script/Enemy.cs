using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float starthealth = 100;
    public float Plushealth;
    private float health;
    public float test;
    public int worth = 50;
    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;

    void Start()
    {
        Plushealth = (10*Mathf.Pow(PlayerStats.Rounds, 3) - 109*Mathf.Pow(PlayerStats.Rounds, 2) + 1290*PlayerStats.Rounds - 826)/starthealth;//starthealth + 16*Mathf.Pow(PlayerStats.Rounds, 2) + 40*PlayerStats.Rounds;
        speed = startSpeed;
        health = Plushealth+test;
        Debug.Log(health);
    }

    void Update()
    {
        //Debug.Log(health);
    }

    public void TakeDamage (float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / Plushealth;
        Debug.Log(health);

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow (float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die() {
        {
            isDead = true;

            PlayerStats.Money += worth;

            GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Wavespwaner.EnemiesAlive--;
            Destroy(gameObject);
        }
    }

}
