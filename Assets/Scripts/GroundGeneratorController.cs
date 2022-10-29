using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGeneratorController : MonoBehaviour
{
    [Header("Game Object to genaration :")]
    public GameObject Ground;
    public GameObject background;
    public GameObject positionBg;
    public float timeToGeneration = 9;
    public float intialTimeToGeneration;
    void Start()
    {
        this.intialTimeToGeneration = this.timeToGeneration;
        Instantiate(this.Ground, transform.position, transform.rotation);
        Instantiate(this.background, positionBg.transform.position, positionBg.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        this.timeToGeneration -= Time.deltaTime; 
        if(this.timeToGeneration <= 0)
        {
            Instantiate(this.Ground, transform.position, transform.rotation);
            Instantiate(this.background, positionBg.transform.position, positionBg.transform.rotation);
            this.timeToGeneration = this.intialTimeToGeneration;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, new Vector3(3, 3, 3));
    }
}
