using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;
namespace StateMachinePractice
{

    public class EnemyBehaviour : MonoBehaviour
    {
        private NavMeshAgent agent;
        public Transform pointA, pointB,playerPosition;
        public Transform currentTarget;

        public float chaseRadius;
        public bool isChasing = false;
        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            StartPatrol();
        }
        void Start()
        {
            agent.speed = 0f;
        }

        void Update()
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerPosition.position);
            if(distanceToPlayer < chaseRadius)
            {
                agent.speed = 5f;
                isChasing = true;
                currentTarget = playerPosition;
                agent.SetDestination(playerPosition.position);

            }

            else if(!agent.pathPending && agent.remainingDistance < agent.stoppingDistance)
            {
                currentTarget = (currentTarget == pointA) ? pointB : pointA;
                agent.SetDestination(currentTarget.position);
            }


            
        }

        public async void StartPatrol()
        {
            await Task.Delay(5000);
            agent.speed = 3.5f;
            currentTarget = pointA;
            agent.SetDestination(currentTarget.position);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position,chaseRadius);
        }
    }
}
