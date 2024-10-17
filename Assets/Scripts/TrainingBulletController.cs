using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingBulletController : MonoBehaviour
{
    private TrainingBulletPool bulletPool;
    private Rigidbody bulletRigidbody;
    private Coroutine returnCoroutine;

    private void Start()
    {
        bulletPool = FindObjectOfType<TrainingBulletPool>();
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            ReturnToPool(); //���� �浹�ϸ� Ǯ�� ��ȯ
        }
    }

    private void OnEnable()
    {
        ResetBullet(); //�Ѿ� �ʱ�ȭ
    }

    private void OnDisable()
    {
        if (returnCoroutine != null)
        {
            StopCoroutine(returnCoroutine); //���� �ڷ�ƾ �ߴ�
        }
    }

    private void ResetBullet()
    {
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = Vector3.zero; //�ӵ� �ʱ�ȭ
            bulletRigidbody.angularVelocity = Vector3.zero; //ȸ�� �ӵ� �ʱ�ȭ
        }
    }

    public void ReturnToPool()
    {
        if (returnCoroutine != null)
        {
            StopCoroutine(returnCoroutine); //Ȱ��ȭ ���¿��� �ڷ�ƾ �ߴ�
        }

        bulletPool.ReturnBullet(gameObject); //�Ѿ��� Ǯ�� ��ȯ
    }

    public void StartReturnCoroutine(float delay)
    {
        returnCoroutine = StartCoroutine(ReturnBulletAfterDelay(delay));
    }

    private IEnumerator ReturnBulletAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnToPool(); //���� �� �Ѿ� ��ȯ
    }
}
