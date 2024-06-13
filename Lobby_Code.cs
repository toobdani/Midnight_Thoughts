using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobby_Code : MonoBehaviour
{
    //Stores the LoadingCount script
    [SerializeField] LoadingCount LC;

    //Stores the different doorways in the lobby
    [SerializeField] GameObject[] Doorways;

    //Stores the chess pieces that appear in the centre
    [SerializeField] GameObject[] Pieces;

    //Stores the player
    [SerializeField] GameObject Player;

    //Stores the sound effects
    [SerializeField] GameObject[] ticking;

    //Stores the background music
    [SerializeField] AudioSource Music;

    //Stores a float value array for the different pitches and volumes of the audio
    [SerializeField] float[] Musicvolume;
    [SerializeField] float[] Musicpitch;

    //Stores the lights that appear by the doorway
    [SerializeField] GameObject[] StageLights;

    //Stores the god rays and the spot light attatched to them
    [SerializeField] GameObject CentreLight;
    [SerializeField] GameObject CentreSpot;

    //Stores the scenes notes
    [SerializeField] GameObject[] Notes;

    //Calls the FinalSequence script
    [SerializeField] FinalSequence FS;

    //Stores the roof
    [SerializeField] GameObject Roof;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the activity of the area's items.
        Doorways[2].SetActive(true);
        Doorways[1].SetActive(false);
        Doorways[0].SetActive(false);
        Doorways[3].SetActive(true);
        Doorways[4].SetActive(false);
        Doorways[5].SetActive(false);

        Pieces[0].SetActive(false);
        Pieces[1].SetActive(false);
        Pieces[2].SetActive(false);

        StageLights[0].SetActive(false);
        StageLights[1].SetActive(false);
        CentreLight.SetActive(false);
        CentreSpot.SetActive(false);

        Roof.SetActive(true);

        StartChecks();

    }

    // Update is called once per frame
    void Update()
    {
        //This will check what pieces have been collected, and change the scene based on that.
        if (LC.Pieces[0] == true && FS.cutscene_End == false)
        {
            CentreLight.SetActive(true);
            CentreSpot.SetActive(true);
        }
        if (LC.Pieces[1] == true)
        {
            Doorways[2].SetActive(false);
            Doorways[1].SetActive(true);
            Doorways[0].SetActive(false);
        }
        if(LC.Pieces[2] == true)
        {
            Doorways[3].SetActive(false);
            Doorways[5].SetActive(true);
            Doorways[4].SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Checks what pieces have been collected and activates elements of the stage.
        if(LC.Pieces[0] == true && LC.Pieces[1] == false)
        {
            Pieces[0].SetActive(true);
            Doorways[2].SetActive(false);
            Doorways[1].SetActive(false);
            Doorways[0].SetActive(true);
            StageLights[0].SetActive(true);
            LC.LobbyPieces[0] = true;
        }
        if(LC.Pieces[1] == true && LC.Pieces[2] == false)
        {
            Pieces[1].SetActive(true);
            Doorways[3].SetActive(false);
            Doorways[5].SetActive(false);
            Doorways[4].SetActive(true);
            StageLights[1].SetActive(true);
            LC.LobbyPieces[1] = true;
        }
        if(LC.Pieces[2] == true)
        {
            Pieces[2].SetActive(true);
            LC.LobbyPieces[2] = true;
            FS.Cutscene();
        }
    }

    void StartChecks()
    {
        //Called in the start function and activates elements of the room.
        if (LC.LobbyPieces[0] == true)
        {
            Pieces[0].SetActive(true);
        }
        else
        {
            Pieces[0].SetActive(false);
        }

        if (LC.LobbyPieces[1] == true)
        {
            Pieces[1].SetActive(true);
        }
        else
        {
            Pieces[1].SetActive(false);
        }

        if (LC.LobbyPieces[2] == true)
        {
            Pieces[2].SetActive(true);
        }
        else
        {
            Pieces[2].SetActive(false);
        }

        if(LC.Pieces[0] == false)
        {
            Player.transform.position = new Vector3(90.6071777f, 20.9424133f, 177.316711f);
            Music.volume = Musicvolume[0];
            Music.pitch = Musicpitch[0];
            ticking[0].SetActive(false);
            ticking[1].SetActive(false);
            Notes[0].SetActive(true);
            Notes[1].SetActive(false);
        }

        if(LC.Pieces[1] == true && LC.Pieces[2] == false)
        {
            Player.transform.position = new Vector3(139.600006f, 21.7199993f, 186.899994f);
            Music.volume = Musicvolume[1];
            Music.pitch = Musicpitch[1];
            ticking[0].SetActive(true);
            ticking[1].SetActive(false);
            Notes[0].SetActive(false);
            Notes[1].SetActive(false);
        }

        if(LC.Pieces[2] == true)
        {
            Player.transform.position = new Vector3(139.600006f, 21.7199993f, 166);
            Music.volume = Musicvolume[2];
            Music.pitch = Musicpitch[2];
            ticking[0].SetActive(false);
            ticking[1].SetActive(true);
            ticking[2].SetActive(true);
            Notes[0].SetActive(false);
            Notes[1].SetActive(true);
            Roof.SetActive(false);
        }

    }
}
