using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Ghoul : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    private Animation enemyAnimation;

    bool canAttack;

    [SerializeField] private float distanceForAttack = 1.5f;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAnimation = GetComponent<Animation>();
    }


    private void Start()
    {


    }
    private void Update()
    {
        if (!canAttack)
        {

            if (IsVisible())
            {
                navMeshAgent.isStopped = true;
                enemyAnimation.Stop();
            }
            else
            {
                navMeshAgent.isStopped = false;
                enemyAnimation.Play("Run");
                MoveTowards();

            }

        }
        //DistanceToPlayer();

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
            //animacion De Muerte

        }
    }
    /*  private void DistanceToPlayer()
      {
          float distance = Vector3.Distance(transform.position ,playerPosition.position);

          if (distance < distanceForAttack)
          {
              Debug.Log("perdiste");
          }
      }*/
}
