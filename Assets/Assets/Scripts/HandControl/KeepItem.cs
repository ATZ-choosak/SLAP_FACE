using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepItem : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            if (!HandControl.Instance.isHolder)
            {
                HandControl.Instance.setItemHolder(other.gameObject);
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box_start"))
        {
            TurnBaseUIHandler.Instance.startTurnBase();
            print("test");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!HandControl.Instance.isHolder)
        {
            HandControl.Instance.setItemHolder(null);
        }
    }

}
