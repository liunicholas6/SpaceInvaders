using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBase : MonoBehaviour
{
    public float speed;
    public float rotation;
    public GameObject laserPrefab;
    public AudioClip deathKnell;
    public GameObject deathExplosion;

    private Laser _laserInstance;
    private Rigidbody _rigidbody;

    // Use this for initialization
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        speed = 2.0f;
        
        Vector3 spawnPos = gameObject.transform.position;
        _laserInstance = Instantiate(laserPrefab).GetComponent<Laser>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _laserInstance.Fire(gameObject.transform.position);
        }
    }

    /* forced changes to rigid body physics parameters should be done through the FixedUpdate()
    method, not the Update() method
    */
    void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(speed * Input.GetAxisRaw("Horizontal"), 0, 0);
    }
    
    public void Die()
    {
        AudioSource.PlayClipAtPoint(deathKnell,
            gameObject.transform.position);
        Instantiate(deathExplosion, gameObject.transform.position,
            Quaternion.AngleAxis(-90, Vector3.right));
        GameObject obj = GameObject.Find("GlobalObject");
        Global g = obj.GetComponent<Global>();
        g.LoseLife();
        
        // g.score += pointValue;
        // g.currAlien = nextAlien;
        // Delete();
    }
    
    
}
