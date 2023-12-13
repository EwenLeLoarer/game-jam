using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeFollow : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _destination = new Vector3(0, 0,0);
    private bool _isCharging = false;

    private void Awake()
    {
        _rb = GetComponentInParent<Rigidbody>();
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
    }

    private void OnTriggerExit(Collider collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;
        _isCharging = false;
        var player = collision.gameObject.GetComponent<ThirdPersonController>();
        player.PlayMusic(player.ExplorationClip);
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
        _rb.MovePosition(Vector3.MoveTowards(_rb.position, (_isCharging ? _destination : _rb.position), Time.deltaTime * 3));
    }
}
