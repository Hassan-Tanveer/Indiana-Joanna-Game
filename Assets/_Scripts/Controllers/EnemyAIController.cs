using UnityEngine;
using UnityEngine.AI;

/* This method is ressponsible for controlling the enemy movements
 * using the enemy animation class
 */

public class EnemyAIController : MonoBehaviour {

    public float jumpSpeed = 600.0f;
    public bool grounded = false;
    public bool doubleJump = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    Animator anim;
    public Rigidbody rb;
    public float vSpeed;

    //created my own varaibles for enemy tracking
    public EnemyAnimMovement enemyAnimMovement;
    public float lookRadius = 30f;
    Transform target;
    NavMeshAgent agent;

    public AudioSource ZombieGrowlSound;
    public AudioSource ZombieWalkSound;

    public EnemyStats enemyStats;
    //private float minAttackDistance = 15f;

    // Use this for initialization
    void Awake() {
        //Sets the target to the player
        target = GameObject.FindWithTag("Player").transform;
        //gets the nav mesh component for the enemy
        agent = GetComponent<NavMeshAgent>();


		anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        anim.SetBool("isIdle", true);
	}

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        //Checks if enemy is within the radius/range of player and chases to attack
        if (enemyStats.isEnemyAlive && distance <= lookRadius)
        {
            ZombieWalkSound.GetComponent<AudioSource>();
            ZombieWalkSound.Play();
            agent.SetDestination(target.position);

            //anim.SetBool("isIdle", false);
            anim.SetBool("crippled", false);
            //anim.SetBool("isJump", true);
            anim.SetBool("isRun", true);

        }

        //If enemy is out of range then enemy stops running and starts walking 
        else if (enemyStats.isEnemyAlive && distance > lookRadius)
        {
            //.SetBool("isJump", false);
            anim.SetBool("isRun", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("crippled", true);
            //enemyAnimMovement.CrippledWalk();
            ZombieGrowlSound.GetComponent<AudioSource>();
            ZombieGrowlSound.Play();
        }

        //Enemy faces the player when in range
        if (enemyStats.isEnemyAlive && distance <= agent.stoppingDistance)
        {
            FaceTarget();
        }

        if (enemyStats.currentEnemyHealth <= 0)
        {
            enemyAnimMovement.Death();
            //target = GameObject.FindGameObjectWithTag("Enemy").transform;

            //anim.SetBool("isIdle", true);
        }

    }

    void FaceTarget()
    {
        //Enemy faces the target (player) at every rotation and angle the player is facing
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*5f);

    }

    void FixedUpdate()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundRadius, whatIsGround);
        vSpeed = rb.velocity.y;
        anim.SetFloat("vSpeed", vSpeed);
    }

    public void Jump()
    {
        if (grounded && rb.velocity.y == 0)
        {
            anim.SetTrigger("isJump");
            rb.AddForce(0, jumpSpeed, 0, ForceMode.Impulse);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
