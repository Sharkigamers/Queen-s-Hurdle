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
    public List<GameObject> nextLevelBorderList;
}

public class MenuManager : MonoBehaviour
{
    public List<IslandData> islandDataList;
    
    [SerializeField]
    private DataInterScene dataInterScene;

    private void Awake() {
        _LoadIslandData();
        _UpdateDataInterScene();
        _HideUnloadedIsland();
    }

    // Start is called before the first frame update
    void Start()
    {
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
            islandDataList[i].tower.GetComponentInChildren<LevelSwitch>().setCurrentIndex(
                islandDataList[i].data.indexIsland + 1
            );
        }
    }

    private void _HideUnloadedIsland() {
        for (int i = 0; i < islandDataList.Count; ++i) {
            if (!islandDataList[i].data.isUnlocked || !islandDataList[i].data.isAlreadyAnimated) {
                islandDataList[i].island.SetActive(false);
                islandDataList[i].tower.SetActive(false);
            }
            if (i + 1 < islandDataList.Count && !islandDataList[i + 1].data.isUnlocked)
                _setNextLevelBorderActive(i);
                
        }
    }

    private void _UpdateDataInterScene() {
        if (DataInterScene.currentIndexLevel < islandDataList.Count &&
        !islandDataList[DataInterScene.currentIndexLevel].data.isUnlocked)
            islandDataList[DataInterScene.currentIndexLevel].data.isUnlocked = true;
    }

    private void _setNextLevelBorderActive(int i) {
        for (int j = 0; j < islandDataList[i].nextLevelBorderList.Count; ++j)
            islandDataList[i].nextLevelBorderList[j].SetActive(true);
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
            }
        }
    }
}

