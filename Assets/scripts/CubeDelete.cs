using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CubeDelete : MonoBehaviour
{
    public GameObject cube;
    // Start is called before the first frame update
   void Start()
    {
        /*Task.Delay(2000);
        Destroy(cube);
        if (cube == null)
        {
            return;
        }*/
    }

    
    void Update()
    {
        Task.Delay(2000);
        Destroy(cube);
        if (cube == null)
        {
            return;
        }
    } 
}
