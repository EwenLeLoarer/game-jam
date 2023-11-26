using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
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
            else { Die(); }
        }
    }

    [SerializeField] public HealthBar HealthBar;
    private void Die()
    {
       Destroy(this.gameObject);
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
