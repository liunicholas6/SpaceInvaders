using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Alien : MonoBehaviour, IKillable
{
    public int pointValue;
    public Alien prevAlien;
    public Alien nextAlien;
    public GameObject missile;
    public float bulletFrequency;

    // Start is called before the first frame update
    void Start()
    {
        pointValue = 10;
        bulletFrequency = 0.001f;
        // GetComponent<Rigidbody>().isKinematic = true;
    }

    public void Move(Vector3 v)
    {
        gameObject.transform.position += v;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Random.value < bulletFrequency)
        {
            Instantiate(missile, gameObject.transform.position, Quaternion.identity);
        }
    }

    public GameObject deathExplosion;
    public AudioClip deathKnell;
    public void Die()
    {
        AudioSource.PlayClipAtPoint(deathKnell,
            gameObject.transform.position);
        Instantiate(deathExplosion, gameObject.transform.position,
            Quaternion.AngleAxis(-90, Vector3.right));
        
        Global g = GameObject.Find("GlobalObject").GetComponent<Global>();
        g.score += pointValue;
        if (this == nextAlien)
        {
            g.SpawnAliens();
        }
        else
        {
            g.currAlien = nextAlien;
        }
        Delete();
    }

    public void Delete()
    {
        nextAlien.prevAlien = prevAlien;
        prevAlien.nextAlien = nextAlien;
        Destroy(gameObject);
    }

    public void SetNext(Alien alien)
    {
        nextAlien = alien;
        alien.prevAlien = this;
    }
}