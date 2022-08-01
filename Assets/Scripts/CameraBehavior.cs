using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 camOffSet = new Vector3(0f, 1.2f, -2.6f);
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("JohnLemon").GetComponent<PlayerMovement>().transform;
    }

    void LateUpdate()
    {
        this.transform.position = target.TransformPoint(camOffSet);
        this.transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
