using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "JohnLemon")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Item collect");
        }
    }
}
