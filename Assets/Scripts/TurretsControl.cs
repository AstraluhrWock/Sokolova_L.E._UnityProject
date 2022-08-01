using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretsControl : MonoBehaviour
{
    private Transform _player;
    private float _distance;

    public float howClose;
    public Transform head;
    public Transform barrel;
    public GameObject shells;
    public float fireRate = 2f;
    public float nextFire = 2f;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        _distance = Vector3.Distance(_player.position, transform.position);
        if (_distance <= howClose)
        {
            head.LookAt(_player);
            if (Time.time >= nextFire)
            {
                nextFire = Time.time + 1f / fireRate;
                Shooting();
            }

        }
    }

    void Shooting()
    {
        GameObject clone = Instantiate(shells, barrel.position, head.rotation);
        clone.GetComponent<Rigidbody>().AddForce(head.forward * 1000);
        Destroy(clone, 10);
    }
}
