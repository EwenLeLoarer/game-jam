using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class PlayerMovements : MonoBehaviour
{
    [Header("")]
    public float MoveSpeed;

    public Transform Orientation;
    public Transform FollowTarget;
    Vector3 moveDirection;
    Vector2 input;
    public Vector2 _move;
    public Vector2 _look;
    private InputPlayer inputPlayer;
    private InputPlayer.OnFootActions onFoot;

    public float rotationPower = 3f;
    public float rotationLerp = 0.5f;
    public Vector3 nextPosition;
    public Quaternion nextRotation;
    Rigidbody rb;

    private void Awake()
    {
        inputPlayer = new InputPlayer();
        onFoot = inputPlayer.OnFoot;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    public void OnLook(InputValue value)
    {
        _look = value.Get<Vector2>();
    }
    public void OnMovement(InputValue value)
    {
        _move = value.Get<Vector2>();
    }

    private void Update()
    {
        input = onFoot.Movement.ReadValue<Vector2>(); 
        Rotate( onFoot.Look.ReadValue<Vector2>());
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();

    }

    public void MovePlayer()
    {
       
        moveDirection = Orientation.forward * input.y + Orientation.right * input.x;

        rb.AddForce(moveDirection.normalized * MoveSpeed * 10f, ForceMode.Force);
        /*Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        Vector3 forward = _freeLookCamera.transform.forward;
        Vector3 right = _freeLookCamera.transform.right;
        forward.y = 0f; // Prevents player from flying when looking up/down
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        moveDirection = forward * input.y + right * input.x;
        moveDirection.Normalize();*/
        
        //controller.Move(transform.TransformDirection(moveDirection) * MoveSpeed * Time.deltaTime);
    }

    public void Rotate(Vector2 input)
    {
        //Rotate the Follow Target transform based on the input
        
    }
    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
