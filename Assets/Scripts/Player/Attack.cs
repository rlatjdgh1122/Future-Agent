using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Name
{
    Enemy,Player
}
public class Attack : MonoBehaviour
{
    [SerializeField] new Name name;
    public float Damage;

    Health health;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() != null && name == Name.Enemy)
        {
            health = collision.GetComponent<Health>();
            health.Damaged(Damage, health.EnemyHp);
        }

        if (collision.GetComponent<Health>() != null && name == Name.Player)
        {
            health = collision.GetComponent<Health>();
            health.Damaged(Damage, health.EnemyHp);

        }
    }
}
