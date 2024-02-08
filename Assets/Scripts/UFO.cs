using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour, IKillable
{
    public GameObject deathExplosion;
    public AudioClip deathKnell;
    public Vector3 velocity;
    public int spawnRate;

    private Global _global;

    private int[] _possiblePoints =
    {
        100, 50, 50, 100, 150, 100, 100, 50,
        300, 100, 100, 100, 50, 150, 100, 50
    };

// Start is called before the first frame update
    void Start()
    {
        _global = GameObject.Find("GlobalObject").GetComponent<Global>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > _global.rightBound)
        {
            gameObject.SetActive(false);
        }
    }
    
    public void Die()
    {
        AudioSource.PlayClipAtPoint(deathKnell,
            gameObject.transform.position);
        Instantiate(deathExplosion, gameObject.transform.position,
            Quaternion.AngleAxis(-90, Vector3.right));
        
        Global g = GameObject.Find("GlobalObject").GetComponent<Global>();
        g.score += _possiblePoints[Laser.ufoScorePtr];
        gameObject.SetActive(false);
    }
}
