using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IslandGameData {
    public IslandGameData(IslandGameData islandGameData) {
        indexIsland = islandGameData.indexIsland;
        nextLevelName = islandGameData.nextLevelName;
        isUnlocked = islandGameData.isUnlocked;
        isAlreadyAnimated = islandGameData.isAlreadyAnimated;   
    }

    public int indexIsland;
    public string nextLevelName;
    public bool isUnlocked;
    public bool isAlreadyAnimated;
}

[System.Serializable]
public class IslandData {
    public IslandGameData data;
    public GameObject island;
    public float waitTowerAppearTime = 1;
    public GameObject tower;
}

public class MenuManager : MonoBehaviour
{
    public List<IslandData> islandDataList;

    // Start is called before the first frame update
    void Start()
    {
        _LoadIslandData();
        _AnimateUnlockedIslandList();
    }

    private void _LoadIslandData() {
        IslandGameData newIslandGameData;

        for (int i = 0; i < islandDataList.Count; ++i) {
            newIslandGameData = SaveMenu.LoadIslandGameData(islandDataList[i].data);
            if (newIslandGameData == null)
                SaveMenu.SaveIslandGameData(islandDataList[i].data);
            else
                islandDataList[i].data = new IslandGameData(newIslandGameData);
            islandDataList[i].tower.GetComponentInChildren<LevelSwitch>().setNextLevelName(
                islandDataList[i].data.nextLevelName
            );
        }
    }

    private void _AnimateUnlockedIslandList() {
        StartCoroutine(_Appear());
    }

    private IEnumerator _Appear() {
        for (int i = 0; i < islandDataList.Count; ++i) {
            if (islandDataList[i].data.isUnlocked && !islandDataList[i].data.isAlreadyAnimated) {
                islandDataList[i].island.SetActive(true);
                islandDataList[i].island.GetComponent<Animator>().SetTrigger("Appear");
                yield return new WaitForSeconds(islandDataList[i].waitTowerAppearTime);
                islandDataList[i].tower.SetActive(true);
                islandDataList[i].tower.GetComponent<Animator>().SetTrigger("Appear");
                islandDataList[i].data.isAlreadyAnimated = true;
                SaveMenu.SaveIslandGameData(islandDataList[i].data);
            } else if (islandDataList[i].data.isUnlocked && islandDataList[i].data.isAlreadyAnimated) {
                islandDataList[i].island.SetActive(true);
                islandDataList[i].tower.SetActive(true);
            }
        }
    }
}

