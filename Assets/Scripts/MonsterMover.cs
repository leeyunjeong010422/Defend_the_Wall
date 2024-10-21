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

    [SerializeField] NavMeshAgent navMeshAgent;

    private bool isAttacking = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator.SetFloat("Locomotion", 1);

        monsterAttackPoint = GameObject.Find("AttackPointackPoint");
        target = GameObject.Find("AttackPointackPoint").transform;
    }

    private void Update()
    {
        //monsterAttackPoint�� ������ ���
        if (Vector3.Distance(transform.position, monsterAttackPoint.transform.position) < 1f)
        {
            //���� ���� �ƴ� �� ���� ����
            if (!isAttacking)
            {
                StartAttack();
            }
        }
        else
        {
            //monsterAttackPoint�� �������� �ʾ��� ���� �̵�
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void StartAttack()
    {
        isAttacking = true;
        navMeshAgent.isStopped = true;
        Attack();
        StartCoroutine(AttackLoop());
    }

    private void Attack()
    {
        animator.SetTrigger("Attack2");
    }

    private IEnumerator AttackLoop()
    {
        while (isAttacking)
        {
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            Attack();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            animator.SetTrigger("Death");
            StartCoroutine(DestroyAfterDelay(2f));
        }
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

}
