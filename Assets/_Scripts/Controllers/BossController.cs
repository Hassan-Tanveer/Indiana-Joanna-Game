using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    public float lookRadius = 60f;
    public float attackRadius = 35f;
    public bool grounded = false;
    Transform target;
    NavMeshAgent agent;
    Animator anim;
    public Rigidbody rb;

    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
   // public float vSpeed;

    public BossStats bossStats;
    public BossAnim bossAnim;

    public AudioSource BossWalkSound;
    public AudioSource BossRunSound;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
        //gets the nav mesh component for the enemy
        agent = GetComponent<NavMeshAgent>();

        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        //Checks if enemy is within the radius/range of player and chases to attack
        if (bossStats.isBossAlive && distance <= lookRadius && distance > attackRadius)
        {
            BossRunSound.GetComponent<AudioSource>();
            BossRunSound.Play();
            agent.SetDestination(target.position);

            //anim.SetBool("isIdle", false);
            anim.SetBool("isWalk", false);
            
            anim.SetBool("isRun", true);
            
            anim.SetBool("Attack1", false);
            anim.SetBool("Attack2", false);
            anim.SetBool("TakeHit", false);
        }

        //If player is out of range then enemy stops running and starts walking 
        else if (bossStats.isBossAlive && distance > lookRadius)
        {
            anim.SetBool("isRun", false);
            anim.SetBool("isWalk", true);
            BossWalkSound.GetComponent<AudioSource>();
            BossWalkSound.Play();
        }

        //if player is within the attack range then attack
        else if (bossStats.isBossAlive && distance <= attackRadius)
        {
            anim.SetBool("isRun", false);
            anim.SetBool("isWalk", false);
            anim.SetBool("Attack1", true);
            anim.SetBool("Attack2", true);
            bossStats.BossSwordSound.Play();
        }

        //Enemy faces the player when in range
        if (bossStats.isBossAlive && distance <= agent.stoppingDistance)
        {
            FaceTarget();
        }

        if (bossStats.currentBossHealth <= 0)
        {
            bossAnim.Death();
            //target = GameObject.FindGameObjectWithTag("Enemy").transform;

            //anim.SetBool("isIdle", true);
        }

    }
    void FaceTarget()
    {
        //Enemy faces the target (player) at every rotation and angle the player is facing
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

    }

    void FixedUpdate()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundRadius, whatIsGround);
        //vSpeed = rb.velocity.y;
        //anim.SetFloat("vSpeed", vSpeed);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
