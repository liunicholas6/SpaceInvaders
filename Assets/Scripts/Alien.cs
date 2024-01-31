using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public int pointValue;
    public Alien prevAlien;
    public Alien nextAlien;

    // Start is called before the first frame update
    void Start()
    {
        pointValue = 10;
        // GetComponent<Rigidbody>().isKinematic = true;
    }

    public void Move(Vector3 v)
    {
        gameObject.transform.position += v;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public GameObject deathExplosion;
    public AudioClip deathKnell;
    public void Die()
    {
        AudioSource.PlayClipAtPoint(deathKnell,
            gameObject.transform.position);
        Instantiate(deathExplosion, gameObject.transform.position,
            Quaternion.AngleAxis(-90, Vector3.right));
        GameObject obj = GameObject.Find("GlobalObject");
        Global g = obj.GetComponent<Global>();
        g.score += pointValue;
        g.currAlien = nextAlien;
        Delete();
    }

    public void Delete()
    {
        nextAlien.prevAlien = prevAlien;
        prevAlien.nextAlien = nextAlien;
        Destroy(gameObject);
    }

    public void setNext(Alien alien)
    {
        nextAlien = alien;
        alien.prevAlien = this;
    }
}