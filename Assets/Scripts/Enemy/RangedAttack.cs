using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public float Damage = 10;
    public float Speed = 10;

    Vector2 dir;
    Health health;
    private void Start()
    {
        float a = GameObject.Find("Ranged Zombie").transform.localScale.x;
        if (a == 1) { transform.localScale = new Vector3(1, 1, 1); dir = Vector3.right; }
        if (a == -1) { transform.localScale = new Vector3(-1, 1, 1); dir = Vector3.left; }

    }
    void Update()
    {
        transform.Translate(dir * Speed * Time.deltaTime);
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
