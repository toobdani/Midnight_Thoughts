using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningCutscene : MonoBehaviour
{
    [SerializeField] Animator[] OpeningAnimations;

    [SerializeField] int ClickCount;
    // Start is called before the first frame update
    void Start()
    {
        OpeningAnimations[0].SetBool("Appear", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            switch (ClickCount)
            {
                case 3:
                    {
                        SceneManager.LoadScene(1);
                    }
                    break;
                case 2:
                    {
                        OpeningAnimations[3].SetBool("Appear", true);
                        OpeningAnimations[2].SetBool("Fade", true);
                        OpeningAnimations[1].SetBool("Fade", true);
                        OpeningAnimations[0].SetBool("Fade", true);
                        ClickCount++;

                    }
                    break;
                case 1:
                    {
                        OpeningAnimations[2].SetBool("Appear", true);
                        ClickCount++;
                    }
                    break;
                case 0:
                    {
                        OpeningAnimations[1].SetBool("Appear", true);
                        ClickCount++;
                    }
                    break;
   
            }
        }
    }
}
