using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Entity : MonoBehaviour
{
    public GameObject Ragdoll = null;
    public int MaxHP;
    public int ActualHP
    {
        get { return _actualHP; }
        set
        {
            if (value > 0 && value <= MaxHP)
            {
                _actualHP = value;
            }
            else {
                Die();

            }
        }
    }

    [SerializeField] public HealthBar HealthBar;
    private void Die()
    {
        if (this.gameObject.CompareTag("Player"))
        {
            this.gameObject.GetComponent<Animator>().enabled = false;
            this.gameObject.GetComponent<CharacterController>().enabled = false;
            this.gameObject.GetComponent<PlayerInput>().enabled = false;
            this.gameObject.GetComponent<ThirdPersonController>().enabled = false;
            Collider[] RagdollCollider = Ragdoll.GetComponentsInChildren<Collider>();
            Rigidbody[] RagdollRigidBody = Ragdoll.GetComponentsInChildren<Rigidbody>();
            foreach (Collider c in RagdollCollider)
            {
                c.enabled = true;
            }
            foreach (Rigidbody r in RagdollRigidBody)
            {
                r.isKinematic = false;
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    [SerializeField]
    private int _actualHP;
    void Start()
    {
        HealthBar.UpdateHealthBar(MaxHP, _actualHP);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
