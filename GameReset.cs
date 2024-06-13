using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReset : MonoBehaviour
{
    //Stores the asset version of LoadingCount
    [SerializeField] LoadingCount LC;
    // Start is called before the first frame update
    void Update()
    {
        //Resets LC's bools values to false
        LC.Pieces[0] = false;
        LC.LobbyPieces[0] = false;        
        LC.Pieces[1] = false;
        LC.LobbyPieces[1] = false;        
        LC.Pieces[2] = false;
        LC.LobbyPieces[2] = false;
    }

}
