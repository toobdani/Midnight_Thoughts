using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairBorder : MonoBehaviour
{
    [SerializeField] movementTest MT;
    [SerializeField] GameObject Border;
    [SerializeField] GameObject Steps;
    // Start is called before the first frame update
    void Start()
    {
        Border.SetActive(false);
        if (Steps == null) return;
        Steps.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (MT.MoveAllow != 0)
        {
            Border.SetActive(false);
            if (Steps == null) return;
            Steps.SetActive(false);
        }
        else
        {
            if (Steps == null) return;
            Steps.SetActive(true);
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player" && MT.MoveAllow != 0) return;
        
        Border.SetActive(true); 
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        
        Border.SetActive(false);
        
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "Player" && MT.MoveAllow != 0) return;
        Border.SetActive(true);
    }*/
}
