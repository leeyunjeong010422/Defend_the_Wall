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
        GameObject bullet = bulletPool.GetBullet(bulletType); //오브젝트 풀에서 총알 가져오기

        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;

            Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
            rigidbody.velocity = bullet.transform.forward * fireSpeed;

            //총알이 사용된 후 2초 뒤에 풀로 돌아가도록 설정
            bullet.GetComponent<TrainingBulletController>().StartReturnCoroutine(2f);
        }
    }
}
