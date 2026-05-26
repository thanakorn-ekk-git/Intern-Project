using UnityEngine;
using UnityEngine.AI;

namespace Character {
    [RequireComponent(typeof(NavMeshAgent))]

    public class AIMovement : CharacterMovement {

        private Vector3 targetPos;

        public NavMeshAgent Agent => agent;
        private NavMeshAgent agent;

        private bool canMove = true;

        protected override void Awake() {
            base.Awake();
            agent = GetComponent<NavMeshAgent>();
        }
        void Start() {
            agent.updatePosition = false;
            agent.updateRotation = false;
        }

        protected override void Update() {
            base.Update();

            if (!canMove)
                return;

            agent.SetDestination(targetPos);
            agent.nextPosition = transform.position;

            Vector3 moveDirection = agent.desiredVelocity.normalized;

            if (agent.remainingDistance > agent.stoppingDistance) {
                Move(new Vector3(moveDirection.x, 0, moveDirection.z));
            } else {
                Move(Vector3.zero);
                LookAtTarget(targetPos);
            }
        }

        public void SetTarget(Vector3 worldPosition) {
            targetPos = worldPosition;
        }

        protected override void ApplyMovement() {
            base.ApplyMovement();
            ResetInputDirection();
        }

        private void LookAtTarget(Vector3 position) {
            Vector3 direction = (position - transform.position).normalized;
            direction.y = 0f;

            if (direction != Vector3.zero) {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            }
        }
    }
}