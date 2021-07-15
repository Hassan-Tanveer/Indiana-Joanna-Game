using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {
    //player stats variables #1
    public int points = 0;
    public int maxHealth = 100;
    public int currentHealth;
    public bool isPlayerDead = false;

    public int levelPlaying = 1;

    //player stats variables #2
    public HealthBar healthbar;
    public GameObject player;
    public Text scoreText;
    public EnemyStats enemyStats;

    public AudioSource PlayerHitSound;
    public GameOverController gameOverController;
    public Rigidbody rb;

    public SpikeTrapController SpikeTrap;

    public LevelController lc;

    // Use this for initialization
    void Start ()
    {
        PlayerHitSound.GetComponent<AudioSource>();
        //sets player health
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

        //passing/getting data to next scene using PlayerPrefs.
        points = PlayerPrefs.GetInt("PlayerScore");

        //currentHealth = PlayerPrefs.GetInt("PlayerHealth");

        //levelPlaying = SceneManager.GetActiveScene().buildIndex;
        //PlayerPrefs.SetInt("Level", levelPlaying);
        //Debug.Log("YOU ARE PLAYING LEVEL: "+ levelPlaying);
        //PlayerPrefs.SetInt("GameLevel", level);

    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        PlayerDie();
	}

    void OnTriggerEnter(Collider other)
    {
        //if the enemy attacks player, player loses health
        if(other.gameObject.tag == "Enemy")
        {
            enemyStats.ZombiePunchSound.Play();
            PlayerHitSound.Play();
            TakeDamage(EnemyStats.EnemyHitDamage);
        }

        if(other.gameObject.tag == "Trap")
        {
            Debug.Log("TRAP has hit you " + currentHealth);
            PlayerHitSound.Play();
            TakeDamage(SpikeTrap.TrapDamage);
        }
    }

    private void OnGUI()
    {
        //GUI.Label(new Rect(10, 10, 100, 20), "Score : " + points);
        scoreText.text = "Score: " + points;
    }

    public void TakeDamage(int damage)
    {
        //health is reduced after every hit
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }

    public void PlayerDie()
    {
        if (currentHealth <= 0 || rb.position.y < -2f)
        {
            Debug.Log("Player Dead");
            isPlayerDead = true;
            gameOverController.EndGame();
        }
    }

    //getter and setter methods for Player Points
    public int Points
    {
       get { return points; }
       set { points = value; }
    }
}
