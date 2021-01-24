using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogWalkState : StateMachineBehaviour
{
    public float speed = 2.5f;

    Transform player;
    Rigidbody2D rb;
    FrogEnemy frog;
    CircleCollider2D circle;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        circle = animator.GetComponent<CircleCollider2D>();
        frog = animator.GetComponent<FrogEnemy>();

        circle.offset = new Vector2(0, circle.offset.y - 0.2f);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        frog.LookAtPlayer();

        Vector2 target = new Vector2(Mathf.Sign(player.position.x - rb.position.x) * (100 * Time.fixedDeltaTime), rb.velocity.y);

        rb.velocity = target;
        if (Vector2.Distance(player.position, rb.position) > 20)
        {
            animator.SetBool("isDamaged", false);
        }
        //Debug.Log(Vector2.Distance(player.position.x, rb.position.x));
        if (Mathf.Abs(Mathf.Abs(player.position.x) - Mathf.Abs(rb.position.x)) <= 2.0f)
        {
            animator.SetTrigger("Waiting");
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Waiting");
        circle.offset = new Vector2(0, circle.offset.y + 0.2f);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
