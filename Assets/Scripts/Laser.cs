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
            IKillable alien = collider.gameObject.GetComponent<IKillable>();
            alien.Die();
            var contact = collision.contacts[0];
            collider.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(contact.normal, contact.point, ForceMode.Impulse);
        } else if (collider.CompareTag("Shield"))
        {
            ShieldBlock shieldBlock = collider.gameObject.GetComponent<ShieldBlock>();
            shieldBlock.Damage();
        }
        gameObject.SetActive(false);
    }
}