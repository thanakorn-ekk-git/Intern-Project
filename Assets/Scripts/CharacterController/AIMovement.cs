using UnityEngine;
using Unity.AI;
using UnityEngine.AI;
using System;

public class AIMovement : MonoBehaviour
{
    public Transform targetPos;

    private NavMeshAgent agent;
    private CharacterMovement charMovement;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        charMovement = GetComponent<CharacterMovement>();

        agent.updatePosition = false;
        agent.updateRotation = false;
    }

    void Update()
    {
        if (targetPos == null)
            return;
        agent.SetDestination(targetPos.position);
        agent.nextPosition = transform.position;

        Vector3 moveDirection = agent.desiredVelocity.normalized;

        if(agent.remainingDistance>agent.stoppingDistance)
        {
            charMovement.Move(new Vector3(moveDirection.x, 0, moveDirection.z));
        }
        else
        {
            charMovement.Move(Vector3.zero);

            FaceTarget(targetPos.position);
        }
    }

    private void FaceTarget(Vector3 position)
    {
        Vector3 direction = (position - transform.position).normalized;
        direction.y = 0f;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }
}
