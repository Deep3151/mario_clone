using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
        Physics.IgnoreLayerCollision(gameObject.layer, 7);
        Physics.IgnoreLayerCollision(gameObject.layer, 8);
        Physics.IgnoreLayerCollision(gameObject.layer, 6);
        Physics.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }



}
