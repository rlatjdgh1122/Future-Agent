using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalName;

public class AttackArea : MonoBehaviour
{
    [SerializeField] new Name name;
    public float Damage;
    Health health;

    #region �浹 ó��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() != null && name == Name.Enemy)
        {
            health = collision.GetComponent<Health>();
            health.Damaged(Damage, health.PlyerHp);
        }

        if (collision.GetComponent<Health>() != null && name == Name.Player)
        {
            health = collision.GetComponent<Health>();
            health.Damaged(Damage, health.EnemyHp);

        }
    }
    
    #endregion
}
