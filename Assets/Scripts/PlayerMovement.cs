using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float runSpeed = 5f;

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string running = "Running";

    private Vector3 direction;
    private bool isRunning;

    private Vector3 jump;
    private float jumpForce = 2.0f;
    private bool isGrounded;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

    }

    private void OnCollisionStay()
    {
        isGrounded = true;
    }


    private void Update()
    {
        direction.x = Input.GetAxis(horizontal);
        direction.z = Input.GetAxis(vertical);


        isRunning = Input.GetButton(running);
        transform.position += direction * ((isRunning ? runSpeed : speed) * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        //if (direction.magnitude >= 0.1f)
        //{
        //    float playerRotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        //    transform.rotation = Quaternion.Euler(0f, playerRotation, 0f);

        //}
    }
}
