using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerStatics : MonoBehaviour
{
    public static PlayerStatics Instance { get; private set; }

    public int damageDealt = 1;
    public float projectileSpeed = 5;
    public float cooldown;
    public float Experience;
    public float totalScore;
    public bool area1Stay;
    public bool area2Stay;
    public bool area3Stay;
    public bool area4Stay;

    //EnemyStats

    public int health = 1;
    public int enemyHealth = 5;
    float enemyCooldown = 5;
    public float enemySpeed = 1;
    [SerializeField] GameObject [] enemies;
    [SerializeField] GameObject []instancers;

    int healthcooldown = 5;
    int healthcooldownMax = 5;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;




    }

    private void Start()
    {
        UpdateAll();

        StartCoroutine(UpdateEnemyControllers());
    }

    private IEnumerator UpdateEnemyControllers()
    {
        healthcooldown -= 1;

        if (healthcooldown <= 0)
        { 
            healthcooldown = healthcooldownMax;
        }

        enemyCooldown = enemyCooldown * 0.99f;
        enemySpeed = enemySpeed + 0.5f;
        
        Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Length)], instancers[UnityEngine.Random.Range(0,instancers.Length)].transform.position, Quaternion.identity);
        
        
        yield return new WaitForSeconds(enemyCooldown);
        StartCoroutine(UpdateEnemyControllers());
    }

    private void UpdateAll()
    {
        /*
        UI.instance.UpdateDamage(damageDealt);
        UI.instance.UpdateProjectileSpeed(projectileSpeed);
        UI.instance.UpdateCooldown(cooldown);
        UI.instance.UpdateMultiplier(projectileSpeed);
        */
    }


    public void AddDamage(int amount)
    {
        damageDealt += amount;
        UI.instance.UpdateDamage(damageDealt);
    }

    public void AddProjectileSpeed(float amount)
    {
        projectileSpeed += amount;
        UI.instance.UpdateProjectileSpeed(projectileSpeed);
    }

    public void Cooldown (float amount)
    {
        cooldown -= amount;
        UI.instance.UpdateCooldown(cooldown);
    }


    public void AddExperience(int amount)
    {
        Experience += amount;
        UI.instance.UpdateExperience(Experience);
    }


    public void AddScore(float amount)
    {
        totalScore += amount;
        UI.instance.UpdateScore(totalScore);
    }
}
