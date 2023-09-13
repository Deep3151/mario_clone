using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public Transform bulletPoint;
    public float bulletSpeed = 50;
    public GameObject enemyBulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var bullet = Instantiate(enemyBulletPrefab, bulletPoint.position, bulletPoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bulletPoint.forward * bulletSpeed, ForceMode.VelocityChange);
    }
}
