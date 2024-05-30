using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;


public class Ghoul : MonoBehaviour
{
    [Header("NavMesh")]
    [SerializeField] private Transform playerPosition;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    private Animator animator;
  

    bool canAttack;

    [SerializeField] private float distanceForAttack = 1.5f;


    [SerializeField] private PlayableDirector killAnimation;
    [SerializeField] private CinemachineVirtualCamera deathCamera;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        
    }


    private void Start()
    {
        


    }
    private void Update()
    {
        if (!canAttack)
        {

            /* if (IsVisible())
             {
                 StopIfVisible();
             }
             else
             {



             }*/
          
            
            navMeshAgent.isStopped = false;
            animator.Play("Walk");
            MoveTowards();
        }
   

    }

    private bool IsVisible()
    {
        return skinnedMeshRenderer.isVisible;
    }

    /// <summary>
    /// Si el player mira al enemigo este se detiene
    /// </summary>
    private void StopIfVisible()
    {
        navMeshAgent.isStopped = true;
        animator.speed = 0f;
    }

    private void MoveTowards()
    {
        navMeshAgent.SetDestination(playerPosition.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
       
            canAttack = true;
            killAnimation.Play();

        }
    }

}
