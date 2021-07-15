using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

    public GameObject GameOverMenuUI;
    public AudioSource GameOverSound;
    public bool gameHasEnded = false;

    public Text FinalScore;
    public PlayerScript playerScript;

    public AudioSource InGameMusic;

    public GamePlayManager gpm;

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            Debug.Log("GAME OVER");
            gameHasEnded = true;
            InGameMusic.GetComponent<AudioSource>();
            InGameMusic.Stop();

            GameOverMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameOverSound.GetComponent<AudioSource>();
            GameOverSound.Play();

            StartCoroutine(gpm.GameOverCR());

        }
    }

    public void RestartGame()
    { 
        Debug.Log("Restarting...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        InGameMusic.Play();
        Time.timeScale = 1f;
        gameHasEnded = false;
    }

    public void ReturnToMenu()
    {
        Debug.Log("Returning To Main Menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    private void OnGUI()
    {
        FinalScore.text = "Score: " + playerScript.Points;
    }

}
