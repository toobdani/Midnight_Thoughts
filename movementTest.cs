using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movementTest : MonoBehaviour
{
    //Stores the speed the player moves at
    [SerializeField] float MoveSpeed;
    //Stores the players rigidbody
    public Rigidbody MyRigidbody;

    //Stores the velocity of the players movement and the direction it is in
    [SerializeField] Vector3 MoveValues;

    //Stores the player's transform
    [SerializeField] Transform MyTransform;


    //variables to set the distance and radius of the spherecast
    [SerializeField] float RayCastDistance;
    [SerializeField] float RayCastRadius;

    //Stores the speed the player moves up stairs.
    [SerializeField] float StepSmooth = 0.1f;

    //Stores the player's rotation value in the Y axis
    [SerializeField] float YRotation;

    //A bool which is set when the player is standing on ground
    public bool Groundbool;

    //This int is used to set when the player is able to move
    public int MoveAllow;

    //Checks if the player is standing on stairs
    public bool Triggered;

    //Checks if the player can move up steps
    [SerializeField] bool Step;

    //Stores the speed the player rotates by
    [SerializeField] float RotateSpeed;
    
    //Checks if the player is rotating in the regular directions
    [SerializeField] bool RegularMove;

    //Stores the player's rotation values in the X and Z axis
    public float XRotation;
    public float ZRotation;

    //Stores the gravity the player faces when falling
    [SerializeField] Vector3 Customgravity;

    //Checks if the player is clipping objects
    public bool Clipping;

    //Checks if the player is in the first room or not
    [SerializeField] bool FirstRoom;

    //Checks if the player is softlocked
    public bool Softlocked;

    //Stores the room the player is playing in
    public int Room;
    // Start is called before the first frame update
    void Start()
    {
        //Attaches the components to the appropriate variables
        MyRigidbody = GetComponent<Rigidbody>();
        MyTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //This creates a raycasthit called GHit
        RaycastHit GHit;
        //It uses the Raycast variables to cast a sphere, which when colliding sets Groundbool as true. 
        Groundbool = Physics.SphereCast(transform.position, RayCastRadius ,Vector3.down, out GHit, RayCastDistance);

        //If the player is falling it will check for when they hit the ground and change things back to normal movement.
        if(MoveAllow == 2)
        {
            if(Groundbool)
            {
                //transform.Rotate(0, 0, 0);
                Softlocked = false;
                MoveAllow = 0;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(Room == 3)
        {
            Softlocked = false;
        }
    }

    private void FixedUpdate()
    {
        //Every frame of FixedUpdate pulls the player by the value of of the custom gravity
        MyRigidbody.velocity += Customgravity * Time.fixedDeltaTime;

        //It checks if the player can move then calls the move() and rotate() functions
        if (MoveAllow == 0)
        {
            move();
            rotate();
        }

        //This checks whether the player is colliding with the stairs and whether they are not clipping, then calls the StepUp() function
        if(Triggered == true)
        {
            if(Clipping == false)
            {
                StepUp();
            }
        }
    }

    void move()
    {
        //Sets the value of the MoveValues by the direction the player should be moving
        MoveValues = new Vector3();

        if(RegularMove == true)
        {
            MoveValues.x = -MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
            MoveValues.z = MoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
            MoveValues.y = MyRigidbody.velocity.y;
        }
        else
        {
            MoveValues.x = MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
            MoveValues.z = -MoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
            MoveValues.y = MyRigidbody.velocity.y;
        }

        //Changes the players velocity by the value of MoveValues
        MyRigidbody.velocity = MoveValues;

        //Makes it so Step is only true when the player is moving.
        if(MoveValues.x != 0 || MoveValues.z != 0)
        {
            Step = true;
        }
        else
        {
            Step = false;
        }
    }

    void rotate()
    {
        switch (RegularMove)
        {
            case true:
                {
                    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
                    {
                        if (YRotation > -90 && YRotation < 90)
                        {
                            YRotation += RotateSpeed * MoveValues.z * Time.deltaTime;

                        }
                        else if (YRotation > 90 && Input.GetKey(KeyCode.D))
                        {
                            YRotation += RotateSpeed * -MoveValues.z * Time.deltaTime;
                        }

                        if (YRotation >= 90 && MoveValues.z < 0)
                        {
                            YRotation += RotateSpeed * MoveValues.z * Time.deltaTime;
                        }
                        else if (YRotation <= 90 && MoveValues.z > 0)
                        {
                            YRotation += RotateSpeed * MoveValues.z * Time.deltaTime;
                        }
                    }


                    if (Input.GetKey(KeyCode.S))
                    {
                        if (YRotation > -180 && YRotation < 180)
                        {
                            if (YRotation < 0)
                            {
                                YRotation += RotateSpeed * -MoveValues.x * Time.deltaTime;
                            }
                            else if (YRotation > 0)
                            {
                                YRotation += RotateSpeed * MoveValues.x * Time.deltaTime;
                            }
                        }
                        else
                        {
                            YRotation = 180;
                        }
                    }

                    if (Input.GetKey(KeyCode.W))
                    {
                        if (YRotation != 0)
                        {
                            if (YRotation < 0)
                            {
                                YRotation += RotateSpeed * -MoveValues.x * Time.deltaTime;
                            }
                            else if (YRotation > 0)
                            {
                                YRotation += RotateSpeed * MoveValues.x * Time.deltaTime;
                            }
                        }
                        else
                        {
                            YRotation = 0;
                        }
                    }
                }
                break;
            case false:
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        if (YRotation > -180 && YRotation < 180)
                        {
                            if (YRotation < 0)
                            {
                                YRotation += RotateSpeed * -MoveValues.x * Time.deltaTime;
                            }
                            else if (YRotation > 0)
                            {
                                YRotation += RotateSpeed * MoveValues.x * Time.deltaTime;
                            }
                        }
                        else
                        {
                            YRotation = 180;
                        }
                    }

                    if (Input.GetKey(KeyCode.S))
                    {
                        if (YRotation != 0)
                        {
                            if (YRotation < 0)
                            {
                                YRotation += RotateSpeed * -MoveValues.x * Time.deltaTime;
                            }
                            else if (YRotation > 0)
                            {
                                YRotation += RotateSpeed * MoveValues.x * Time.deltaTime;
                            }
                        }
                        else
                        {
                            YRotation = 0;
                        }
                    }

                    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
                    {
                        if (YRotation > -90 && YRotation < 90)
                        {
                            YRotation += RotateSpeed * MoveValues.z * Time.deltaTime;

                        }
                        else if (YRotation > 90 && Input.GetKey(KeyCode.A))
                        {
                            YRotation += RotateSpeed * -MoveValues.z * Time.deltaTime;
                        }

                        if (YRotation >= 90 && MoveValues.z < 0)
                        {
                            YRotation += RotateSpeed * MoveValues.z * Time.deltaTime;
                        }
                        else if (YRotation <= 90 && MoveValues.z > 0)
                        {
                            YRotation += RotateSpeed * MoveValues.z * Time.deltaTime;
                        }
                    }
                }
                break;
        }
        MyRigidbody.rotation = Quaternion.Euler(0, YRotation, 0); 

    }

    void StepUp()
    {
        //Checks the value of Step and what room the player is in, then moves the player up the steps. 
        if (Step == true)
        {
            switch (FirstRoom)
            {
                case false:
                    {
                        MyRigidbody.position = new Vector3((MyRigidbody.position.x + StepSmooth), (MyRigidbody.position.y + StepSmooth), MyRigidbody.position.z);
                    }
                    break;
                case true:
                    {
                        MyRigidbody.position = new Vector3(MyRigidbody.position.x, (MyRigidbody.position.y + StepSmooth), MyRigidbody.position.z);
                    }
                    break;
            }
        }
    }

}


