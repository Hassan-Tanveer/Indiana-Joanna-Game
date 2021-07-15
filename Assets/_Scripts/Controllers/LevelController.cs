using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;

    public GameObject LevelCompleteUI;
    public AudioSource LevelCompleteSound;
    bool levelComplete = false;

    public Text EndLevelScore;
    public PlayerScript playerScript;

    public AudioSource InGameMusic;

    public int gameLevel;

    //displays 'Level Complete' GUI
    public void EndLevel()
    {
        if (levelComplete == false)
        {
        Debug.Log("Level Complete!");
        levelComplete = true;
        InGameMusic.GetComponent<AudioSource>();
        InGameMusic.Stop();

        LevelCompleteUI.SetActive(true);
        Time.timeScale = 0f;
        LevelCompleteSound.GetComponent<AudioSource>();
        LevelCompleteSound.Play();
        }
    }

    //Loads next level (using build level index)
    public void NextLevel()
    {
        Debug.Log("Loading Next Level...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        levelComplete = false;

        //setting/saving data into the next level
        PlayerPrefs.SetInt("PlayerScore", playerScript.points);
        
        gameLevel = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("GameLevel", gameLevel);
        
        //PlayerPrefs.SetInt("PlayerHealth", playerScript.currentHealth);
    }

    //displays the player's score
    private void OnGUI()
    {
        EndLevelScore.text = "Score: " + playerScript.Points;
    }
}

