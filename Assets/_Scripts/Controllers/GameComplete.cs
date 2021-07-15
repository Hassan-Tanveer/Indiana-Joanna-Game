using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameComplete : MonoBehaviour
{
    public GameObject GameCompleteMenuUI;
    public AudioSource GameCompleteSound;
    public bool gameComplete = false;

    public Text FinalScore;
    public PlayerScript playerScript;
    public AudioSource InGameMusic;

    public void CompletedGame()
    {
        if (gameComplete == false)
        {
            Debug.Log("GAME COMPLETE");
            gameComplete = true;
            InGameMusic.GetComponent<AudioSource>();
            InGameMusic.Stop();

            GameCompleteMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameCompleteSound.GetComponent<AudioSource>();
            GameCompleteSound.Play();
        }
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
