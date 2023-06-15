using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttonBehaviour : MonoBehaviour
{
    public GameObject puzzleGroup;
    public GameObject interact;
    private bool buttonPressed = false;

    public KeyCode interactKey;

    private bool inReach;

    public List<GameObject> lights;
    


    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            Debug.Log("enter");
        }
    }
    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            Debug.Log("exit");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetKeyDown(interactKey) && buttonPressed == false)
        {
            buttonPressed = true;
            Debug.Log(buttonPressed);
        }
        else if (inReach && Input.GetKeyDown(interactKey) && buttonPressed == true)
        {
            buttonPressed = false;
            Debug.Log(buttonPressed);
        }

        foreach(GameObject light in lights)
        {
            return;
        }
    }
    
}
