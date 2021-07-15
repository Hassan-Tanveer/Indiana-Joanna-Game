using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    AudioSource startGame;
    //public Text Continue;
    public Button continueGame;

    // Use this for initialization
    void Awake()
    {
        startGame = GetComponent<AudioSource> ();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        continueGame.GetComponent<Button>();

        PlayerPrefs.GetInt("PlayerScore");
        PlayerPrefs.GetInt("GameLevel");
    }

    public void ButtonHandlerPlay()
    {
        StartCoroutine(PlaySoundAndStartGame());
    }

    IEnumerator PlaySoundAndStartGame()
    {
        startGame.Play();

        yield return new WaitForSeconds(4);
        //Player Prefs deleted -- reset game
        PlayerPrefs.DeleteAll();
        SceneManager.LoadSceneAsync(1);
    }

    public void doQuit()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }

    public void ContinueGame()
    {
        int sceneContinue = PlayerPrefs.GetInt("SavedScene");
        //continueGame.interactable = false;

        if(sceneContinue != 0)
        {
            SceneManager.LoadScene(sceneContinue);
           //PlayerPrefs.GetInt("PlayerScore");
           //PlayerPrefs.GetInt("PlayerHealth");
        }
        else
        {  
            Debug.Log("NOPE");
            return;
        }
    }

    public void Credits()
    {
        SceneManager.LoadSceneAsync(4); ;
    }
}
