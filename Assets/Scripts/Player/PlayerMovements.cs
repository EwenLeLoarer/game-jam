using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    
    //private Vector3 velocity;

    public float MoveSpeed = 5f;
    private Rigidbody _rb;


    // Start is called before the first frame update
    void Start()
    {
        //controller = GetComponent<CharacterController>();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void MovePlayer(Vector2 input)
    {
       

        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        _rb.velocity = moveDirection * MoveSpeed;
        //controller.Move(transform.TransformDirection(moveDirection) * MoveSpeed * Time.deltaTime);
    }
}
