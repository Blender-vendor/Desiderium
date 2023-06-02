using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public bool lightOn = false;
    private bool failSafe = false;

    public float Battery = 100;

    public GameObject Light;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (lightOn == false && failSafe == false && Battery > 0)
            {
                lightOn = true;
                Light.SetActive(true);
                failSafe = true;
                StartCoroutine(FailSafe());
            }
            if (lightOn == true && failSafe == false && Battery > 0)
            {
                lightOn = false;
                Light.SetActive(false);
                failSafe = true;
                StartCoroutine(FailSafe());
            }
        }
        if (lightOn == true)
        {
            //Battery -= 1 * Time.deltaTime;
        }
        
    }

    


    IEnumerator FailSafe ()
    {
        yield return new WaitForSeconds(0.05f);
        failSafe = false;
    }
}
