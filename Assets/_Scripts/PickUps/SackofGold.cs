using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SackofGold : MonoBehaviour
{

    public AudioSource pickUpNoise;
    public PlayerScript playerScript;
    private int SackofGoldPoints = 3;

    // Use this for initialization
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //rotates the SackofGold
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //play pick up sound
            pickUpNoise = GetComponent<AudioSource>();
            pickUpNoise.Play();

            //Add the points value of SackofGold to players score
            playerScript.points += SackofGoldPoints;
            Debug.Log("Sack of Gold " + "Score: " + playerScript.points);

            //This destroys the gold bar
            Destroy(gameObject, 0.9f);
        }

    }
}
