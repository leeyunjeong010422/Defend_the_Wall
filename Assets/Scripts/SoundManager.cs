using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioSource gun;
    [SerializeField] private AudioSource reload;
    [SerializeField] private AudioSource enemyDie;
    [SerializeField] private AudioSource score_10;

    [SerializeField] private AudioSource bigMonster;
    [SerializeField] private AudioSource smallMonster;
    [SerializeField] private AudioSource monsterDie;

    private float previousTime = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetStartBGM()
    {
        PlayBGM(bgm);
    }

    public void PlayBGM(AudioSource bgm)
    {
        bgm.time = previousTime;
        bgm.loop = true;
        bgm.Play();
    }

    public void StopBGM()
    {
        previousTime = bgm.time; //startBGM의 현재 시간 저장
        bgm.Stop();
    }

    public void PlayGunSound()
    {
        gun.PlayOneShot(gun.clip);
    }

    public void PlayReloadSound()
    {
        reload.PlayOneShot(reload.clip);
    }

    public void PlayEnemyDieSound()
    {
        enemyDie.PlayOneShot(enemyDie.clip);
    }

    public void PlayScore_10Sound()
    {
        score_10.PlayOneShot(score_10.clip);
    }

    public void PlayBigMonster()
    {
        bigMonster.PlayOneShot(bigMonster.clip);
    }

    public void PlaySmallMonster()
    {
        smallMonster.PlayOneShot(smallMonster.clip);
    }

    public void PlayMosterDie()
    {
        monsterDie.PlayOneShot(monsterDie.clip);
    }
}

