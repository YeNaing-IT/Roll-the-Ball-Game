using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;

namespace YeNaing
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] Transform playerTransform;
        [SerializeField] Transform guardTransform;
        private NavMeshAgent agent;

        [SerializeField] float chaseDistance;
        [SerializeField] float lastSawPlayerTimer;
        [SerializeField] float suscpicousTimer;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }
        void Update()
        {
            if (playerTransform != null)
            {
                ChasePlayer();
            }
        }

        // Chase Player
        public void ChasePlayer()
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
            
            if (distanceToPlayer <= chaseDistance) // If Player is in Chase Distance
            {
                lastSawPlayerTimer = 0;
                agent.isStopped = false;
                agent.SetDestination(playerTransform.position);
            }
            else if (lastSawPlayerTimer <= suscpicousTimer) // Player out of sight, suspicious Timer
            {
                lastSawPlayerTimer = lastSawPlayerTimer + Time.deltaTime;
                agent.isStopped = true;
            }
            else // Player out of sight, return to guard position
            {
                agent.isStopped = false;
                ReturnToGuardPosition();
            }
            
        }

        // Return to Guard Position
        public void ReturnToGuardPosition()
        {
            if (guardTransform == null) return;
            agent.SetDestination(guardTransform.position);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}
