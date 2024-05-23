using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;


public class Ghoul : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    private Animation enemyAnimation;
  

    bool canAttack;

    [SerializeField] private float distanceForAttack = 1.5f;


    [SerializeField] private PlayableDirector killAnimation; 
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAnimation = GetComponent<Animation>();
        
    }


    private void Start()
    {
        //animator.Play();


    }
    private void Update()
    {
        if (!canAttack)
        {

            if (IsVisible())
            {
                navMeshAgent.isStopped = true;
               // enemyAnimation.Stop();
            }
            else
            {
                navMeshAgent.isStopped = false;
                //enemyAnimation.Play("Run");
                MoveTowards();

            }

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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            canAttack = true;
            killAnimation.Play();

        }
    }

}
