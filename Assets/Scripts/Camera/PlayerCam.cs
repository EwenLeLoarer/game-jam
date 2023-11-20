using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class PlayerCam : MonoBehaviour
{
    public Transform FollowTarget;
    public Transform Player;
    public Transform PlayerObject;
    public Rigidbody rb;

    public Vector2 _move;
    public Vector2 _look;

    private InputPlayer inputPlayer;
    private InputPlayer.OnFootActions onFoot;

    public float RotationSpeed;
    public float RotationPower;
    private void Awake()
    {
        inputPlayer = new InputPlayer();
        onFoot = inputPlayer.OnFoot;
    }
    private void Start()
    {

        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
       
    }
     public void OnMove(InputValue value)
    {
        _move = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        _look = value.Get<Vector2>();
    }

    private void Update()
    {
        TurnPlayer(onFoot.Movement.ReadValue<Vector2>());
        RotateCam(onFoot.Look.ReadValue<Vector2>()); FollowTarget.rotation *= Quaternion.AngleAxis(_look.x * RotationPower, Vector3.up);




        FollowTarget.rotation *= Quaternion.AngleAxis(_look.y * RotationPower, Vector3.right);

        var angles = FollowTarget.localEulerAngles;
        angles.z = 0;

        var angle = FollowTarget.localEulerAngles.x;

        //Clamp the Up/Down rotation
        if (angle > 180 && angle < 340)
        {
            angles.x = 340;
        }
        else if (angle < 180 && angle > 40)
        {
            angles.x = 40;
        }


        FollowTarget.localEulerAngles = angles;


        //Set the player rotation based on the look transform
        transform.rotation = Quaternion.Euler(0, FollowTarget.rotation.eulerAngles.y, 0);
        //reset the y rotation of the look transform
        FollowTarget.localEulerAngles = new Vector3(angles.x, 0, 0);


        //Set the player rotation based on the look transform
        transform.rotation = Quaternion.Euler(0, FollowTarget.rotation.eulerAngles.y, 0);
        //reset the y rotation of the look transform
        FollowTarget.localEulerAngles = new Vector3(angles.x, 0, 0);

    }
   

    public void TurnPlayer(Vector2 input)
    {
        FollowTarget.Rotate(Vector3.zero);
        Vector3 viewDir = Player.position - new Vector3(transform.position.x, Player.position.y, transform.position.z);
        //FollowTarget.forward = viewDir;
        Vector3 inputDir = FollowTarget.forward * input.y + FollowTarget.right * input.x;
        
        if(inputDir != Vector3.zero)
        {
            PlayerObject.forward = Vector3.Slerp(PlayerObject.forward, inputDir.normalized, Time.deltaTime * RotationSpeed);

        }
    }
    public void RotateCam(Vector2 value)
    {
        
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
