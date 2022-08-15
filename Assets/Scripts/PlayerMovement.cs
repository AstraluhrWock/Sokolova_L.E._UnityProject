using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float angularSpeed = 20f;

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string running = "Running";
    //private const string mouseX = "Mouse X";

    

    private bool isRunning;

    private Vector3 _jump;
    private float jumpForce = 2.0f;
    private bool isGrounded;

    private Rigidbody _rb;
    private Animator _animator;
    private Vector3 _direction;
    private AudioSource _source;
    private Quaternion _rotation = Quaternion.identity;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _jump = new Vector3(0.0f, 2.0f, 0.0f);
        _source = GetComponent<AudioSource>();

    }

    private void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void Move()
    {
        _direction.x = Input.GetAxis(horizontal);
        _direction.z = Input.GetAxis(vertical);
        isRunning = Input.GetButton(running);

        _direction.Set(_direction.x, 0f, _direction.z);
        _direction.Normalize();

        transform.position += _direction * ((isRunning ? runSpeed : speed) * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _rb.AddForce(_jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }


        bool hasHorizontalInput = !Mathf.Approximately(_direction.x, 0f);
        bool hasVerticalInput = !Mathf.Approximately(_direction.z, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        _animator.SetBool("IsWalking", isWalking);

        if (isWalking)
        {
            if (_source.isPlaying)
            {
                _source.Play();
            }
        }
        else
        {
            _source.Stop();
        }
    }

    private void Rotate()
    {
        //    rotationDirection.y = Input.GetAxis(mouseX) * angularSpeed * Time.deltaTime;
        //    transform.Rotate(rotationDirection);

         Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _direction, angularSpeed * Time.deltaTime, 0f);
        _rotation = Quaternion.LookRotation(desiredForward);
    }

    private void Update()
    {
        Move();
        //Rotate();
    }

    private void OnAnimatorMove()
    {
        _rb.MovePosition(_rb.position + _direction *_animator.deltaPosition.magnitude);
        _rb.MoveRotation(_rotation);
    }

}
