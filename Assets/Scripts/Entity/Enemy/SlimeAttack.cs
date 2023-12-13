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

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            var player = collision.gameObject.GetComponent<ThirdPersonController>();
            player.ActualHP--;
            player.PlayDamageSound();
            player.HealthBar.UpdateHealthBar(player.MaxHP, player.ActualHP);
        }
    }
}
