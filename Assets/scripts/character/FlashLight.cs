using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public KeyCode recharge;
    public bool lightOn = false;
    //private bool failSafe = false;

    public float Battery = 100f;

    public GameObject Light;
    public GameObject soundVolume;

    


    // Update is called once per frame
    void Update()
    {
        //detects if battery is zero and turns the torch off. stops the battery from going under 0%
        if (Battery <= 0)
        {
            lightOn = false;
            Light.SetActive(false);
            Battery = 0;
        }
        //toggles the state of the flashlight
        if (Input.GetMouseButtonDown(0))
        {
            if (lightOn == false && Battery > 0)
            {
                lightOn = true;
                Light.SetActive(true);
               
            }
            else if (lightOn == true && Battery > 0)
            {
                lightOn = false;
                Light.SetActive(false);
               
            }
        }
        //drains battery
        if (lightOn == true)
        {
            Battery -= 5 * Time.deltaTime;
        }
        //recharges battery and de/actives the sound detection volume
        if (Input.GetKey(recharge))
        {
            Battery += 10 * Time.deltaTime;
            soundVolume.SetActive(true);
        }
        else
        {
            soundVolume.SetActive(false);
        }
        //keeps battery from going over 100%
        if (Battery > 100)
        {
            Battery = 100;
        }
    }
}