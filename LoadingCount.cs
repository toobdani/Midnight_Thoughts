using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "LoadingObject", order = 3, fileName = "Loading Count")]
public class LoadingCount : ScriptableObject
{
    //Contains the number of the lobby in the build settings
    [SerializeField] int Lobby;

    //Stores the number of the room the player is moving to 
    public int Going;

    //Stores the number of the piece interacting with the script
    public int PieceNumber;

    //Stores an array of bools for if the pieces have been collected
    public bool[] Pieces;

    //Stores an array of bools for if the pieces have been placed in the lobby
    public bool[] LobbyPieces;


    public void ChangeScene(int Location)
    {
        //Sends the player to the loading screen and sets Going as the target room location
        Going = Location;
        SceneManager.LoadScene(4);
    }
}
