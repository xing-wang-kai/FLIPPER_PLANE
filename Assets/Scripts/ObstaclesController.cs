using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    [Header("Attributes of Obstacles :")]
    [SerializeField]
    public float Speed = 5;
    [SerializeField]
    private float timeToDestroy = 20;
    public GameController controller;
    public bool isScored;

    private Transform plane;

    public void Start()
    {
        this.plane = GameObject.FindWithTag("plane").GetComponent<Transform>();
        this.controller = GameObject.FindObjectOfType<GameController>();

        float randomAxiY = Random.Range(-3.5f, 1.5f);
        this.transform.Translate(Vector3.up * randomAxiY);
    }

    void Update()
    {
        if(!this.isScored && this.plane.position.x >= this.transform.position.x)
        {
            this.controller.setPoint();
            this.isScored = true;
        }
        this.transform.Translate(Vector2.left * this.Speed * Time.deltaTime);
        Destroy(this.gameObject, this.timeToDestroy);
    }
}
