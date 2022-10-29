using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [Header("Attributs of Ground")]
    [SerializeField]
    public float Speed = 2f;
    [SerializeField]
    private float timeToDestroy = 18;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.left * this.Speed * Time.deltaTime);
        Destroy(this.gameObject, this.timeToDestroy);
    }
}
