using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_Code_Triggers : MonoBehaviour
{
    public bool Triggered;

    public bool Swapped;

    [SerializeField] bool Rotating;

    [SerializeField] movementTest MT;
    // Start is called before the first frame update
    void Start()
    {
        MT = GameObject.FindGameObjectWithTag("Player").GetComponent<movementTest>();
    }

    // Update is called once per frame
    void Update()
    {
        if(MT.MoveAllow != 0)
        {
            Rotating = true;
        }
        else
        {
            Rotating = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Triggered = true;
        if(Swapped == true || Rotating == true)
        {
            Triggered = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Triggered = false;
        if(Swapped == true)
        {
            Swapped = false;
        }
    }
}
