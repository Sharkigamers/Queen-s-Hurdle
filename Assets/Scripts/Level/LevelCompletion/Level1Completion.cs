using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Completion : MonoBehaviour
{
    private Level1Manager gameManager;
    public GameObject levelSwitcher;

    // Update is called once per frame
    private void Start() {
        gameManager = GetComponent<Level1Manager>();
    }

    void Update()
    {
        openDoorOnLevelCompletion();
    }

    private void openDoorOnLevelCompletion() {
        print(gameManager.isLevelCompleted());
        if (gameManager.isLevelCompleted())
            levelSwitcher.SetActive(true);
    }
}
