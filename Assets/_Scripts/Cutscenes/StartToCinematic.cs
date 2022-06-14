using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartToCinematic : MonoBehaviour
{
    [SerializeField]
    private string sceneAfterMenu = "Menu";
    public void MENU_GoToCinematic() {
        SceneManager.LoadScene(sceneAfterMenu);
    }
}
