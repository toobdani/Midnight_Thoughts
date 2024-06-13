using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Portal_Code : MonoBehaviour
{
    [SerializeField] GameObject Portal_A;

    [SerializeField] GameObject Portal_B;

    [SerializeField] Portal_Code_Triggers PCT_A;

    [SerializeField] Portal_Code_Triggers PCT_B;

    [SerializeField] Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PCT_A.Triggered == true)
        {
            PCT_B.Swapped = true;
            Player.transform.position = Portal_B.transform.position;
        }

        if(PCT_B.Triggered == true)
        {
            PCT_A.Swapped = true;
            Player.transform.position = Portal_A.transform.position;
        }
    }

}
