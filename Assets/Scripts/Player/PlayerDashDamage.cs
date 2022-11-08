using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalName;

public class PlayerDashDamage : MonoBehaviour
{
    //[SerializeField] new Name name;
    public float DashDamage;
    Health health;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() != null)
        {
            health = collision.GetComponent<Health>();
            health.Damaged(DashDamage, health.EnemyHp);

        }
    }
}
