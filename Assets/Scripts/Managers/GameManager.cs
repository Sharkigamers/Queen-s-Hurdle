using System;
using UnityEngine;

public class GameManager : StaticInstance<GameManager> {
    public GameObject coinList;

    public bool isLevelCompleted() {
        if (coinList && coinList.transform.childCount != 0) {
            print("Non validation");
            return false;
        }
        print("Validation");
        return true;
    } 
}
