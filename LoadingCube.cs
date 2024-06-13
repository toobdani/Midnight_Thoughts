using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCube : MonoBehaviour
{
    [SerializeField] int loopcount;


    public Transform T;
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float z;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Rotate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Rotate()
    {
        T.transform.Rotate(x -= 0.1f, y += 0.1f, z -= 0.1f, Space.World);
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Rotate());

    }
}
