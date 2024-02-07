using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Vector3 speed;
    public bool isActive = true;

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
    
    
}
