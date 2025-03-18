using StateMachinePractice;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;
public class EnemyPatrolState : StateMachineBehaviour
{
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    EnemyBehaviour Enemy;
    NavMeshAgent agent;
    Transform pointA, pointB, player;
    public Transform currentTarget;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Enemy = animator.GetComponent<EnemyBehaviour>();
        agent = animator.GetComponent<NavMeshAgent>();
        pointA = Enemy.pointA;
        pointB = Enemy.pointB;
        player = Enemy.playerPosition;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public async void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //if (Enemy.distanceToPlayer <= Enemy.chaseRadius)
       // {
       //     agent.speed = 5f;
      //      animator.SetBool("isChase", true);
      //      animator.SetBool("isPatrol", false);
      //      agent.SetDestination(player.position);
//
        //}
        if(!agent.pathPending && agent.remainingDistance < agent.stoppingDistance)
        {
            currentTarget = (currentTarget == pointA) ? pointB : pointA;
            Enemy.currentTarget = currentTarget;
            animator.speed = 0;
            await Task.Delay(1000);
            GoToDestination();
        }
        if (currentTarget == null) return;
        Vector3 direction = currentTarget.transform.position;
        if(agent.velocity.magnitude>0.01f)//check if AI is not moving
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            Enemy.transform.rotation = rotation;

        }
        void GoToDestination()
        {
            animator.speed = 1;
            agent.SetDestination(currentTarget.position);
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
