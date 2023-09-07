using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
        Physics.IgnoreLayerCollision(7, 8);
        Physics.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }



}
