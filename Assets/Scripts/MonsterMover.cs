using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMover : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float locomotionSpeed;

    [SerializeField] GameObject monsterAttackPoint;

    [SerializeField] Transform target;

    NavMeshAgent navMeshAgent;

    private void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator.SetFloat("Locomotion", 1);
    }

    private void Update()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == monsterAttackPoint)
        {
            Attack();
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack2");
    }
}
