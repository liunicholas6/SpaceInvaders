using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBlock : MonoBehaviour
{
    public float damagePerHit = 0.2f;
    public float health = 1.0f;

    private Material _material;

    private static readonly int ColorId = Shader.PropertyToID("_Color");

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
        Damage();
    }

    public void Damage()
    {
        health -= damagePerHit;
        _material.SetColor(ColorId, Color.Lerp(Color.red, Color.white, health));
        if (health < 0f)
        {
            Destroy(gameObject);
        }
    }
}
