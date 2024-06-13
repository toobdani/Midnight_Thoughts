using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepUp : MonoBehaviour
{
    [SerializeField] movementTest MT;

    //The code checks if the collider is triggered and sets Triggered's value based on this.
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Stair")
        {
            MT.Triggered = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Stair")
        {
            MT.Triggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        MT.Triggered = false;
    }
}
