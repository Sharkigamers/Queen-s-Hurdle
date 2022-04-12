using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitch : MonoBehaviour
{
    public string nexLevel;
    [SerializeField] LevelLoader levelLoader;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
            levelLoader.LoadSpecificLevel(nexLevel);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
