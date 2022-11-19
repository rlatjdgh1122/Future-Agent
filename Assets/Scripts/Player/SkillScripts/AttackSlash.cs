using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalName;

public class AttackSlash : MonoBehaviour
{
    public float Damage = 3;
    public float Speed = 3;

    new Name name;
    Health health;

    private void Update()
    {
        if (transform.rotation.y == 0)
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        else
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() != null && name == Name.Enemy && collision.CompareTag("Enemy"))
        {
            health = collision.GetComponent<Health>();
            health.Damaged(Damage, health.EnemyHp);

        }
    }
}
