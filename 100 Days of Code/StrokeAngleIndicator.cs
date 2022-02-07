using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrokeAngleIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StrokeManager = GameObject.FindObjectOfType<StrokeManager>(); //Finds StrokeManager
        playerBallTransform = GameObject.FindGameObjectWithTag("golfBall").transform; //Finds golf ball
    }

    StrokeManager StrokeManager;
    Transform playerBallTransform;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = playerBallTransform.position;
        this.transform.rotation = Quaternion.Euler(StrokeManager.StrokeAngleX, StrokeManager.StrokeAngleY, 0);
    }
}
