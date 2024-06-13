using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    //Stores the cameras within the scene
    public GameObject[] Cameras;

    //Changes the camera set
    public bool Cameratype;

    //Stores the walls of the rotating room
    public GameObject[] Walls;

    //Contains the materials of the walls.
    public Material[] WallMaterials;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Swaps between the cameras based on the value of Cameratype
        Cameras[0].SetActive(Cameratype == true);
        Cameras[1].SetActive(Cameratype == false);
    }

    public void change()
    {
        //This function was called in other scripts and inverts the value of Cameratype.
        Cameratype = !(Cameratype);
    }
}
