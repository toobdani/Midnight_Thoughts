using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class RotatePosition
{
    public Vector3 CPosition;
    public Quaternion CRotation;

    public RotatePosition(Vector3 g, Quaternion q)
    {
        CPosition = g;
        CRotation = q;
    }
}
