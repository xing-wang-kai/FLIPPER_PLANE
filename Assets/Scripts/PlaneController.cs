using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [Header("Attributs of the Plane : ")]
    [SerializeField]
    public float Speed = 5;
    public GameController controller;

    [HideInInspector]
    private Rigidbody2D rig;
    private bool canImpulse;

    public void Awake()
    {
        this.rig = GetComponent<Rigidbody2D>();
        this.controller = GameObject.FindObjectOfType<GameController>();
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this.canImpulse = true;
        }
    }
    void FixedUpdate()
    {
        if (this.canImpulse)
        {
            this.InpulsePlane();
        }
            
    }
    public void InpulsePlane()
    {
        this.rig.velocity = Vector3.zero;
        this.rig.AddForce(Vector2.up * this.Speed, ForceMode2D.Impulse);
        canImpulse = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
       this.rig.simulated = false;
       this.controller.GameOver();
      
    }
    
}
