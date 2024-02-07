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
            Global g = GameObject.Find("GlobalObject").GetComponent<Global>();
            g.sacrifices++;
        }
    }
}
