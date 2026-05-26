using Attack; 
using Character;
using Data;
using GameManagement;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

namespace Enemy
{
    public class EnemyBehavior : MonoBehaviour
    {
        private enum State
        {
            Idle, Chase, Attack, Restart, Retreat
        }

        [SerializeField] private State currentState = State.Idle;

        [SerializeField] private AIMovement aiMovement;
        [SerializeField] private Transform targetPos;
        [SerializeField] private Attacker attacker;

        private float checkStateTimer;
        [SerializeField] private float checkStateInterval = 0.2f;

        [SerializeField] private float viewDistance = 50f;
        [SerializeField] private float heightOffset = 0.3f;

        [SerializeField] private float attackRange = 2f;
        [SerializeField] private float retreatRange;
        [SerializeField] private float attackCooldown = 2f;
        private float lastAttackTime;

        [SerializeField] private GameObject retreatPos;

        private float distanceToPlayer;

        private Vector3 origin;

        [SerializeField] private string enemyID;
        private EnemyGameData myEnemyData;

        public void Initialize(EnemyGameData data)
        {
            myEnemyData = data;

            if (TryGetComponent<Attacker>(out var attacker) && TryGetComponent<EntityWithHealth>(out var defender))
            {
                const int zeroStrengthForEnemy = 0;
                attacker.SetData(myEnemyData.Stats.AtkDamage, zeroStrengthForEnemy);
                defender.SetData(myEnemyData.Stats.Defense, myEnemyData.Stats.MaxHealth);
            }

        }

        private void Update()
        {
            if(targetPos == null)
                return;

            distanceToPlayer = Vector3.Distance(transform.position, targetPos.position);

            checkStateTimer += Time.deltaTime;
            if(checkStateTimer >= checkStateInterval)
            {
                UpdateState();
                checkStateTimer = 0f;
            }
            TakeAction();
        }

        private void UpdateState()
        {
            if (currentState == State.Retreat)
            {
                return;
            }
            else if(distanceToPlayer <= attackRange)
            {
                currentState = State.Attack;
                return;
            }
            else if (IsPlayerOnSight())
            {
                currentState = State.Chase;
            }
            else if(!IsPlayerOnSight())
            {
                aiMovement.SetTarget(Vector3.zero);
                currentState = State.Idle;
            }
        }

        private void TakeAction()
        {
            switch (currentState)
            {
                case State.Idle:
                    break;
                case State.Chase:
                    IsPlayerOnSight();
                    aiMovement.SetTarget(targetPos.position);
                    break;
                case State.Attack:
                    if (Time.time >= lastAttackTime + attackCooldown)
                    {
                        PerformAttack();
                    }
                    break;
                case State.Retreat:
                    if (aiMovement.Agent.remainingDistance <= aiMovement.Agent.stoppingDistance)
                    {
                        currentState = State.Idle;
                    }
                    break;
            }
        }

        private bool IsPlayerOnSight()
        {
            origin =  new Vector3 (transform.position.x, transform.position.y + heightOffset, transform.position.z);
            Vector3 targetWithOffset = new Vector3 (targetPos.position.x, targetPos.position.y + heightOffset, targetPos.position.z);
            Vector3 directionToPlayer = (targetWithOffset - origin).normalized;

            RaycastHit raycastResult;
            LayerMask groundAndEntity = GameManager.Instance.LayerEntityAndGround;

            if (Physics.Raycast(origin, directionToPlayer, out raycastResult, viewDistance, groundAndEntity) 
                && raycastResult.collider.CompareTag(Tags.Player))
            {
                return true;
            }
            return false;
        }
        void PerformAttack()
        {
            aiMovement.SetTarget(Vector3.zero);
            attacker.Attack();
            lastAttackTime = Time.time;
        }

        public void PerformRetreat()
        {
            const float raycastHeight = 10f;
            Vector3 randRadius = Random.insideUnitCircle * retreatRange;
            Vector3 randPoint = new Vector3(transform.position.x + randRadius.x
                , 0 + raycastHeight
                , transform.position.z + randRadius.y);

            if (Physics.Raycast(randPoint, Vector3.down, out RaycastHit hit, raycastHeight, GameManager.Instance.LayerGround))
            {
                aiMovement.SetTarget(hit.point);
                currentState = State.Retreat;
            }
        }
    }
}