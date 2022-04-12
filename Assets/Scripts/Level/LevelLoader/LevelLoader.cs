using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1.0f;

    public void LoadSpecificLevel(string levelName) {
        StartCoroutine(LoadLevel(levelName));
    }

    IEnumerator LoadLevel(string levelName) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelName);
        yield return new WaitForSeconds(transitionTime);
    }
}
