using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] int levelNumber;

    /*void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("AAAAAAAAAAAH");
            if (!pauseMenu.activeSelf) {
                Pause();
            }
            else {
                Resume();
            }
        }
    }*/
    
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;        
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;   
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelNumber);
    }

    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
