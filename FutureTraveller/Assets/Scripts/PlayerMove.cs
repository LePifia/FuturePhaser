using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;

    [SerializeField]Transform limitWest;
    [SerializeField] Transform limitEast;
    [SerializeField] Transform limitNorth;
    [SerializeField] Transform limitSouth;


    Vector3 moveDir;

    void Update ()
    {






        moveDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * moveSpeed * Time.deltaTime;
            transform.position += moveDir;
        



    }
}
