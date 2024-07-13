using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    Transform player;
    [SerializeField] float moveSpeed;
    [SerializeField] SpriteRenderer spriteRenderer;

    Vector3 destination;
    float visionRange;
    float dexterity;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        moveSpeed = PlayerStatics.Instance.enemySpeed * Random.Range(0.9f, 1.1f);
        destination = player.transform.position;
        visionRange = Random.Range(0, 100);
        dexterity = Random.Range(0.25f, 2.5f);
    }


    void Update()
    {

        if (player.position.x < gameObject.transform.position.x)
        {
            spriteRenderer.flipX = true;
        }

        if (player.position.x > gameObject.transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        Vector3 newDestination = player.transform.position + (Vector3)Random.insideUnitCircle * visionRange;
        destination = Vector3.Lerp(destination, newDestination, Time.deltaTime * dexterity);
        //Debug.DrawLine(transform.position, destination, Color.red);
        transform.position = Vector2.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
    }
}
