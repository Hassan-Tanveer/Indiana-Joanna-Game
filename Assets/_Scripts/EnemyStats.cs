using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* This method stores the enemy stats and
 * the enemy state (dead, alive, taking damage).
 */

public class EnemyStats : MonoBehaviour {

    //enemy stats variables
    private int MaxEnemyHealth = 20;
    public int currentEnemyHealth;
    public static int EnemyHitDamage = 5;
    public bool isEnemyAlive = true;
    private int enemyEXP = 5;

    public PlayerScript playerScript;
    public EnemyAnimMovement enemyAnimMovement;

    //audio variables
    public AudioSource ZombieHurt;
    public AudioSource ZombiePunchSound;
    public AudioSource ZombieDieSound;

    //public GameObject enemyEXPPointsPopUp;

   public bool canBeAttacked = true;

    void Start()
    {
        //sets the enemy health
        currentEnemyHealth = MaxEnemyHealth;

        ZombieHurt.GetComponent<AudioSource>();
        ZombiePunchSound.GetComponent<AudioSource>();
    }

    //Method for: when an enemy is hit by an arrow
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Arrow")
        {
            EnemyTakeDamage(ArrowScript.ArrowDamage);
            ZombieHurt.Play();
            Debug.Log("ENEMY HAS BEEN HIT BY AN ARROW!");
        }

    }

    public void EnemyTakeDamage(int damage)
    {
        currentEnemyHealth -= damage;
        enemyAnimMovement.TakeHitDamage();
        Debug.Log("EnemyHealth: " + currentEnemyHealth);

        if (currentEnemyHealth <= 0)
        {
            EnemyDie();
            if (canBeAttacked == true)
            {
                playerScript.points += enemyEXP;
                canBeAttacked = false;
            }
            //canBeAttacked = false;
        }
    }

    public void EnemyDie()
    {
        isEnemyAlive = false;
        ZombieDieSound.Play();
        enemyAnimMovement.Death();
        //Instantiate(enemyEXPPointsPopUp, transform.position, Quaternion.identity);
        Destroy(gameObject, 4f);
    }
}
