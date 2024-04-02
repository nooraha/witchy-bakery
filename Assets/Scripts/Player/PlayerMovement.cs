using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    Vector3 targetPosition;
    NavMeshAgent agent;

    private void Awake()
    {
        agent = FindObjectOfType<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        UpdateTargetPosition();
        UpdateAgentDestination();
    }

    void UpdateTargetPosition()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void UpdateAgentDestination()
    {
        agent.SetDestination(new Vector3(targetPosition.x, targetPosition.y, transform.position.z));
    }
}
