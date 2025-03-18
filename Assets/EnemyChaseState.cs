using StateMachinePractice;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : StateMachineBehaviour
{
    EnemyBehaviour enemyBehaviour;
    NavMeshAgent agent;
    Transform pointA,pointB,player,currentTarget;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyBehaviour = animator.GetComponent<EnemyBehaviour>();
        agent = animator.GetComponent<NavMeshAgent>();
        player = enemyBehaviour.playerPosition;
        agent.speed = 7;
    }

   // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distanceToPlayer = enemyBehaviour.distanceToPlayer;
        agent.SetDestination(player.position);
        if(enemyBehaviour.distanceToPlayer <=enemyBehaviour.chaseRadius)
        {
            animator.SetBool("isChase", true);
            animator.SetBool("isPatrol", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
