using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapController : MonoBehaviour {

    //This script goes on the SpikeTrap prefab;

    public int TrapDamage = 10;
    public AudioSource SpikeTrapSound;
    public PlayerScript playerScript;

    public Animator spikeTrapAnim; //Animator for the SpikeTrap;

    // Use this for initialization
    void Awake()
    {
        SpikeTrapSound.GetComponentInChildren<AudioSource>();
        //get the Animator component from the trap;
        spikeTrapAnim = GetComponent<Animator>();
        //play the spike trap sound
        SpikeTrapSound.Play();
        //start opening and closing the trap;
        StartCoroutine(OpenCloseTrap());
    }

    IEnumerator OpenCloseTrap()
    {
        //play open animation;
        spikeTrapAnim.SetTrigger("open");
        //wait 2 seconds;
        yield return new WaitForSeconds(2);
        //play close animation;
        spikeTrapAnim.SetTrigger("close");
        //wait 3 seconds;
        yield return new WaitForSeconds(3);
        //Do it again;
        StartCoroutine(OpenCloseTrap());

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("TRAP has hit you! Health: " + playerScript.currentHealth);
            playerScript.PlayerHitSound.Play();
            playerScript.TakeDamage(TrapDamage);
        }
    }
}