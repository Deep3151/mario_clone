using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public float killPlayer = 3;

    void Awake()
    {
        Destroy(gameObject, killPlayer);
        Physics.IgnoreLayerCollision(gameObject.layer, 9);
        Physics.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

}
