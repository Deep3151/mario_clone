using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    [SerializeField] public int Health;
    [SerializeField] public int BulletAmount;

    public void TakeDamage(int DamageAmount)
    {
        Health -= DamageAmount;
    }

    public void Damage(GameObject target)
    {
        var amt = target.GetComponet<AttributesManager>();
        if (amt != null)
        {
            amt.TakeDamage(BulletAmount);
        }
    }
}
