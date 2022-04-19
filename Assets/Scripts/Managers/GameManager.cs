using System;
using UnityEngine;

public class GameManager : StaticInstance<GameManager> {
    public GameObject coinList;

    public bool isLevelCompleted() {
        if (coinList && coinList.transform.childCount != 0) {
            return false;
        }
        return true;
    } 
}
