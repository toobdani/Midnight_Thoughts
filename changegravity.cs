using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changegravity : MonoBehaviour
{
    //Stores the players Rigidbody
    Rigidbody R;
    //Stores the Rooms Transform
    public Transform T;

    //Stores the value to rotate the room by (set to 0)
    float x;
    float y;
    float z;

    //stores the value to rotate the x axis of the player
    float playerx;

    //Stores the CameraSwap script
    [SerializeField] CameraSwap CS;

    //Temporarily stores the data of the wall gameobjects when rotating
    [SerializeField] GameObject[] Temp;

    //Temporarily stores the material data of the walls
    [SerializeField] Material[] WallTemp;
    
    //Stores the movementTest script
    [SerializeField] movementTest MT;

    //Used to count the amount of loops when rotating
    [SerializeField] int loopcount;

    //Set when the player is in the portal level
    [SerializeField] bool portalRoom;

    //Stores the value to increase/decrease the material transparency
    [SerializeField] float Down;
    [SerializeField] float Up;

    //Stores the Player GameObject
    [SerializeField] GameObject Player;

    //Stores the script attatched to the stairs in the first room
    [SerializeField] FirstRoomStairs FRS;

    //The amount of time between loops
    [SerializeField] float RotateSpeed;

    //Used to calculate the rotation of the room automatically
    [SerializeField] float LoopCountAmount;
    [SerializeField] float RotateAmount;
    [SerializeField] float ChangeTrasnparent;

    // Start is called before the first frame update
    void Start()
    {
        //Sets it so the player is standing up
        Player.transform.rotation = new Quaternion(0, 0, 0, 0);

        //Sets the Rigidbody
        R = gameObject.GetComponent<Rigidbody>();
        //Stores x as the value of the room's x axis rotation
        x = T.transform.rotation.x;

        //Checks to see whether the room is the portal, then sets the transparency of the material to fit.
        if(portalRoom == false)
        {
             CS.WallMaterials[0].SetFloat("_Visbility", 15);
             CS.WallMaterials[1].SetFloat("_Visbility", 15);
             CS.WallMaterials[2].SetFloat("_Visbility", 0);
             CS.WallMaterials[3].SetFloat("_Visbility", 0);
        }
        else
        {
             CS.WallMaterials[0].SetFloat("_Visbility", 15);
             CS.WallMaterials[1].SetFloat("_Visbility", 15);
             CS.WallMaterials[2].SetFloat("_Visbility", 1f);
             CS.WallMaterials[3].SetFloat("_Visbility", 1f);
        }

        //Calculates the amount that the room should rotate each loop
        RotateAmount = 90 / LoopCountAmount;

        //Sets the value that the material should become transparent.
        if(portalRoom == false)
        {
            ChangeTrasnparent = 15 / LoopCountAmount;
        }
        else
        {
            ChangeTrasnparent = 14 / LoopCountAmount;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Checks whether the player is on the ground and can move.
        if (MT.Groundbool == true && MT.MoveAllow == 0)
        {
            //When left clicked the code sets the code to rotate the stage to the left. 
            if (Input.GetMouseButtonDown(0))
            {
                //Stops the players movement and freezes them in the air without being able to collide.
                MT.MoveAllow = 1;
                MT.MyRigidbody.velocity = new Vector3(0, 0, 0);
                MT.MyRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                MT.gameObject.layer = 7;
                //Restarts things so the loop begins fresh
                loopcount = 0;

                //Sets the values of Down and Up
                if (portalRoom == false)
                {
                    Down = 15f;
                    Up = 0f;
                }
                else
                {
                    Down = 15f;
                    Up = 1f;
                }

                //Starts the rotation loop which is done via a coroutine
                StartCoroutine(LeftRotate());

                //Checks which room the player is in, then either moves the wall up or down the array.
                if(portalRoom == false)
                {
                    MoveArrayup();
                }
                else
                {
                    MoveArrayDown();
                }
                //Checks if the value of the FRS variable is null or not, if not null it then calls a function from it.
                if(FRS != null)
                {
                    FRS.MoveMaterialUp();
                }
            }

            //When right clicked the code sets the code to rotate the stage to the right.
            if (Input.GetMouseButtonDown(1))
            {
                //Stops the players movement and freezes them in the air without being able to collide.
                MT.MoveAllow = 1;
                MT.MyRigidbody.velocity = new Vector3(0, 0, 0);
                MT.MyRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                MT.gameObject.layer = 7;
                //Restarts things so the loop begins fresh
                loopcount = 0;

                //Sets the value for Down and Up
                if (portalRoom == false)
                {
                    Down = 15f;
                    Up = 0f;
                }
                else
                {
                    Down = 15f;
                    Up = 1f;
                }

                //Starts the rotation loop which is done via a coroutine
                StartCoroutine(RightRotate());

                //Checks which room the player is in, then either moves the wall up or down the array.
                if (portalRoom == false)
                {
                    MoveArrayDown();
                }
                else
                {
                    MoveArrayup();
                }
                //Checks if the value of the FRS variable is null or not, if not null it then calls a function from it.    
                if (FRS != null)
                {
                    FRS.MoveMaterialDown();
                }
            }
        }
    }

    IEnumerator LeftRotate()
    {
        //Sets Down and Ups value to subtract from ChangeTrasnparent
        Down -= ChangeTrasnparent;
        Up += ChangeTrasnparent;

        //Sets the visibility of the walls to fit the room the player is in.
        if (portalRoom == false)
        {
            CS.WallMaterials[0].SetFloat("_Visbility", Up);
            CS.WallMaterials[1].SetFloat("_Visbility", 15f);
            CS.WallMaterials[2].SetFloat("_Visbility", Down);
            CS.WallMaterials[3].SetFloat("_Visbility", 0f);

            if (FRS != null)
            {
                FRS.StairMaterials[0].SetFloat("_Visbility", Up);
                FRS.StairMaterials[1].SetFloat("_Visbility", 15f);
                FRS.StairMaterials[2].SetFloat("_Visbility", Down);
                FRS.StairMaterials[3].SetFloat("_Visbility", 1f);
            }
        }
        else
        {
            CS.WallMaterials[0].SetFloat("_Visbility", 15f);
            CS.WallMaterials[1].SetFloat("_Visbility", Up);
            CS.WallMaterials[2].SetFloat("_Visbility", 1f);
            CS.WallMaterials[3].SetFloat("_Visbility", Down);
        }

        //Rotates the room and the player by rotate amount.
        T.transform.Rotate((x - RotateAmount), y, z, Space.World);
        Player.transform.Rotate((playerx + RotateAmount), y, z, Space.World);

        //Adds to the value of loopcount
        loopcount++;
        //Creates a pause that waits for the amount RotateSpeed is set to.
        yield return new WaitForSeconds(RotateSpeed);

        //Restarts the Coroutine if loopcount is a different value to LoopCountAmount.
        if(loopcount != LoopCountAmount)
        {
            StartCoroutine(LeftRotate());
        }
        else
        {
            //When the loop ends it resets the player, setting it so they fall down but can't move and makes sure they are standing up.
            MT.MyRigidbody.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation;
            MT.MoveAllow = 2;
            MT.XRotation += 90;
            //Sets Softlocked as true, which is designed so that if the player gets stuck on an object and can't move then the room resets.
            MT.Softlocked = true;
            //If FRS has a value then it calls ChangeStairsLeft() which sets the transparency of the stairs.
            if (FRS != null)
            {
                FRS.ChangeStairsLeft();
            }
            //Resets the values of Down and Up
            Down = 15f;
            Up = 0f;
            //Disconnects the player from the room so they can be accuralty reset rotation, before reattaching them.
            Player.transform.parent = null;
            Player.transform.rotation = new Quaternion(0, 0, 0, 0);
            Player.transform.SetParent(T);

            //Sets the transparency of the Walls
            if (portalRoom == false)
            {
            CS.WallMaterials[0].SetFloat("_Visbility", 15f);
            CS.WallMaterials[1].SetFloat("_Visbility", 15f);
            CS.WallMaterials[2].SetFloat("_Visbility", 0f);
            CS.WallMaterials[3].SetFloat("_Visbility", 0f);
            }
            else
            {
            CS.WallMaterials[0].SetFloat("_Visbility", 15f);
            CS.WallMaterials[1].SetFloat("_Visbility", 15f);
            CS.WallMaterials[2].SetFloat("_Visbility", 1f);
            CS.WallMaterials[3].SetFloat("_Visbility", 1f);
            }
            //Changes the players layer so they can collide with objects again.
            MT.gameObject.layer = 0;
            //calls the SoftlockedScene Coroutine.
            StartCoroutine(SoftlockedScene());
        }
    }

    IEnumerator RightRotate()
    {
        //Sets Down and Ups value to subtract from ChangeTrasnparent
        Down -= ChangeTrasnparent;
        Up += ChangeTrasnparent;

        //Sets the visibility of the walls to fit the room the player is in.
        if (portalRoom == false)
        {
            CS.WallMaterials[0].SetFloat("_Visbility", 15f);
            CS.WallMaterials[1].SetFloat("_Visbility", Up);
            CS.WallMaterials[2].SetFloat("_Visbility", 0f);
            CS.WallMaterials[3].SetFloat("_Visbility", Down);


            if (FRS != null)
            {
                FRS.StairMaterials[0].SetFloat("_Visbility", Up);
                FRS.StairMaterials[1].SetFloat("_Visbility", 15f);
                FRS.StairMaterials[2].SetFloat("_Visbility", Down);
                FRS.StairMaterials[3].SetFloat("_Visbility", 1f);

            }
        }
        else
        {
            CS.WallMaterials[0].SetFloat("_Visbility", Up);
            CS.WallMaterials[1].SetFloat("_Visbility", 15f);
            CS.WallMaterials[2].SetFloat("_Visbility", Down);
            CS.WallMaterials[3].SetFloat("_Visbility", 1f);
        }

        //Rotates the room and the player by rotate amount.
        T.transform.Rotate((x + RotateAmount), y, z, Space.World);
        Player.transform.Rotate((playerx - RotateAmount), y, z, Space.World);

        //Adds to the value of loopcount
        loopcount++;
        //Creates a pause that waits for the amount RotateSpeed is set to.
        yield return new WaitForSeconds(RotateSpeed);

        //Restarts the Coroutine if loopcount is a different value to LoopCountAmount.
        if (loopcount != LoopCountAmount)
        {
            StartCoroutine(RightRotate());
        }
        else
        {
            //When the loop ends it resets the player, setting it so they fall down but can't move and makes sure they are standing up.
            MT.MyRigidbody.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation;
            MT.MoveAllow = 2;
            MT.XRotation -= 90;
            //Disconnects the player from the room so they can be accuralty reset rotation, before reattaching them.
            Player.transform.parent = null;
            Player.transform.rotation = new Quaternion(0, 0, 0, 0);
            Player.transform.SetParent(T);
            //Sets Softlocked as true, which is designed so that if the player gets stuck on an object and can't move then the room resets.
            MT.Softlocked = true;

            //If FRS has a value then it calls ChangeStairsLeft() which sets the transparency of the stairs.
            if (FRS != null)
            {
                FRS.ChangeStairsLeft();
            }

            //Resets the values of Down and Up
            Down = 15f;
            Up = 0f;

            //Sets the transparency of the Walls
            if (portalRoom == false)
            {
                CS.WallMaterials[0].SetFloat("_Visbility", 15f);
                CS.WallMaterials[1].SetFloat("_Visbility", 15f);
                CS.WallMaterials[2].SetFloat("_Visbility", 0f);
                CS.WallMaterials[3].SetFloat("_Visbility", 0f);
            }
            else
            {
                CS.WallMaterials[0].SetFloat("_Visbility", 15f);
                CS.WallMaterials[1].SetFloat("_Visbility", 15f);
                CS.WallMaterials[2].SetFloat("_Visbility", 1f);
                CS.WallMaterials[3].SetFloat("_Visbility", 1f);
            }

            //Changes the players layer so they can collide with objects again.
            MT.gameObject.layer = 0;
            //calls the SoftlockedScene Coroutine.
            StartCoroutine(SoftlockedScene());
        }
    }

    public void MoveArrayup()
    {
        //Moves the positon of the walls and there materials within there array.
        for (int ArrayNumber = 0; ArrayNumber < 4; ArrayNumber++)
        {
            Temp[ArrayNumber] = CS.Walls[ArrayNumber];
            WallTemp[ArrayNumber] = CS.WallMaterials[ArrayNumber];
        }

        for (int ArrayNumber = 0; ArrayNumber < 4; ArrayNumber++)
        {
            CS.Walls[ArrayNumber + 1] = Temp[ArrayNumber];
            CS.WallMaterials[ArrayNumber + 1] = WallTemp[ArrayNumber];
            if(ArrayNumber == 3)
            {
                CS.Walls[0] = Temp[3];
                CS.Walls[4] = null;
                CS.WallMaterials[0] = WallTemp[3];
                CS.WallMaterials[4] = null;
            }
        }
    }


    public void MoveArrayDown()
    {
        //Moves the positon of the walls and there materials within there array.
        for (int ArrayNumber = 3; ArrayNumber >= 0; ArrayNumber--)
        {
            Temp[ArrayNumber] = CS.Walls[ArrayNumber];
            WallTemp[ArrayNumber] = CS.WallMaterials[ArrayNumber];
        }

        for (int ArrayNumber = 3; ArrayNumber >= 0; ArrayNumber--)
        {
            switch(ArrayNumber)
            {
                case 0:
                    {
                        CS.Walls[3] = Temp[0];
                        CS.Walls[4] = null;
                        CS.WallMaterials[3] = WallTemp[0];
                        CS.WallMaterials[4] = null;
                    }
                    break;
                default:
                    {
                        CS.WallMaterials[ArrayNumber - 1] = WallTemp[ArrayNumber];
                        CS.Walls[ArrayNumber - 1] = Temp[ArrayNumber];
                    }
                    break;
            }
            Debug.Log(ArrayNumber);
        }     
        
    }

    IEnumerator SoftlockedScene()
    {
        //After 30 seconds checks if the player is softlocked, if thats the case then the game resets the scene.
        yield return new WaitForSecondsRealtime(15f);
        if(MT.Softlocked == true)
        {
            SceneManager.LoadScene(MT.Room);
        }
    }
}
