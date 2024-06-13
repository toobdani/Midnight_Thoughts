using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRoomStairs : MonoBehaviour
{
    [SerializeField] GameObject[] ModelTemp;

    [SerializeField] GameObject[] StairModel;

    [SerializeField] Material[] MaterialTemp;

    public Material[] StairMaterials;
    // Start is called before the first frame update
    void Start()
    {
        StairMaterials[0].SetFloat("_Visbility", 15f);
        StairMaterials[1].SetFloat("_Visbility", 15f);
        StairMaterials[2].SetFloat("_Visbility", 0.7f);
        StairMaterials[3].SetFloat("_Visbility", 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveMaterialUp()
    {
        for (int ArrayNumber = 0; ArrayNumber < 4; ArrayNumber++)
        {
            ModelTemp[ArrayNumber] = StairModel[ArrayNumber];
            MaterialTemp[ArrayNumber] = StairMaterials[ArrayNumber];
        }

        for (int ArrayNumber = 0; ArrayNumber < 4; ArrayNumber++)
        {
            StairModel[ArrayNumber + 1] = ModelTemp[ArrayNumber];
            StairMaterials[ArrayNumber + 1] = MaterialTemp[ArrayNumber];
            if (ArrayNumber == 3)
            {
                StairModel[0] = ModelTemp[3];
                StairModel[4] = null;
                StairMaterials[0] = MaterialTemp[3];
                StairMaterials[4] = null;
            }
        }
    }

    public void MoveMaterialDown()
    {
        for (int ArrayNumber = 3; ArrayNumber >= 0; ArrayNumber--)
        {
            ModelTemp[ArrayNumber] = StairModel[ArrayNumber];
            MaterialTemp[ArrayNumber] = StairMaterials[ArrayNumber];
        }

        for (int ArrayNumber = 3; ArrayNumber >= 0; ArrayNumber--)
        {
            switch (ArrayNumber)
            {
                case 0:
                    {
                        StairModel[3] = ModelTemp[0];
                        StairModel[4] = null;
                        StairMaterials[3] = MaterialTemp[0];
                        StairMaterials[4] = null;
                    }
                    break;
                default:
                    {
                        StairMaterials[ArrayNumber - 1] = MaterialTemp[ArrayNumber];
                        StairModel[ArrayNumber - 1] = ModelTemp[ArrayNumber];
                    }
                    break;
            }
            Debug.Log(ArrayNumber);
        }
    }

    public void ChangeStairsLeft()
    {
        StairMaterials[0].SetFloat("_Visbility", 15f);
        StairMaterials[1].SetFloat("_Visbility", 15f);
        StairMaterials[2].SetFloat("_Visbility", 0.7f);
        StairMaterials[3].SetFloat("_Visbility", 0.7f);
    }

}
