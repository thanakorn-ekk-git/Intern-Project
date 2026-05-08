using Attack;
using Character;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance;
using static Enemy.EnemyBehavior;

namespace Enemy
{
    public class EnemyBehavior : MonoBehaviour
    {
        public enum EnemyState
        {
            Idle, Chasing, Attacking, Restarting
        }
        [SerializeField] private EnemyState currentState = EnemyState.Idle;

        [SerializeField] private AIMovement aiMovement;
        [SerializeField] private Transform targetPos;
        [SerializeField] private Attacker attacker;

        private float checkStateTimer;
        [SerializeField] private float checkStateInterval = 0.2f;

        [SerializeField] private float viewDistance = 50f;
        [SerializeField] private float heightOffset = 0.3f;

        [SerializeField] private float attackRange = 2f;
        [SerializeField] private float attackCooldown = 2f;
        private float lastAttackTime;
        [SerializeField] private float minMaxAttackRanRange;

        private Vector3 retreatPos;

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

            checkStateTimer += Time.deltaTime;
            if(checkStateTimer >= checkStateInterval)
            {
                ChangeState();
                checkStateTimer = 0f;
            }

            EnemyAction();
        }

        private void ChangeState()
        {
            if (currentState == EnemyState.Restarting)
            {
                return;
            }

            if(distanceToPlayer <= attackRange)
            {
                currentState = EnemyState.Attacking;
                return;
            }
            else if (TargetOnSight())
            {
                currentState = EnemyState.Chasing;
            }
            else
            {
                aiMovement.SetTarget(null);
                currentState = EnemyState.Idle;
            }
        }

        private void EnemyAction()
        {
            switch (currentState)
            {
                case EnemyState.Idle:
                    break;
                case EnemyState.Chasing:
                    TargetOnSight();
                    aiMovement.SetTarget(targetPos);
                    break;
                case EnemyState.Attacking:
                    if (Time.time >= lastAttackTime + attackCooldown)
                    {
                        PerformAttack();
                    }
                    break;
                case EnemyState.Restarting:
                    if(aiMovement.Agent.remainingDistance <= aiMovement.Agent.stoppingDistance)
                    {
                        currentState = EnemyState.Idle;
                    }
                    break;
            }
        }

        private bool TargetOnSight()
        {
            origin =  new Vector3 (transform.position.x, transform.position.y + heightOffset, transform.position.z);
            Vector3 targetWithOffset = new Vector3 (targetPos.position.x, targetPos.position.y + heightOffset, targetPos.position.z);

            Vector3 directionToPlayer = (targetWithOffset - origin).normalized;

            Debug.DrawRay(origin, directionToPlayer * viewDistance, Color.green);

            RaycastHit raycast;
            if (Physics.Raycast(origin, directionToPlayer, out raycast, viewDistance))
            {
                if (raycast.collider.CompareTag("Player"))
                {
                    return true;
                }
            }
            return false;
        }
        void PerformAttack()
        {
            aiMovement.SetTarget(null);
            attacker.Attack();
            StartCoroutine(attacker.AttackImpactCoroutine(2.0f));
            lastAttackTime = Time.time;

            ResetAttack();
        }

        private void ResetAttack()
        {
            float randX = UnityEngine.Random.Range(-minMaxAttackRanRange, minMaxAttackRanRange);
            float randZ = UnityEngine.Random.Range(-minMaxAttackRanRange, minMaxAttackRanRange);
            Vector3 randomPoint = new Vector3(targetPos.position.x + randX,
                                                targetPos.position.y + 5f,
                                                targetPos.position.z + randZ);

            if(Physics.Raycast(randomPoint, Vector3.down, out RaycastHit hit, 10f))
            {
                retreatPos = hit.point;
                aiMovement.SetDestination(retreatPos);
                currentState = EnemyState.Restarting;
            }
        }
    }
}