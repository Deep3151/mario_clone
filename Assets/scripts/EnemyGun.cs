using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public Transform bulletPoint;
    public float bulletSpeed = 50;
    public GameObject enemyBulletPrefab;
    public Transform targetObj;
    [SerializeField] GameObject player;
    [SerializeField] float chasingDistence = 0.5f;
    [SerializeField] private float Firerate = 50f;
    [SerializeField] private float NextFire = 0.0f;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (getDistence() <= chasingDistence)
        {

            if( Time.time > NextFire)
            {
                NextFire = Time.time + Firerate;
                var bullet = Instantiate(enemyBulletPrefab, bulletPoint.position, bulletPoint.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(bulletPoint.forward * bulletSpeed, ForceMode.VelocityChange);
            }



        }
    }

    float getDistence()
    {
        return Vector3.Distance(player.transform.position, transform.position);
    }
}



