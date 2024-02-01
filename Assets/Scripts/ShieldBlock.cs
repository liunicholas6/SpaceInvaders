using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBlock : MonoBehaviour
{
    public float damagePerHit = 0.2f;
    public float health = 1.0f;

    private Material _material;
    // Start is called before the first frame update
    void Start()
    {
        _material = gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        health -= damagePerHit;

        _material.SetColor("_Color", Color.Lerp(Color.red, Color.white, health));
        if (health < 0f)
        {
            Destroy(gameObject);
        }
    }
}
