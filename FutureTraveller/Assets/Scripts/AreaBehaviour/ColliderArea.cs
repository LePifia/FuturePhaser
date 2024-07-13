using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum areaType
{
    area1,
    area2,
    area3,
    area4,
    agujeroNegro,
}
public class ColliderArea : MonoBehaviour
{
    [SerializeField] areaType areaType;

    private void OnTriggerStay2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            if (collision.CompareTag("Player"))
            {
                //Debug.Log(areaType);

                if (areaType == areaType.area1)
                {
                    PlayerStatics.Instance.area1Stay = true;
                }
                else
                {
                    PlayerStatics.Instance.area1Stay = false;
                }

                if (areaType == areaType.area2)
                {
                    PlayerStatics.Instance.area2Stay = true;
                }
                else
                {
                    PlayerStatics.Instance.area2Stay = false;
                }

                if (areaType == areaType.area3)
                {
                    PlayerStatics.Instance.area3Stay = true;
                }
                else
                {
                    PlayerStatics.Instance.area3Stay = false;
                }

                if (areaType == areaType.area4)
                {
                    PlayerStatics.Instance.area4Stay = true;
                }
                else
                {
                    PlayerStatics.Instance.area4Stay = false;
                }
            }

            if (collision.CompareTag("Enemy"))
            {
                

                if (areaType == areaType.area1)
                {
                    statType enemyCollide = collision.GetComponent<PlayerStats>().GetStatType();

                    if (enemyCollide == statType.area1enemy)
                    {

                        collision.GetComponent<PlayerStats>().TakeDamage(1);

                    }

                }

                if (areaType == areaType.area2)
                {
                    statType enemyCollide = collision.GetComponent<PlayerStats>().GetStatType();

                    if (enemyCollide == statType.area2enemy)
                    {
                        collision.GetComponent<PlayerStats>().TakeDamage(1);
                    }

                }

                if (areaType == areaType.area3)
                {
                    statType enemyCollide = collision.GetComponent<PlayerStats>().GetStatType();

                    if (enemyCollide == statType.area3enemy)
                    {
                        collision.GetComponent<PlayerStats>().TakeDamage(1);
                    }


                }

                if (areaType == areaType.area4)
                {
                    statType enemyCollide = collision.GetComponent<PlayerStats>().GetStatType();

                    if (enemyCollide == statType.area4enemy)
                    {
                        collision.GetComponent<PlayerStats>().TakeDamage(1);
                    }

                }

                if (areaType == areaType.agujeroNegro)
                {
                    statType enemyCollide = collision.GetComponent<PlayerStats>().GetStatType();

                    if(enemyCollide == statType.area1enemy || enemyCollide == statType.area2enemy || enemyCollide == statType.area3enemy || areaType == areaType.area4)
                    {
                        collision.GetComponent<PlayerStats>().TakeDamage(1);
                        Debug.Log("Enemy is in " + areaType);
                    }

                }

            }
        }
    }
}
