using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoise : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Guard")) {
            other.GetComponent<GuardBehaviour>().CorpseSeen();
        }
    }
}
