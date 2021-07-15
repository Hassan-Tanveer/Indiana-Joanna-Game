using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTextController : MonoBehaviour
{

    public Text highScoreText;

    void Start()
    {
        StartCoroutine(RemoteHighScoreManager.Instance.GetHighScoreCR(UpdateUI));
    }

    void UpdateUI(int score)
    {
        if (score > 0) highScoreText.text = "High Score: " + score + "!";
        else highScoreText.text = "No High Score!";
    }

    public void ButtonHandlerReset()
    {
        StartCoroutine(RemoteHighScoreManager.Instance.SetHighScoreCR(0, ResetOnComplete));
    }

    void ResetOnComplete()
    {
        UpdateUI(0);
    }

}
