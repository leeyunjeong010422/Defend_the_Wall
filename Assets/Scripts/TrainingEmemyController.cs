using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingEmemyController : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); //총알 제거
            Destroy(gameObject); //적 제거
        }
    }
}
