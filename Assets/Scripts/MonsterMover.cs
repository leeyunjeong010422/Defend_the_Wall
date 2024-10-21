using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMover : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float locomotionSpeed;

    [SerializeField] private GameObject monsterAttackPoint;

    [SerializeField] private Transform target;

    [SerializeField] private Transform player;

    [SerializeField] private NavMeshAgent navMeshAgent;

    private bool isAttacking = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator.SetFloat("Locomotion", 1);

        monsterAttackPoint = GameObject.Find("MonsterAttackPoint");
        target = monsterAttackPoint.transform;

        GameObject xrOrigin = GameObject.Find("XR Origin");
        if (xrOrigin != null)
        {
            player = xrOrigin.transform;
        }
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < 10f)
        {
            //몬스터가 플레이어에게 이동
            navMeshAgent.SetDestination(player.position);

            if (!isAttacking && distanceToPlayer < 2f)
            {
                StartAttack("Attack1");
            }
        }
        else
        {
            if (isAttacking)
            {
                StopAttack();
            }

            //monsterAttackPoint에 도착하지 않았을 때만 이동
            navMeshAgent.SetDestination(target.position);
        }

        //monsterAttackPoint에 도착한 경우
        if (!isAttacking && Vector3.Distance(transform.position, target.position) < 1f)
        {
            StartAttack("Attack2");
        }
    }

    private void StartAttack(string attackAnimation)
    {
        isAttacking = true;
        navMeshAgent.isStopped = true;
        Attack(attackAnimation);
        StartCoroutine(AttackLoop(attackAnimation));
    }

    private void StopAttack()
    {
        isAttacking = false;
        navMeshAgent.isStopped = false;
        animator.ResetTrigger("Attack1");
        animator.ResetTrigger("Attack2");
    }

    private void Attack(string attackAnimation)
    {
        animator.SetTrigger(attackAnimation);
    }

    private IEnumerator AttackLoop(string attackAnimation)
    {
        while (isAttacking)
        {
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            Attack(attackAnimation);
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
