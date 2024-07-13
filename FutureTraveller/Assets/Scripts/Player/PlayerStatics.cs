using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerStatics : MonoBehaviour
{
    public static PlayerStatics Instance { get; private set; }

    public int damageDealt = 1;

    public float Experience;
    public float coins;
    public float totalScore;
    [SerializeField] float maxEnemySpeed;
    [SerializeField] float targetScore;
    public GameObject blackHole;
    [SerializeField] TextMeshProUGUI totalScoreUI;
    [SerializeField] TextMeshProUGUI appleUI;
    public bool activateBlackHole;
   

    [SerializeField] bool InstantiateEnemies;
    public bool area1Stay;
    public bool area2Stay;
    public bool area3Stay;
    public bool area4Stay;

    //EnemyStats

    public int health = 1;
    public int enemyHealth = 5;
    float enemyCooldown = 3;
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
        

        StartCoroutine(UpdateEnemyControllers());
    }

    private void Update()
    {
        totalScoreUI.text = totalScore.ToString(); 
        appleUI.text = coins.ToString();

        if (coins >= targetScore && blackHole != null)
        {
            
            activateBlackHole = true;

            //Instantiate(blackHole, gameObject.transform.position, Quaternion.identity);
        }
    }

    private IEnumerator UpdateEnemyControllers()
    {
        if (InstantiateEnemies)
        {
            healthcooldown -= 1;

            if (healthcooldown <= 0)
            {
                healthcooldown = healthcooldownMax;
            }

            enemyCooldown = enemyCooldown * 0.99f;
            Debug.Log(enemySpeed);

            if (enemySpeed >= maxEnemySpeed)
            {

            }
            else
            {
                enemySpeed = enemySpeed + 0.05f;
            }
            

            Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Length)], instancers[UnityEngine.Random.Range(0, instancers.Length)].transform.position, Quaternion.identity);


            yield return new WaitForSeconds(enemyCooldown);
            StartCoroutine(UpdateEnemyControllers());
        }
       
    }

    public void AddDamage(int amount)
    {
        damageDealt += amount;
        
    }


    public void AddExperience(int amount)
    {
        Experience += amount;
        
    }


    public void AddScore(float amount)
    {
        totalScore += amount;
        
    }

    public void AddCoins(int amount)
    {
        coins += amount;

    }
}
