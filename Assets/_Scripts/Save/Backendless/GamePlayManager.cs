using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour
{
    public PlayerScript playerScript;

    public static GamePlayManager Instance;


    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public IEnumerator GameOverCR()
    {
        yield return new WaitForSeconds(2f);
        // remote storage of high score
        StartCoroutine(RemoteHighScoreManager.Instance.GetHighScoreCR(GetHighScoreComplete));
        Debug.Log("TEST2");
    }

    void GetHighScoreComplete(int highScore)
    {
        //int score = PlayerPrefs.GetInt("PlayerScore");
        int score = playerScript.points;
        Debug.Log("HIGHSCORE IS: "+ playerScript.points);
        if (score > highScore)
        {
            StartCoroutine(RemoteHighScoreManager.Instance.SetHighScoreCR(score, SetHighScoreComplete));
        }
        else
        {
            SceneManager.LoadSceneAsync(GlobalScript.MENU_SCENE);
        }
    }

    void SetHighScoreComplete()
    {
        SceneManager.LoadSceneAsync(GlobalScript.GAME_SCENE);
    }
}
