using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPointController : MonoBehaviour
{
    private float timeToDetroy = 3;
     
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Destroy(gameObject, 3);
        }
        
    }
}
