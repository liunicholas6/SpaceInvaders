using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class Laser : MonoBehaviour
{
    public Vector3 speed;

    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Fire(Vector3 spawnPos)
    {
        if (gameObject.activeSelf)
        {
            return;
        }
        gameObject.transform.position = spawnPos;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        float height = Screen.height;
        if (Camera.main.WorldToScreenPoint(gameObject.transform.position).y > height)
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        transform.position += speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;
        if (collider.CompareTag("Alien"))
        {
            Alien alien = collider.gameObject.GetComponent<Alien>();
            alien.Die();
        }
        gameObject.SetActive(false);
    }
}