using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MonsterMover : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float locomotionSpeed;

    [SerializeField] private GameObject monsterAttackPoint;

    [SerializeField] private Transform target;

    [SerializeField] private Transform player;

    [SerializeField] private NavMeshAgent navMeshAgent;

    [SerializeField] private bool isBigMonster;

    private bool isAttacking = false;

    private Player playerComponent;

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
            playerComponent = player.GetComponent<Player>();
        }

        isBigMonster = gameObject.name.Contains("Big");
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < 10f)
        {
            //몬스터가 플레이어에게 이동
            navMeshAgent.SetDestination(player.position);

            if (!isAttacking && distanceToPlayer < 5f)
            {
                StartAttack("Attack1");
                PlayMonsterSound();
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

        if (attackAnimation == "Attack1" && playerComponent != null)
        {
            playerComponent.TakeDamage(5);
        }
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
            SoundManager.Instance.PlayMosterDie();
            animator.SetTrigger("Death");
            StartCoroutine(DestroyAfterDelay(2f));
        }
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    private void PlayMonsterSound()
    {
        if (isBigMonster)
        {
            SoundManager.Instance.PlayBigMonster();
        }
        else
        {
            SoundManager.Instance.PlaySmallMonster();
        }
    }
}
