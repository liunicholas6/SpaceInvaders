using System;
using System.Threading;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Vector3 speed;
    public GameObject explosionPrefab;

    private void Update()
    {
        if (Camera.main.WorldToScreenPoint(gameObject.transform.position).y < 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.position += speed * Time.deltaTime;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        Vector3 spawnPos = gameObject.transform.position;
        Collider collider = collision.collider;
        if (collider.CompareTag("Player"))
        {
            LaserBase laserBase = collider.gameObject.GetComponent<LaserBase>();
            laserBase.Die();
        }
        else
        {
            Instantiate(explosionPrefab, spawnPos,
                        Quaternion.AngleAxis(-90, Vector3.right));
        }
        Destroy(gameObject);
    }
}
