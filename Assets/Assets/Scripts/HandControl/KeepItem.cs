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

    private void OnTriggerExit(Collider other)
    {
        if (!HandControl.Instance.isHolder)
        {
            HandControl.Instance.setItemHolder(null);
        }
    }

}
