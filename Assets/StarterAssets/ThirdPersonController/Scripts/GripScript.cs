using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripScript : MonoBehaviour
{
    // Start is called before the first frame update
    public ThirdPersonController PlayerScript;
    public bool canGrip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grip"))
        {

        }
    }


}
