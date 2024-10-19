using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrainingGunController : MonoBehaviour
{
    [SerializeField] TrainingBulletPool bulletPool;
    [SerializeField] Transform firePoint;
    [SerializeField] float fireSpeed;

    [SerializeField] int maxAmmo = 30;
    [SerializeField] float reloadTime = 1.3f;

    [SerializeField] TextMeshProUGUI ammoText;

    private int currentAmmo;
    private bool isReloading = false;

    private void Start()
    {
        currentAmmo = maxAmmo;

        if (bulletPool == null)
        {
            bulletPool = FindObjectOfType<TrainingBulletPool>();
        }

        UpdateAmmoUI();
    }

    private void Update()
    {
        if (currentAmmo <= 0 && !isReloading)
        {
            StartCoroutine(Reload());
        }
    }

    public void Fire(string bulletType)
    {
        if (isReloading || currentAmmo <= 0)
        {
            return;
        }

        SoundManager.Instance.PlayGunSound();
        GameObject bullet = bulletPool.GetBullet(bulletType); //������Ʈ Ǯ���� �Ѿ� ��������

        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;

            Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
            rigidbody.velocity = bullet.transform.forward * fireSpeed;

            currentAmmo--;
            UpdateAmmoUI();

            //�Ѿ��� ���� �� 2�� �ڿ� Ǯ�� ���ư����� ����
            bullet.GetComponent<TrainingBulletController>().StartReturnCoroutine(2f);
        }
    }

    private IEnumerator Reload()
    {
        SoundManager.Instance.PlayReloadSound();
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        UpdateAmmoUI();
        isReloading = false;
    }

    private void UpdateAmmoUI()
    {
        ammoText.text = currentAmmo + "/" + maxAmmo;
    }
}
