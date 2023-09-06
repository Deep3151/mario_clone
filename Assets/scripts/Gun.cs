using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 50;
    float fireRate;

    public enum FireMode { Semi, Brust, Auto }

    [SerializeField] private FireMode fireMode = FireMode.Semi;

    [SerializeField] private KeyCode cycleFireModeKey = KeyCode.B;

    private bool ShootInput = false;

    private bool BurstFiring = false;

    private float FireTimer = .35f;

    void Update()
    {
        if (Time.time - fireRate < FireTimer) return;

        if (ShootInput)
        {
            Shoot();

            if (fireMode == FireMode.Brust)
            {
               BurstFiring = true;
               StartCoroutine(BrustFire());
            }

        }


        switch (fireMode)
        {
            case FireMode.Auto:
                ShootInput = Input.GetMouseButton(0);
                break;

            default:
                ShootInput = Input.GetMouseButtonDown(0);
                break;
        }

        if (Input.GetKeyDown(cycleFireModeKey))
        {
            CycelFireMode();
        }


    }

    void CycelFireMode()
    {
        if ((int)fireMode < 2)
        {
            fireMode += 1;
        }

        else
        {
            fireMode = 0;
        }
    }


    public void Shoot()
    {
        fireRate = Time.time;
        var bullet = Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bulletPoint.forward * bulletSpeed, ForceMode.VelocityChange);
    }

    private IEnumerator BrustFire()
    {

        yield return new WaitForSeconds(fireRate);
        Shoot();

        yield return new WaitForSeconds(fireRate);
        Shoot();

        yield return new WaitForSeconds(fireRate);
        Shoot();

        yield return new WaitForSeconds(fireRate);
        BurstFiring = false;
    }

}


