using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour {

    public static bool isPaused = false;
    public GameObject PauseMenuUI;

    public int currentSceneIndex;
    public int savePlayerPos;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
}

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        isPaused = false;
        Cursor.visible = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
        isPaused = true;
        Cursor.visible = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;

        //PLAYER PREFS SAVING DATA TO RESUME GAME WHERE LEFT OFF
        //LEVEL -- linked to continue button on main menu
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        Debug.Log("Restarting from Pause Menu...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioListener.pause = false;
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
