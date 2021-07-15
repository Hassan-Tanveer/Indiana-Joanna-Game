using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickUp : MonoBehaviour {

    public AudioSource pickUpNoise;
    public PlayerScript playerScript;
    private int goldPickupPoints = 1;

	// Use this for initialization
	void Awake () {
           
    }
	
	// Update is called once per frame
	void Update () {
        //rotates gold bar
        transform.Rotate(0, 90 * Time.deltaTime, 0);
	}

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            //play pick up gold sound
            pickUpNoise = GetComponent<AudioSource>();
            pickUpNoise.Play();

            //Add 1 to score
            playerScript.points += goldPickupPoints;
            Debug.Log("Gold Bar Collected " + "Score: " + playerScript.points);

            //This destroys the gold bar
            Destroy(gameObject, 0.9f); 
        }

    }
}
