using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCameraTrigger : MonoBehaviour
{
    [SerializeField] LobbyCameraSwap LCS;

    [SerializeField] int swapnumber;

    private void OnTriggerEnter(Collider other)
    {
        LCS.SwapCamera = swapnumber;
    }
}
