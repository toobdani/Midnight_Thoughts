using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Buttons_code : MonoBehaviour
{

    [SerializeField] GameObject CreditImage;
    // Start is called before the first frame update
    void Start()
    {
        CreditImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(CreditImage.activeSelf == true)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                CreditImage.SetActive(false);
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(5);
    }

    public void Credits()
    {
        CreditImage.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("End Game");
    }
}
