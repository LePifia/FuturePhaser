using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealityRepair : MonoBehaviour
{
    public static RealityRepair Instance { get; private set; }

    [SerializeField] GameObject [] areasDisabled;
    public float maxtimer = 5;
    [SerializeField] float timer;

    public bool anyAreaDisabled;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;




    }
    private void Update()
    {
        foreach (var item in areasDisabled) {
            if (item.activeSelf == false)
            {
                
                timer += Time.deltaTime;

                if (timer >= maxtimer) { 
                
                item.SetActive(true);
                    item.GetComponent<DisableBehaviour>().SetTimer(maxtimer);
                    item.GetComponent <DisableBehaviour>().SetActionExecute(false);
                    anyAreaDisabled = false;
                    timer = 0;
                }
            }
           
        
        }

    }
}
