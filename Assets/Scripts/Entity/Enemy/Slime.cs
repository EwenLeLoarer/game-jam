using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Entity
{
    SlimeFollow follow;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        MaxHP = 5;
        ActualHP = MaxHP;
        follow = GetComponentInChildren<SlimeFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updatePlayerPosition()
    {
        follow.UpdatePlayerPosition(player.transform.position);
    }

    public void ChangeDirectionByPlayerDirection()
    {
        transform.LookAt(player.transform.position);
    }

}
