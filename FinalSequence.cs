using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSequence : MonoBehaviour
{
    public bool StartEnd;

    [SerializeField] movementTest MT;

    [SerializeField] GameObject EndScreen;

    [SerializeField] GameObject Ticking;
    [SerializeField] GameObject Footsteps;

    [SerializeField] GameObject Dong;

    [SerializeField] AudioSource BellSound;
    [SerializeField] float Volume;
   
    public Animator monster_animator;
    public Animator camera_animator;
    public Animator audio_animator;
    public Animator audio_Slam_animator;

    public Camera MainCamera;
    public Camera cutscene_Camera;

    public GameObject[] disable_objects;
    public GameObject[] enable_objects;

    [SerializeField] GameObject UI;

    public bool cutscene_End;
    // Start is called before the first frame update
    void Start()
    {
        cutscene_Camera.enabled = false;
        EndScreen.SetActive(false);
        Dong.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BellSound.volume = Volume;
        if (StartEnd == true)
        {
                EndScreen.SetActive(true);
                Ticking.SetActive(false);
                Footsteps.SetActive(false);
                Dong.SetActive(true);
                if (BellSound.volume > 0)
                {
                    Volume -= 0.000145f;
                }
                else
                {
                    SceneManager.LoadScene(0);
                }
            
        }
        if (this.camera_animator.GetCurrentAnimatorStateInfo(0).IsName("end"))
        {
            StartEnd = true;
        }
    }


    public void Cutscene()
    {
        cutscene_End = true;
        monster_animator.SetBool("cutscene_start", true);
        camera_animator.SetBool("cutscene_start", true);
        audio_animator.SetBool("cutscene_start", true);
        audio_Slam_animator.SetBool("cutscene_start", true);
        MainCamera.enabled = false;
        cutscene_Camera.enabled = true;
        UI.SetActive(false);
        MT.MoveAllow = 1;

        int diable_length = disable_objects.Length;
        int enable_length = enable_objects.Length;

        for (int i = 0; i < diable_length; i++)
        {
            disable_objects[i].SetActive(false);
        }

        for (int i = 0; i < enable_length; i++)
        {
            enable_objects[i].SetActive(true);
        }
        RenderSettings.fogDensity = 0.005f;
    }
}
