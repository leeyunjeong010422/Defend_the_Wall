using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMover : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float locomotionSpeed;

    private void Start()
    {
        animator.SetFloat("Locomotion", 1);
    }
}
