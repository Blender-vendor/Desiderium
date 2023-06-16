using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{

    public bool playerInZone;
    public bool lightOn;

    public PuzzleBehaviour Puzzle;

    [SerializeField] private GameObject[] Lights;



    void Start()
    {
        playerInZone = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInZone=true;
            Debug.Log("Enter");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInZone = false;
            Debug.Log("Exit");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("works fine");
            
            foreach (GameObject Light in Lights)
            {
                Light.SetActive(!Light.activeSelf);
            }
            Puzzle.CountLights();
        }
    }
}
