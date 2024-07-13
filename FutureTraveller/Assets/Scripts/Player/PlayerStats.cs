using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public enum statType
{
    area1enemy, area2enemy,area3enemy, area4enemy,
    player, projectile
}

public class PlayerStats : MonoBehaviour
{
    public event EventHandler OnDieEvent;
    [SerializeField] statType statType;
    [SerializeField] int health = 5;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float scoreGiven = 0;

    [SerializeField]bool player;
    [SerializeField] bool enemy;
    [SerializeField] bool damageblae = true;

    [SerializeField] bool area1Enemy;
    [SerializeField] bool area2Enemy;
    [SerializeField] bool area3Enemy;
    [SerializeField] bool area4Enemy;

    

    float timer;

    [Header("Events")]
    [Space]

    public UnityEvent OnHitEvent;


    private void Start()
    {
        if(statType == statType.area1enemy || statType == statType.area2enemy || statType == statType.area3enemy || statType == statType.area4enemy)
        {
            health = PlayerStatics.Instance.enemyHealth;
        }
        if(statType == statType.player)
        {
            health = PlayerStatics.Instance.health;
        }
    }
    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            damageblae = true;
        }
        if (health <= 0)
        {
            DIE();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
            if (timer <= 0 && player  == true)
            {
             
                DamageDealer damageDealer = other.GetComponent<DamageDealer>();

                if (damageDealer != null)
                {
                    TakeDamage(damageDealer.GetDamage());
                }

                timer = 5;
            }
            else
            {
            DamageDealer damageDealer = other.GetComponent<DamageDealer>();
            if (damageDealer != null)
            {
                if (other.GetComponent<PlayerStats>().enemy == false && other.GetComponent<PlayerStats>() != null)
                {
                

                

                    TakeDamage(damageDealer.GetDamage());

                    if (area1Enemy == true && damageDealer.GetDamageType() == damageType.area1)
                    {
                        TakeDamage(damageDealer.GetDamage() * 9);
                    }

                    if (area2Enemy == true && damageDealer.GetDamageType() == damageType.area2)
                    {
                        TakeDamage(damageDealer.GetDamage() * 9);
                    }

                    if (area3Enemy == true && damageDealer.GetDamageType() == damageType.area3)
                    {
                        TakeDamage(damageDealer.GetDamage() * 9);
                    }

                    if (area4Enemy == true && damageDealer.GetDamageType() == damageType.area4)
                    {
                        TakeDamage(damageDealer.GetDamage() * 9);
                    }
                }
               


            }

                
            
            }
        
       
   
        
    }
    public void TakeDamage (int Damage)
    {
        OnHitEvent.Invoke();

        if (damageblae)
        {
            damageblae = false;
            health -= Damage;
            Debug.Log("Damaged");
        }
        

        if (health > 0)
        {
            StartCoroutine(DamageFlash());
        }
        

        if (health <= 0)
        {
            DIE();
        }
    }

    public void DIE()
    {
        if (statType == statType.area1enemy || statType == statType.area2enemy || statType == statType.area3enemy || statType == statType.area4enemy)
        {
            
            Destroy(gameObject);
        }
        if (statType == statType.player)
        {
            OnDieEvent?.Invoke(this, EventArgs.Empty);
            AudioManager.Instance.CasualExplosion();
            gameObject.SetActive(false);
            
        }
        if (statType == statType.projectile)
        {
            Destroy(gameObject);
        }
        
    }

    public int GetHealth()
    {
        return health;
    }

    IEnumerator DamageFlash()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.05f);

        spriteRenderer.color = Color.white;
    }

    private void OnDestroy()
    {
        if (statType == statType.area1enemy || statType == statType.area2enemy || statType == statType.area3enemy || statType == statType.area4enemy)
        {
            //AudioManager.Instance.CasualExplosion();
            PlayerStatics.Instance.AddScore(scoreGiven);
            PlayerStatics.Instance.AddExperience(1);
            
        }

        if (statType == statType.projectile)
        {
            //AudioManager.Instance.PlayerExplosion();
            
        }
            
    }

    public statType getStatType()
    {
        return gameObject.GetComponent<statType>();
    }

    

}
