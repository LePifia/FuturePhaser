using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    Transform player;
    [SerializeField] float moveSpeed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        moveSpeed = PlayerStatics.Instance.enemySpeed;
        
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
}
