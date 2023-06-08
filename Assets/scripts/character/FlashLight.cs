using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public KeyCode recharge;
    public bool lightOn = false;

    public float Battery = 100f;
    static float rayLength;

    public GameObject Light;
    public GameObject soundVolume;
    public GameObject flashlight;
    public GameObject Obstacle;
    public GameObject visionCube;
    RaycastHit hit;


    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, flashlight.transform.forward);
        Debug.DrawRay(flashlight.transform.position, flashlight.transform.forward * rayLength, Color.red);
        
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.distance);
            rayLength = hit.distance; 
            for (float i = rayLength; i == 0; i--)
            {
                Instantiate (visionCube, rayLength.point)
            }
        }

       
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
        //recharges battery and de/activates the sound detection volume
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