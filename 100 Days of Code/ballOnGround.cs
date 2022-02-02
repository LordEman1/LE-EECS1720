using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballOnGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Gets Balls Rigidbody

        //Makes the slowdown of Ball faster/slower
        rb.sleepThreshold = 0.5f; // Default = 0.005 if needed
    }

    Rigidbody rb;
}
