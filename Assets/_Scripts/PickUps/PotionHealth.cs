using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionHealth : MonoBehaviour {

    public AudioSource HealthPotionSound;
    public PlayerScript playerScript;
    public HealthBar healthbar;
    public int healthBonus = 5;

    // Use this for initialization
    void Awake ()
    {
        playerScript = FindObjectOfType<PlayerScript>();
        HealthPotionSound = GetComponent<AudioSource>();
    }
	
	void Update () {
        //rotates Potion
        transform.Rotate(0, 0, 90 * Time.deltaTime);
    }

    //method for when player picks up the health potion
    //potion is only picked up when both if conditions are met
    //the tag is the player AND the current health is less than or equal to the max health (100)
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && playerScript.currentHealth < playerScript.maxHealth)
        {
            //play potion of health pick up sound
            
            HealthPotionSound.Play();
            //destroys the potion
            Destroy(gameObject,0.8f);
            //Calls the method and adds the health bonus to current health of player
            HealthBoost(healthBonus);
            Debug.Log("Health Potion Collected "+ healthBonus);
        }
    }

    //method for adding health bonus
    public void HealthBoost(int healthBonus)
    {
        playerScript.currentHealth += healthBonus;
        healthbar.SetHealth(playerScript.currentHealth);
    }
}
