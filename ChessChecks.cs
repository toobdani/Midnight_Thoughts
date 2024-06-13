using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessChecks : MonoBehaviour
{
    //Stores the images for the Check UI
    [SerializeField] GameObject[] PawnCheck;
    [SerializeField] GameObject[] KnightCheck;
    [SerializeField] GameObject[] QueenCheck;

    //The text that appears on screen.
    [SerializeField] GameObject CollectChessPiece;
    [SerializeField] GameObject ReturntoCentre;

    //The LoadingCount Script
    [SerializeField] LoadingCount LC;

    //This bool tracks what area the player is in
    [SerializeField] bool[] area;
    // Start is called before the first frame update
    void Start()
    {
        //Sets the text as false
        CollectChessPiece.SetActive(false);
        ReturntoCentre.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Takes it in turn checking which piece is collected and adapts the code based on that. 
        if (LC.Pieces[0] == true)
        {
            PawnCheck[0].SetActive(false);
        }
        if (LC.LobbyPieces[0] == true)
        {
            PawnCheck[1].SetActive(true);
        }


        if (LC.Pieces[1] == true)
        {
            KnightCheck[0].SetActive(false);
        }
        if (LC.LobbyPieces[1] == true)
        {
            KnightCheck[1].SetActive(true);
        }

        if (LC.Pieces[2] == true)
        {
            QueenCheck[0].SetActive(false);
        }
        if (LC.LobbyPieces[2] == true)
        {
            QueenCheck[1].SetActive(true);
        }

        //It tracks the area of the game and displays the text 
        if (area[0] == true)
        {
            if (LC.Pieces[0] == false)
            {
                CollectChessPiece.SetActive(true);
                ReturntoCentre.SetActive(false);
            }
            if (LC.Pieces[0] == true)
            {
                CollectChessPiece.SetActive(false);
                ReturntoCentre.SetActive(true);
            }
            if (LC.LobbyPieces[0] == true)
            {
                CollectChessPiece.SetActive(false);
                ReturntoCentre.SetActive(false);
                area[0] = false;
            }
        }
        else if (area[1] == true)
        {
            if (LC.Pieces[1] == false)
            {
                CollectChessPiece.SetActive(true);
                ReturntoCentre.SetActive(false);
            }
            if (LC.Pieces[1] == true)
            {
                CollectChessPiece.SetActive(false);
                ReturntoCentre.SetActive(true);
            }
            if (LC.LobbyPieces[1] == true)
            {
                CollectChessPiece.SetActive(false);
                ReturntoCentre.SetActive(false);
                area[1] = false;
            }
        }        
        else if (area[2] == true)
        {
            if (LC.Pieces[2] == false)
            {
                CollectChessPiece.SetActive(true);
                ReturntoCentre.SetActive(false);
            }
            if (LC.Pieces[2] == true)
            {
                CollectChessPiece.SetActive(false);
                ReturntoCentre.SetActive(true);
            }
            if (LC.LobbyPieces[2] == true)
            {
                CollectChessPiece.SetActive(false);
                ReturntoCentre.SetActive(false);
                area[2] = false;
            }
        }

    }
}
