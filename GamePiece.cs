using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    //This stores what numbered piece the player is collecting
    [SerializeField] int PieceNumber;

    //Stores the asset version of LoadingCount
    [SerializeField] LoadingCount LC;

    //Stores the Parent of the script.
    [SerializeField] GameObject Parent;


    // Update is called once per frame
    void Update()
    {
        //if the player has picked up this piece before it won't appear
        if(LC.Pieces[PieceNumber] == true)
        {
            Parent.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //When colliding with the piece the Piece's bool is marked as true in LC and the scene changes back to the lobby by calling ChangeScene
        LC.Pieces[PieceNumber] = true;

        if(PieceNumber != 0)
        {
            LC.ChangeScene(1);
        }

    }
}
