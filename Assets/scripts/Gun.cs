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

    [SerializeField] private float FireTimer = .35f;

    private Coroutine m_routine = null;

    void Update()
    {
        if (Input.GetKeyDown(cycleFireModeKey))
        {
            CycelFireMode();
        }
        switch (fireMode)
        {
            case FireMode.Auto:
                ShootInput = Input.GetMouseButton(0);
                break;

            case FireMode.Semi:
            case FireMode.Brust:
                ShootInput = Input.GetMouseButton(0);
                break;
        }
        if (ShootInput && fireMode == FireMode.Semi || ShootInput && fireMode == FireMode.Auto)
        {
            if (Time.time - fireRate < FireTimer) return;
            Shoot();
        }
        else if (ShootInput && fireMode == FireMode.Brust)
        {
            if (Time.time - fireRate < FireTimer) return;
            if (m_routine == null)
                m_routine = StartCoroutine(BrustFire());
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
        ShootInput = false;
    }

    private IEnumerator BrustFire()
    {
        fireRate = Time.time;
        Shoot();

        yield return new WaitForEndOfFrame();
        Shoot();

        yield return new WaitForEndOfFrame();
        Shoot();

        yield return new WaitForEndOfFrame();
        BurstFiring = false;
        ShootInput = false;
        m_routine = null;
    }

}


