using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFlagEndTimer : MonoBehaviour
{
    public RedFlagStartTimer redFlagTimer;
    public PlayerScript playerScript;

    public GameObject TimerUI;

    //bool timerStopped = false;
    //bool flagCollected = false;

    public AudioSource BlueFlagEndSound;
    public AudioSource timeToPointsSound;

    // Start is called before the first frame update
    void Start()
    {
        BlueFlagEndSound.GetComponent<AudioSource>();
        timeToPointsSound.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //rotates the flag
        transform.Rotate(90 * Time.deltaTime, 0, 0);
        /* if (flagCollected == true)
         {
             EndTimer();
             //Destroy(gameObject);
         }*/
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //flagCollected = true;
            //timerStopped = true;
            BlueFlagEndSound.Play();
            redFlagTimer.Map2BMusic.Stop();
            redFlagTimer.Map2AMusic.Play();
            Debug.Log("Blue Flag Collected");
            //disable the timer
            redFlagTimer.flagCollected = false;
            TimerUI.SetActive(false);
            Debug.Log("Timer Stopped");
            //add remaining time to player's points
            int timeToPoints = (int)redFlagTimer.timeLeft;
            playerScript.Points = playerScript.points + timeToPoints;
            timeToPointsSound.Play();
            //timerStopped = false;
            //Debug.Log("timeleft: " + (int) redFlagTimer.timeLeft + " Points: " + playerScript.points);
            //Destroy(gameObject, 2f);
            gameObject.SetActive(false);
            redFlagTimer.gameObject.SetActive(false);
        }

    }
}

