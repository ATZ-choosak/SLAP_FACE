using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHand : MonoBehaviour
{
    public float velocityValue;
    Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 F = new Vector3(Input.GetAxisRaw("Mouse X") , Input.GetAxisRaw("Mouse Y") , 0);
        velocityValue = (F.magnitude / body.mass) * Time.fixedDeltaTime * 1000;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("head_enemy"))
        {
            if (velocityValue > 3.0f)
            {
                TurnBaseUIHandler.Instance.takeDamageToEnemy((int)(velocityValue * Random.Range(0.1f, 5.0f)));
                AnimationEnemy.Instance.takeAnimation();
            }
            
        }
    }
}
