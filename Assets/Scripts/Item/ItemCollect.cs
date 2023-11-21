using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector2 _destination = new Vector2(0, 0);
    private bool _isCollecting = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        GoToDestination();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.gameObject.CompareTag("collect"))
            return;
        _isCollecting = true;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (!collision.gameObject.CompareTag("collect"))
            return;
        _isCollecting = false;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (!collision.gameObject.CompareTag("collect"))
            return;
        _destination = collision.transform.position;
    }

    private void GoToDestination()
    {
        if (_destination.magnitude == 0)
            return;
        _rb.MovePosition(Vector3.MoveTowards(_rb.position, (_isCollecting ? _destination : _rb.position), Time.deltaTime * 2));
    }
}
