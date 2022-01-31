using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrokeManager : MonoBehaviour
{
    //Ball Stuff
    Rigidbody playerBallRB;
    bool golfMode = true; //Can be turned off and on
    bool hitBall = false; // Did i hit the ball?

    //Clubs
    static Vector3 putter = new Vector3(0, 0, 20f); //Power of putter club
    static Vector3 iron = new Vector3(0, 10, 50f); //Power of iron club
    static Vector3 clubInHand = putter; //Club that the Player is Using

    //Stroke Angle Indicator Stuff
    public float StrokeAngle { get; protected set; }

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Hit!");
            hitBall = true;
        }

        StrokeAngle += Input.GetAxis("Horizontal") * 100f * Time.deltaTime;
    }

    //FixedUpdate should be used for manipulation
    void FixedUpdate()
    {
        if (playerBallRB == null)
        {
            //Potetial Error? or something went wrong.
            return;
        }

        if (hitBall)
        {
            //Hit Ball
            Debug.Log("Hitting ball!");

            hitBall = false;

            playerBallRB.AddForce(Quaternion.Euler(0, StrokeAngle, 0) * clubInHand, ForceMode.Impulse); //Hitting ball where pointing instantly
        }
    }
}
