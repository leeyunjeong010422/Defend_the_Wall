using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingGunController : MonoBehaviour
{
    [SerializeField] TrainingBulletPool bulletPool;
    [SerializeField] Transform firePoint;
    [SerializeField] float fireSpeed;

    private void Start()
    {
        if (bulletPool == null)
        {
            bulletPool = FindObjectOfType<TrainingBulletPool>();
        }
    }

    public void Fire(string bulletType)
    {
        SoundManager.Instance.PlayGunSound();
        GameObject bullet = bulletPool.GetBullet(bulletType); //������Ʈ Ǯ���� �Ѿ� ��������

        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;

            Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
            rigidbody.velocity = bullet.transform.forward * fireSpeed;

            //�Ѿ��� ���� �� 2�� �ڿ� Ǯ�� ���ư����� ����
            bullet.GetComponent<TrainingBulletController>().StartReturnCoroutine(2f);
        }
    }
}
