using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGeneratorController : MonoBehaviour
{
    [Header("Games Objects Obstacles Configures :")]
    [SerializeField]
    private GameObject[] obstacles;

    private float timeToGenerator = 6;
    private float initalTimeToGenerator;
    private float levelAdvancerTime = 0.1f;
    private float minTimeToGenerator = 1;

    public void Start()
    {
        this.initalTimeToGenerator = this.timeToGenerator;
        Instantiate(this.obstacles[0], transform.position, transform.rotation);
    }

    void Update()
    {
        this.timeToGenerator -= Time.deltaTime; 
        if(this.timeToGenerator <= 0)
        {
            int index = Random.Range(0, 2);
            Instantiate(this.obstacles[index], transform.position, transform.rotation);
            this.timeToGenerator = this.initalTimeToGenerator;

            if(this.initalTimeToGenerator >= this.minTimeToGenerator)
            {
                this.initalTimeToGenerator -= this.levelAdvancerTime;
            }
           
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, 2);
    }
}
