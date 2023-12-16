using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SlimeFollow : MonoBehaviour
{
    
    private Vector3 _destination = new Vector3(0, 0,0);
    private bool _isCharging = false;
    private float _angle = 0f;
    private Vector3 _playerPosition;

    private void Awake()
    {
       
    }
    private void FixedUpdate()
    {
        GoToDestination();
        
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;
        _isCharging = true;
        var player = collision.gameObject.GetComponent<ThirdPersonController>();
        player.PlayMusic(player.combatClip);
        if (player != null)
        {
            UpdatePlayerPosition(collision.gameObject.transform.position);
            ChangeDirectionByPlayerDirection();

        }
            
    }

    private void OnTriggerExit(Collider collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;
        _isCharging = false;
        var player = collision.gameObject.GetComponent<ThirdPersonController>();
        player.PlayMusic(player.ExplorationClip);
        if(player != null)
            UpdatePlayerPosition(collision.gameObject.transform.position);
    }

    private void OnTriggerStay(Collider collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;
        _destination = collision.transform.position;
    }

    private void GoToDestination()
    {
        if (_destination.magnitude == 0)
            return;
        //_rb.MovePosition(Vector3.MoveTowards(_rb.position, (_isCharging ? _destination : _rb.position), Time.deltaTime * 3));
    }

    public void UpdatePlayerPosition(Vector3 position)
    {
        _playerPosition = position;
    }

    public void ChangeDirectionByPlayerDirection()
    {
        transform.parent.LookAt(_playerPosition);
    }
}
