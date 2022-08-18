using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    private GameObject gameObject;
    private Camera cam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = cam.ScreenPointToRay(Input.mousePosition);
            Vector3 dir = r.GetPoint(1) - r.GetPoint(0);
            GameObject ammo = Instantiate(gameObject, r.GetPoint(2), Quaternion.LookRotation(dir));
            ammo.GetComponent<Rigidbody>().velocity = ammo.transform.forward * 20;
            Destroy(ammo, 3);
        }
    }
}
