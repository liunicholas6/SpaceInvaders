using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRadius;

    public float lifetime;

    public float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float t = Time.time - startTime;
        if (t > lifetime)
        {
            Destroy(gameObject);
            return;
        }
        float radius = t/lifetime * explosionRadius;
        transform.localScale = new Vector3(radius, radius, radius);
    }
}
