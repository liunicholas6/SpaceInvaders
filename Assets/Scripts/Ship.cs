using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float speed;
    public float rotation;
    public GameObject laserPrefab;

    private Laser _laserInstance;

    // Use this for initialization
    void Start()
    {
        speed = 2.0f;
        
        Vector3 spawnPos = gameObject.transform.position;
        _laserInstance = Instantiate(laserPrefab).GetComponent<Laser>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 spawnPos = gameObject.transform.position;
            spawnPos.z += 1.5f;
            _laserInstance.Fire(spawnPos);
        }
    }

    /* forced changes to rigid body physics parameters should be done through the FixedUpdate()
    method, not the Update() method
    */
    void FixedUpdate()
    {
        // force thruster
        GetComponent<Rigidbody>().velocity = new Vector3(speed * Input.GetAxisRaw("Horizontal"), 0, 0);
        // if (Input.GetAxisRaw("Vertical") > 0)
        // {
        //     GetComponent<Rigidbody>().AddRelativeForce(forceVector);
        // }
        //
        // if (Input.GetAxisRaw("Horizontal") > 0)
        // {
        //     rotation += rotationSpeed;
        //     Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));
        //     GetComponent<Rigidbody>().MoveRotation(rot);
        // }
        // else if (Input.GetAxisRaw("Horizontal") < 0)
        // {
        //     rotation -= rotationSpeed;
        //     Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));
        //     GetComponent<Rigidbody>().MoveRotation(rot);
        //     //GetComponent<Rigidbody>().Rotate(0, -2.0f, 0.0f );
        // }
    }
}
