using Character;
using Attack;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(AIMovement))]
    public class EnemyBehavior : MonoBehaviour
    {
        AIMovement aiMovement;

        [SerializeField] private Transform targetPos;
        [SerializeField] private float viewDistance = 50f;
        [SerializeField] private float heightOffset = 0.3f;

        [SerializeField] private Attacker attacker;
        [SerializeField] private float attackRange = 2f;

        private float distanceToPlayer;

        private Vector3 origin;

        private void Start()
        {
            aiMovement = GetComponent<AIMovement>();
        }

        private void Update()
        {
            if(targetPos == null)
                return;

            distanceToPlayer = Vector3.Distance(transform.position, targetPos.position);
            TargetOnSight();
        }

        void TargetOnSight()
        {
            origin = transform.position;
            origin.y += heightOffset;

            Vector3 targetWithOffset = targetPos.position;
            targetWithOffset.y += heightOffset;

            Vector3 directionToPlayer = (targetWithOffset - origin).normalized;

            RaycastHit raycast;
            if (Physics.Raycast(origin, directionToPlayer, out raycast, viewDistance))
            {
                if (raycast.collider.CompareTag("Player") && distanceToPlayer >= attackRange)
                {
                    aiMovement.targetPos = raycast.transform;
                }
                else if (distanceToPlayer <= attackRange)
                {
                    aiMovement.targetPos = null;
                    attacker.Attack();
                    StartCoroutine(attacker.AttackImpactCoroutine(2.0f));
                }
                else
                {
                    aiMovement.targetPos = null;
                }
            }
        }
    }
}
