using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatAttack : MonoBehaviour
{
    public float Damage = 10;
    public float speed = 10;
    Health health;

    Rigidbody2D rigid;

    private void Start()
    {

        float a = transform.parent.eulerAngles.y;
        if (a == 0) { transform.rotation = Quaternion.Euler(0,0,20); }
        if (a == 180) { transform.rotation = Quaternion.Euler(0, 0, -200); }

        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = transform.right * speed;

    }
    void Update()
    {
        transform.right = rigid.velocity;
        Destroy(gameObject, 2);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() != null && collision.CompareTag("Player"))
        {
            health = collision.GetComponent<Health>();
            health.Damaged(Damage, health.PlyerHp);

            Destroy(gameObject);
        }
    }
}
