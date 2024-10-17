using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefabs;
    [SerializeField] Transform firePoint;
    [SerializeField] float fireSpeed;

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation);
        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.velocity = bullet.transform.forward * fireSpeed;
    }
}
