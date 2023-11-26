using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    public void UpdateHealthBar(float MaxHealth, float currentHealth)
    {
        _healthBar.fillAmount = currentHealth / MaxHealth;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _camera.transform.position);
    }
}
