using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private bool _touchingDoor = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _touchingDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _touchingDoor = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("e") && _touchingDoor)
        {
            Debug.Log("Door opens");
        }
    }
}
