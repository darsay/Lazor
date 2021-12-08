using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldManager : MonoBehaviour {
    public UnityEvent onPlayerSeen;
    public bool GuardsChasing;
    public GuardBehaviour[] guards;
    public int guardsCount;

    private void Awake() {
        guards = FindObjectsOfType<GuardBehaviour>();
        guardsCount = guards.Length;
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

