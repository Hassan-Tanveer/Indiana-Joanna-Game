using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This method handles and controls the enemy animations
 * from and using the animtor
 */

public class BossAnim : MonoBehaviour
{

    public Animator anim;

    // Use this for initialization
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Walk()
    {
        anim.SetBool("isWalk", !(anim.GetBool("isWalk")));
        anim.SetBool("isIdle", false);
    }

    public void Idle()
    {
        anim.SetBool("isIdle", true);
        anim.SetBool("isRun", false);
        //anim.SetBool("isJump", false);
        anim.SetBool("isWalk", false);
    }

    public void Run()
    {
        anim.SetBool("isRun", !(anim.GetBool("isRun")));
        anim.SetBool("isWalk", false);
        anim.SetBool("isIdle", false);
    }
    /* ATTACK ANIMATION
     */
    /*public void Attack()
    {
        //anim.SetBool("isJump", true);
        anim.SetInteger("Condition", 2);
        StartCoroutine(StopAttacking());
    }
    IEnumerator StopAttacking()
    {
        yield return new WaitForSeconds(4f);
        anim.SetInteger("Condition", 0);
    }
    */


    public void Attack()
    {
        anim.SetBool("isRun", false);
        anim.SetBool("isWalk", false);
        anim.SetBool("isIdle", true);
        anim.SetBool("Attack1", true);
        anim.SetBool("Attack2", true);
    }
    /* public void TakeHitDamage()
     {
         //Idle();
         //anim.SetInteger("Condition", 3);
         anim.SetBool("isRun", false);
         anim.SetBool("isIdle", false);
         anim.SetBool("isWalk", false);
         StartCoroutine(RecoverFromHit());
     }

     IEnumerator RecoverFromHit()
     {
         yield return new WaitForSeconds(2f);
         anim.SetInteger("Condition", 0);
     }*/

    public void TakeHit ()
    {
        anim.SetBool("isIdle", false);
        anim.SetBool("isRun", false);
        anim.SetBool("isWalk", false);
        anim.SetBool("Attack1", false);
        anim.SetBool("Attack2", false);
        anim.SetBool("TakeHit", true);
    }

    public void Death()
    {
        //Idle();
        //anim.SetInteger("Condition", 4);
        //anim.SetBool("isDead", !(anim.GetBool("isDead")));
        //anim.SetBool("isIdle", false);
        anim.SetBool("isRun", false);
        anim.SetBool("isWalk", false);
        anim.SetBool("Attack1", false);
        anim.SetBool("Attack2", false);
        anim.SetBool("TakeHit", true);
        anim.SetBool("isDead", true);
    }
}
