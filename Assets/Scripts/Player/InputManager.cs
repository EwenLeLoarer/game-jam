using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    private InputPlayer inputPlayer;
    private InputPlayer.OnFootActions onFoot;
    private PlayerCam _playerCam;
    private void Awake()
    {
        inputPlayer = new InputPlayer();
        onFoot = inputPlayer.OnFoot;
        _playerCam = GetComponent<PlayerCam>();
    }

    private void Update()
    {
        //_playerCam.MovePlayer(onFoot.Movement.ReadValue<Vector2>());
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
