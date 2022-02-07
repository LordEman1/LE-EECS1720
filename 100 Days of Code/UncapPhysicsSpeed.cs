using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncapPhysicsSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>(); //Gets Rigidbody of Object

        if (rb == null) //Checks if there is or is not a Rigidbody
        {
            Debug.LogError("No Rigidbody on " + gameObject.name); //If there isnt a Rigidbody then it send a message
            return;
        }

        //Makes the slowdown of Ball faster/slower
        rb.sleepThreshold = 0.5f; // Default = 0.005 if needed

        rb.maxAngularVelocity = Mathf.Infinity; //Makes the Object roll without limits (More realistic rather than simulated)
    }

    // Update is called once per frame
    void Update()
    {

    }
}
