using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldManager : MonoBehaviour {
    public UnityEvent onPlayerSeen;
    public bool GuardsChasing;
    private GuardBehaviour[] guards;

    private void Awake() {
        guards = FindObjectsOfType<GuardBehaviour>();
    }

    private void Update() {
        GuardsChasing = false;
        foreach (var g in guards) {
            if (g.guardStateMachine.GetCurrentState() == g.combat) {
                GuardsChasing = true;
                break;
            }
        }
    }
}

