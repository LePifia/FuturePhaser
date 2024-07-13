using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickUpType
{
    coin
}
public class PickUp : MonoBehaviour
{

    [SerializeField] PickUpType type;
    [SerializeField] int value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (type == PickUpType.coin)
            {
                collision.GetComponent<PlayerStatics>().AddCoins(value);

                if (PlayerStatics.Instance.activateBlackHole == true)
                {
                    int random = Random.Range(0, 100);

                    if (random > 65)
                    {
                        Instantiate(PlayerStatics.Instance.blackHole, gameObject.transform.position, Quaternion.identity);
                    }
                    
                }
                Destroy(gameObject);
            }
        }    
    }
}
