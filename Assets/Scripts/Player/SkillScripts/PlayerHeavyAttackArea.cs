using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeavyAttackArea : MonoBehaviour
{
    public float HeavyAttackDamage;
    Health health;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() != null)
        {
            health = collision.GetComponent<Health>();
            health.Damaged(HeavyAttackDamage, health.EnemyHp);
        }
    }
}
