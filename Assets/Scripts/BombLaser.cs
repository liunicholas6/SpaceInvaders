using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLaser : MonoBehaviour
{
    public Vector3 speed;
    public GameObject explosion;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = speed;
    }

    private void Update()
    {
        float y = Camera.main.WorldToViewportPoint(transform.position).y;
        if (y < -0.1 || y > 1.1)
        {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter(Collider _)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    
}
