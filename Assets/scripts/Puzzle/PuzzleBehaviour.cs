using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class PuzzleBehaviour : MonoBehaviour
{

    [SerializeField] private bool PuzzleSolved;

    public List<Light> puzzlelights;

    [SerializeField] private int NoOfLights;
   
    [SerializeField] private int lightsOn;

    public UnityEvent puzzleComplete;

    // Start is called before the first frame update
    void Start()
    {
        NoOfLights = puzzlelights.Count;
        CountLights();
    }

    public void CountLights()
    {
        lightsOn = 0;

        foreach (Light light in puzzlelights)
        {
           if (light.gameObject.activeSelf)
            {
                lightsOn++;
                Debug.Log(lightsOn);
                Debug.Log("on");
           }
           
            if (!light.gameObject.activeSelf)
           {
               if (lightsOn > 0)
               {
                   lightsOn--;
                   Debug.Log(lightsOn);
                   Debug.Log("off");
               }
           }
           
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lightsOn != NoOfLights)
        {
            PuzzleSolved = false;
        }

        if (lightsOn <= 0)
        {
            lightsOn = 0;
        }
        
        if (lightsOn > NoOfLights)
        {
            lightsOn = NoOfLights;
        } 

        if (lightsOn == NoOfLights && PuzzleSolved == false)
        {
            Debug.Log("puzzle complete");
            PuzzleSolved = true;
            puzzleComplete.Invoke();
        }
    }
}
