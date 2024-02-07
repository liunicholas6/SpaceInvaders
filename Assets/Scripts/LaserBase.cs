using UnityEngine;
using UnityEngine.Serialization;

public class LaserBase : MonoBehaviour
{
    public float speed;
    public GameObject laser;
    public GameObject bombLaser;
    public AudioClip deathKnell;
    public GameObject deathExplosion;

    private Rigidbody _rigidbody;

    // Use this for initialization
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !Laser.activeLaser)
        {
            var obj = Instantiate(laser);
            obj.transform.position = transform.position;
        }
        if (Input.GetButtonDown("Fire2") && !Laser.activeLaser)
        {
            var obj = Instantiate(bombLaser);
            obj.transform.position = transform.position;
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
