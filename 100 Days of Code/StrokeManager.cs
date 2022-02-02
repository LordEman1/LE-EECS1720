using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrokeManager : MonoBehaviour
{
    // *** NOTE: ***
    //Clubs are at the bottom of this code!

    //Ball Stuff
    Rigidbody playerBallRB;

    //Stroke Modes
    public enum StrokeModeEnum{
        AIMING,
        FILL_BAR,
        HIT_BALL, 
        BALL_IS_MOVING
        };

    float MaxStrokeForce = 20f; //Max Force of club

    public StrokeModeEnum StrokeMode{ get; protected set;}

    //Stroke Angle Indicator Stuff
    public float StrokeAngle { get; protected set; }

    //Stroke Force Stuff
    public float StrokeForce { get; protected set; }

    //Stroke Force UI Stuff
    public float StrokeForcePerc{get {return StrokeForce / MaxStrokeForce;}} //Updates the Stroke Bar UI

    float strokeForceFillSpeed = 10f;//how fast the Stroke Bar fills
    int fillDir = 1; //Fill Bar direction (1 is UP, -1 is DOWN)

    // Start is called before the first frame update
    void Start()
    {
        FindPlayerBall();
    }

    private void FindPlayerBall()
    {
        GameObject go = GameObject.FindGameObjectWithTag("golfBall");

        if (go == null)
        {
            Debug.LogError("Cant find Ball");
        }

        playerBallRB = go.GetComponent<Rigidbody>();

        if (playerBallRB == null)
        {
            Debug.LogError("Ball may not have Rigidbody");
        }
    }

    // Update is called once per frame, use for inputs
    private void Update()
    {
        if (StrokeMode == StrokeModeEnum.AIMING) //Aim Mode
        {
            StrokeAngle += Input.GetAxis("Horizontal") * 100f * Time.deltaTime; //Can Aim ball left(A) and right(D)

            if (Input.GetButtonUp("Fire1")) //Switch to Fill mode
            {
                StrokeMode = StrokeModeEnum.FILL_BAR; //Fill mode Activated
                return;
            }
        }

        if (StrokeMode == StrokeModeEnum.FILL_BAR) //Fill mode
        {
            StrokeForce += (strokeForceFillSpeed * fillDir) * Time.deltaTime;

            if (StrokeForce > MaxStrokeForce) //If bar is FULL
            {
                StrokeForce = MaxStrokeForce; //Set Bar to Max
                fillDir = -1; //Make Bar go DOWN
            }

            else if(StrokeForce < 0) //If Bar is EMPTY
            {
                StrokeForce = 0; //Set Bar to 0
                fillDir = 1; //Make Bar go UP
            }

             if (Input.GetButtonUp("Fire1")) //Switch to HIT BALL mode
            {
                StrokeMode = StrokeModeEnum.HIT_BALL; //HIT BALL mode Activated
            }
        }


    }

    //Checks on balls moving status
    void CheckMovingStatus()
    {
        if(playerBallRB.IsSleeping()) //If Ball is NOT MOVING then its READY TO HIT.
        {
            StrokeMode = StrokeModeEnum.AIMING;
        }
    }

    //FixedUpdate should be used for manipulation
    void FixedUpdate()
    {
        if (playerBallRB == null)
        {
            //Potetial Error? or something went wrong.
            return;
        }

        if (StrokeMode == StrokeModeEnum.BALL_IS_MOVING)
        {
            CheckMovingStatus();
            return;
        }

        if(StrokeMode != StrokeModeEnum.HIT_BALL) //If not still moving
        {
            return;
        }

        //Hit Ball
        Debug.Log("Hitting ball!");

        //Club Stuff (DO NOT MOVE THESE ANYWHERE ELSE... OR ELSE!)   
        Vector3 putter = new Vector3(0, 0, StrokeForce); //Power of putter club
        Vector3 clubInHand = putter; //Club is use


        playerBallRB.AddForce(Quaternion.Euler(0, StrokeAngle, 0) * clubInHand, ForceMode.Impulse); //Hitting ball where pointing instantly

        StrokeForce = 0;
        StrokeMode = StrokeModeEnum.BALL_IS_MOVING; //After hit Ball CAN NOT be hit again until it STOPS
        
    }
}
