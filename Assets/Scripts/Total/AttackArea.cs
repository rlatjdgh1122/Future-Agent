using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalName;

public class AttackArea : MonoBehaviour
{
    public stat Setstat;
    public float defaultDamage;
    [SerializeField] new Name name;
    public float EnemyDamage;
    Health health;
    #region 충돌 처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() != null && name == Name.Enemy)
        {
            health = collision.GetComponent<Health>();
            health.Damaged(EnemyDamage, health.PlyerHp);
        }

        if (collision.GetComponent<Health>() != null && name == Name.Player)
        {
            health = collision.GetComponent<Health>();
            health.Damaged(defaultDamage + Setstat.damage, health.EnemyHp);
        }
    }

    #endregion
}
