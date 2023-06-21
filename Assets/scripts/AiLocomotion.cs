using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiLocomotion : MonoBehaviour
{
   public NavMeshAgent ai;
    public List<Transform> destinations;
    public float walkSpeed, chaseSpeed, minIdleTime, maxIdletime, idleTime;
    public bool walking, chasing;

    public Transform playerTransform;
    Transform currentDest;
    Vector3 dest;
    int randomNum, randomNum2;
    public int destinationAmount;
    private void Start()
    {
        walking = true;
        randomNum = Random.Range (0,destinationAmount);
        currentDest = destinations[randomNum];
    }
    private void Update()
    {
        if (walking)
        {
            dest = currentDest.position;
            ai.destination = dest;
            ai.speed = walkSpeed;

            if(ai.remainingDistance <= ai.stoppingDistance)
            {
                randomNum2 = Random.Range (0,2);
                if (randomNum2 == 0)
                {
                    randomNum = Random.Range(0, destinationAmount);
                    currentDest = destinations[randomNum];
                }
                if(randomNum2 == 1)
                {
                    StopCoroutine("stayIdle");
                    StartCoroutine("stayIdle");
                    walking = false;
                }
            }
        }
    }
    IEnumerator stayIdle()
    {
        idleTime = Random.Range (minIdleTime, maxIdletime);
        yield return new WaitForSeconds (idleTime);
        walking = true;
        randomNum = Random.Range(0, destinationAmount);
        currentDest = destinations[randomNum];
    }
}
