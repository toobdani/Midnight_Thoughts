using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perspectiveWallRemove : MonoBehaviour
{
    [SerializeField] CameraSwap CS;

    [SerializeField] Material[] T;
    // Update is called once per frame
    void Update()
    {
        switch(gameObject.tag)
        {
            case "OCamera1":
                {
                    //CS.Walls[0].layer = 0;
                    foreach (MeshRenderer M in CS.Walls[0].GetComponentsInChildren<MeshRenderer>())
                    {
                        if(M.gameObject.tag != "Wall")
                        {
                            M.material = T[0];
                        }
                    }
                    //CS.Walls[1].layer = 0;
                    foreach (MeshRenderer M in CS.Walls[1].GetComponentsInChildren<MeshRenderer>())
                    {
                        if (M.gameObject.tag != "Wall")
                        {
                            M.material = T[0];
                        }
                    }
                    foreach (MeshRenderer M in CS.Walls[2].GetComponentsInChildren<MeshRenderer>())
                    {
                        if (M.gameObject.tag != "Wall")
                        {
                            M.material = T[1];
                        }
                    }
                    //CS.Walls[2].layer = 3; 
                    //CS.Walls[3].layer = 3;
                    foreach (MeshRenderer M in CS.Walls[3].GetComponentsInChildren<MeshRenderer>())
                    {
                        if (M.gameObject.tag != "Wall")
                        {
                            M.material = T[1];
                        }
                    }
                }
                break;
            case "OCamera2":
                {
                    foreach (MeshRenderer M in CS.Walls[0].GetComponentsInChildren<MeshRenderer>())
                    {
                        if (M.gameObject.tag != "Wall")
                        {
                            M.material = T[1];
                        }
                    }
                    //CS.Walls[0].layer = 3;
                    foreach (MeshRenderer M in CS.Walls[1].GetComponentsInChildren<MeshRenderer>())
                    {
                        if (M.gameObject.tag != "Wall")
                        {
                            M.material = T[1];
                        }
                    }
                    //CS.Walls[1].layer = 3;
                    //CS.Walls[2].layer = 0;
                    foreach (MeshRenderer M in CS.Walls[2].GetComponentsInChildren<MeshRenderer>())
                    {
                        if (M.gameObject.tag != "Wall")
                        {
                            M.material = T[0];
                        }
                    }
                    //CS.Walls[3].layer = 0;
                    foreach (MeshRenderer M in CS.Walls[3].GetComponentsInChildren<MeshRenderer>())
                    {
                        if (M.gameObject.tag != "Wall")
                        {
                            M.material = T[0];
                        }
                    }
                }
                break;
        }
    }
}
