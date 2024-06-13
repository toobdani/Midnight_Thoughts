using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCameraSwap : MonoBehaviour
{

    [SerializeField] public List<RotatePosition> CameraLocation;

    public int SwapCamera;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localPosition = CameraLocation[1].CPosition;
        gameObject.transform.localRotation = CameraLocation[1].CRotation;
    }

    // Update is called once per frame
    void Update()
    {

            gameObject.transform.localPosition = CameraLocation[SwapCamera].CPosition;
            gameObject.transform.localRotation = CameraLocation[SwapCamera].CRotation;
    }
}
