using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note_Code : MonoBehaviour
{
    //Stores the note image that appears on screen
    [SerializeField] GameObject NoteUI;

    //Stores movementTest
    [SerializeField] movementTest MT;

    // Start is called before the first frame update
    void Start()
    {
        //Turns the note off at the start of the game
        NoteUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //If the note is visible then it will be removed after the player clicks the screen
        if(NoteUI.activeSelf == true)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                NoteUI.SetActive(false);
                StartCoroutine(WaittoMove());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //When triggered the note appears on screen and the player can't move
        NoteUI.SetActive(true);
        MT.MoveAllow = 1;
    }

    IEnumerator WaittoMove()
    {
        //The code waits 0.1 seconds after clicking to reactivate movement before destroying the note gameobject.
        yield return new WaitForSeconds(0.1f);
        MT.MoveAllow = 0;
        Destroy(gameObject);
    }
}
