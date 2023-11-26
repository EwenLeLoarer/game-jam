using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<ThirdPersonController>();
            player.ActualHP--;
            player.HealthBar.UpdateHealthBar(player.MaxHP, player.ActualHP);
        }
    }
}
