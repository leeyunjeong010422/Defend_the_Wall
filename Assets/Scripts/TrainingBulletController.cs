using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingBulletController : MonoBehaviour
{
    private TrainingBulletPool bulletPool;
    private bool isReturning = false; //중간중간 총알이 사라져서 중복 호출 오류 해결

    private void Start()
    {
        bulletPool = FindObjectOfType<TrainingBulletPool>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !isReturning)
        {
            isReturning = true;
            bulletPool.ReturnBullet(gameObject); //Enemy에 닿으면 풀로 돌아가기
        }
    }

    private void OnEnable()
    {
        isReturning = false; //활성화될 때 초기화
    }
}
