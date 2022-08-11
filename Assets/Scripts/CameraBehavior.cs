using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 camOffSet = new Vector3(0f, 1.2f, -2.6f);
    private Transform _target;

    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform; ;
    }

    void LateUpdate()
    {
        this.transform.position = _target.TransformPoint(camOffSet);
        this.transform.LookAt(_target);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
