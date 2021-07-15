using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedFlagStartTimer : MonoBehaviour
{
    public float timeLeft = 100f;
    public Text countdownText;
    public GameObject TimerUI;
    
    public bool flagCollected = false;
    public bool timerStarted = false;
    public AudioSource RedFlagStartSound;

    public AudioSource Map2AMusic;
    public AudioSource Map2BMusic;

    public GameOverController gameOverController;

    // Start is called before the first frame update
    void Start()
    {
        RedFlagStartSound.GetComponent<AudioSource>();
        Map2AMusic.GetComponent<AudioSource>();
        Map2BMusic.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rotates the flag
        transform.Rotate(90 * Time.deltaTime, 0, 0);
        if (flagCollected == true)
        {
            StartTimer();
            //gameObject.SetActive(false);
        }

        EndLevel();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            flagCollected = true;
            timerStarted = true;
            RedFlagStartSound.Play();
            Map2AMusic.Stop();
            Map2BMusic.Play();
            Debug.Log("Red Flag Collected");
            //StartTimer();
            //Destroy(gameObject, 10f);
        }
    }
    void StartTimer()
    {
        //Debug.Log("Timer Started");
        TimerUI.SetActive(true);
        timeLeft -= Time.deltaTime * 1;
        countdownText.text = "Time: " + timeLeft.ToString("0");
        //string.Format("{0:00}", timeLeft));
        //Debug.Log(timeLeft);
    } 

    void EndLevel()
    {
        if(timeLeft <= 0f)
        {
            gameOverController.gameHasEnded = false;
            Map2BMusic.Stop();
            gameOverController.EndGame();
        }

    }
}
