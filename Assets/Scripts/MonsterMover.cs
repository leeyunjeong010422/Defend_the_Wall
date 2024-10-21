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
        // monsterAttackPoint에 도착한 경우
        if (Vector3.Distance(transform.position, monsterAttackPoint.transform.position) < 1f)
        {
            // 공격 중이 아닐 때 공격 시작
            if (!isAttacking)
            {
                StartAttack(); // 공격을 시작하는 메서드 호출
            }
        }
        else
        {
            // monsterAttackPoint에 도착하지 않았을 때만 이동
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void StartAttack()
    {
        isAttacking = true; // 공격 상태로 설정
        navMeshAgent.isStopped = true; // 이동 중지
        Attack(); // 공격 메서드 호출
        StartCoroutine(AttackLoop()); // 공격 루프 시작
    }

    private void Attack()
    {
        animator.SetTrigger("Attack2"); // 공격 애니메이션 트리거
    }

    private IEnumerator AttackLoop()
    {
        while (isAttacking)
        {
            // 애니메이션 길이만큼 대기
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            Attack(); // 다시 공격 메서드 호출
        }
    }

    // 공격을 종료하는 메서드 추가 (필요 시 호출 가능)
    public void StopAttack()
    {
        isAttacking = false; // 공격 상태 해제
        navMeshAgent.isStopped = false; // 이동 재개
    }
}
