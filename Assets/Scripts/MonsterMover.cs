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
    }

    private void Update()
    {
        // monsterAttackPoint�� ������ ���
        if (Vector3.Distance(transform.position, monsterAttackPoint.transform.position) < 1f)
        {
            // ���� ���� �ƴ� �� ���� ����
            if (!isAttacking)
            {
                StartAttack(); // ������ �����ϴ� �޼��� ȣ��
            }
        }
        else
        {
            // monsterAttackPoint�� �������� �ʾ��� ���� �̵�
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void StartAttack()
    {
        isAttacking = true; // ���� ���·� ����
        navMeshAgent.isStopped = true; // �̵� ����
        Attack(); // ���� �޼��� ȣ��
        StartCoroutine(AttackLoop()); // ���� ���� ����
    }

    private void Attack()
    {
        animator.SetTrigger("Attack2"); // ���� �ִϸ��̼� Ʈ����
    }

    private IEnumerator AttackLoop()
    {
        while (isAttacking)
        {
            // �ִϸ��̼� ���̸�ŭ ���
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            Attack(); // �ٽ� ���� �޼��� ȣ��
        }
    }

    // ������ �����ϴ� �޼��� �߰� (�ʿ� �� ȣ�� ����)
    public void StopAttack()
    {
        isAttacking = false; // ���� ���� ����
        navMeshAgent.isStopped = false; // �̵� �簳
    }
}
