using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRadius;

    public float explosionForce;
    public float lifetime;

    public float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float t = Time.time - startTime;
        if (t > lifetime)
        {
            Destroy(gameObject);
            return;
        }
        float radius = t/lifetime * explosionRadius;
        transform.localScale = new Vector3(radius, radius, radius);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Alien"))
        {
            IKillable alien = collider.gameObject.GetComponent<IKillable>();
            alien.Die();
            var position = transform.position;
            var displacement = collider.transform.position - position;
            var force = displacement / Vector3.SqrMagnitude(displacement) * explosionForce;
            collider.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(force, position, ForceMode.Impulse);
        }
        else if (collider.CompareTag("Shield"))
        {
            ShieldBlock shieldBlock = collider.gameObject.GetComponent<ShieldBlock>();
            shieldBlock.Damage();
        }
    }
}
