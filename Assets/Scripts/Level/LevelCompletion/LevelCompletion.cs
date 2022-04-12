using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    public GameManager gameManager;

    public Animator animator;

    private bool isCompelted = false;

    // Update is called once per frame
    void Update()
    {
        openDoorOnLevelCompletion();
    }

    private void openDoorOnLevelCompletion() {
        if (!isCompelted && gameManager.isLevelCompleted()) {
            isCompelted = true;
        }
    }
}
