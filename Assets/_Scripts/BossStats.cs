using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : MonoBehaviour
{
    private int MaxBossHealth = 150;
    public int currentBossHealth;
    public static int BossHitDamage = 10;
    public bool isBossAlive = true;
    private int BossEXP = 500;
    public bool canBeAttacked = true;

    float waitDelay = 8f;

    public PlayerScript playerScript;
    public GameComplete gameComplete;
    public BossAnim bossAnim;

    public BossHealthBar bossHealthBar;

    public AudioSource BossHurtSound;
    public AudioSource BossSwordSound;
    public AudioSource BossDeathSound;

    // Start is called before the first frame update
    void Start()
    {
        currentBossHealth = MaxBossHealth;
        bossHealthBar.SetMaxHealth(MaxBossHealth);

        BossHurtSound.GetComponent<AudioSource>();
        BossDeathSound.GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Arrow")
        {
            BossTakeDamage(ArrowScript.ArrowDamage);
            BossHurtSound.Play();
            Debug.Log("BOSS HIT BY AN ARROW!");
            //bossAnim.TakeHit();
        }
/*
        if (collision.collider.tag == "Player")
        {
            Debug.Log("BOSS has hit YOU " + playerScript.currentHealth);
            //PLAY ATTACK ANIMATION
            bossAnim.Attack();
            playerScript.PlayerHitSound.Play();
            playerScript.TakeDamage(BossHitDamage);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("BOSS has hit YOU " + playerScript.currentHealth);
            //PLAY ATTACK ANIMATION
            //bossAnim.Attack();
            BossSwordSound.Play();
            playerScript.PlayerHitSound.Play();
            playerScript.TakeDamage(BossHitDamage);
        }

    }

    public void BossTakeDamage(int damage)
    {
        currentBossHealth -= damage;
        bossHealthBar.SetHealth(currentBossHealth);
        //bossAnim.TakeHit();
        Debug.Log("BossHealth: " + currentBossHealth);

        if (currentBossHealth <= 0)
        {
            bossAnim.Death();
            BossDeathSound.Play();
            isBossAlive = false;
            if(canBeAttacked == true)
            {
                playerScript.points += BossEXP;
                canBeAttacked = false;

                StartCoroutine(WaitForCompletion());

                //Destroy(gameObject, 5f);
            }
            Debug.Log("BOSS DEAD");
        }
    }

    IEnumerator WaitForCompletion()
    {
        yield return new WaitForSeconds(waitDelay);
        gameComplete.CompletedGame();
        Destroy(gameObject, 5f);
    }
}
