using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
 

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "JohnLemon")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Item collect");
        }
    }
}
