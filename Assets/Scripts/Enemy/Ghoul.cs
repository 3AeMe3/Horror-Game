using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Ghoul : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    private NavMeshAgent navMeshAgent;
    [SerializeField]private SkinnedMeshRenderer skinnedMeshRenderer;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (IsVisible())
        {
            navMeshAgent.isStopped = true;
        }
        else
        {
            navMeshAgent.isStopped = false;

            MoveTowards();

        }



    }

    private bool IsVisible()
    {
        return skinnedMeshRenderer.isVisible;
    }

    private void MoveTowards()
    {
        navMeshAgent.SetDestination(playerPosition.position);
    }
}
