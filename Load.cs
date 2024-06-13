using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    [SerializeField] LoadingCount LC;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadSceneAsync(LC.Going);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
