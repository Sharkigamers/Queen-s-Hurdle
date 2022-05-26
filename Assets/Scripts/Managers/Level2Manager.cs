using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> toAppearList;
    public float waitAppear = 1;

    private void Awake() {
        _HideGameObjects();
        _AnimateGameobjectList();
    }

    private void _HideGameObjects() {
        for (int i = 0; i < toAppearList.Count; ++i)
            toAppearList[i].SetActive(false);
    }

    private void _AnimateGameobjectList() {
        StartCoroutine(_Appear());
    }

    private IEnumerator _Appear() {
        yield return new WaitForSeconds(waitAppear);
        for (int i = 0; i < toAppearList.Count; ++i) {
            toAppearList[i].SetActive(true);
            toAppearList[i].GetComponent<Animator>().SetTrigger("Appear");
            yield return new WaitForSeconds(waitAppear);
        }
    }
}
