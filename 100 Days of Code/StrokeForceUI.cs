using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrokeForceUI : MonoBehaviour
{
     // Start is called before the first frame update
    void Start()
    {
        StrokeManager = GameObject.FindObjectOfType<StrokeManager>(); //Finds StrokeManager
        powerBar = GetComponent<Image>();
    }

    StrokeManager StrokeManager;
    Image powerBar;

    // Update is called once per frame
    void Update()
    {
        powerBar.fillAmount = StrokeManager.StrokeForcePerc;
    }
}
