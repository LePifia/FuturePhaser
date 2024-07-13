using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBehaviour : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] float timeLook = 5f;
    [SerializeField] float shakeDuration = 0.5f;  // Duration of the shake effect
    [SerializeField] float shakeMagnitude = 0.05f; // Magnitude of the shake effect

    private bool isPlayerOnPoint = false;
    private bool actionExecuted = false;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.localPosition;
        timeLook = RealityRepair.Instance.maxtimer;
    }

    private void Update()
    {
        if (isPlayerOnPoint && RealityRepair.Instance.anyAreaDisabled == false)
        {
            ShakeObject();

            if (timer > 0)
            {
                timer -= Time.deltaTime;

                if (timer <= 0 && !actionExecuted)
                {
                    ExecuteAction();
                    actionExecuted = true;
                }
            }
        }
        else
        {
            if (timer < timeLook)
            {
                timer += Time.deltaTime;
                
                transform.localPosition = originalPosition;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            if (collision.CompareTag("Player"))
            {
                isPlayerOnPoint = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (actionExecuted == false)
            {
                isPlayerOnPoint = false;
            }
        }
    }

    private void ExecuteAction()
    {
        RealityRepair.Instance.anyAreaDisabled = true;
        gameObject.SetActive(false);
    }

    private void ShakeObject()
    {
        if (timer > 0)
        {
            float shakeAmountX = Random.Range(-1f, 1f) * shakeMagnitude;
            float shakeAmountY = Random.Range(-1f, 1f) * shakeMagnitude;
            transform.localPosition = new Vector3(originalPosition.x + shakeAmountX, originalPosition.y + shakeAmountY, originalPosition.z);
        }
        else
        {
            
            transform.localPosition = originalPosition;
        }
    }

    private void UpdateTransform(Vector3 newPosition)
    {
        originalPosition = newPosition;
    }

    public float GetTimer()
    {
        return timer;
    }
    public void SetTimer(float value)
    {

    timer = value; }

    public void SetActionExecute(bool value)
    {
        actionExecuted = value;
    }

    public float GetTimerLook()
    {
        return timeLook;
    }
}