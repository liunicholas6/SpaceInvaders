using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Alien"))
        {
            Alien alien = collider.gameObject.GetComponent<Alien>();
            if (alien.sacrificed) return;
            GameObject.Find("GlobalObject").GetComponent<Global>().sacrifices++;
            alien.sacrificed = true;
        }
    }
}
