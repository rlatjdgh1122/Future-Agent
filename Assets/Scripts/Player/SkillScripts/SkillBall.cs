using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBall : MonoBehaviour
{
    public GameObject[] FoundObjects;
    public GameObject enemy;

    public string TagName;
    public float shortDis;
    public float speed;
    public float Damage;


    Vector3 dir;

    Collider2D[] colliders;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private Transform boxPos;
    [SerializeField] private LayerMask layer;

    Health health;


    private void Awake()
    {
        boxPos = GameObject.Find("BallPos").transform;
        Check();
    }
    private void Update()
    {
        KillMove();
    }
    public void Check()
    {
        colliders = Physics2D.OverlapBoxAll(boxPos.position, boxSize, 0, layer);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
                collider.gameObject.tag = TagName;
        }
        EnemyKill();
    }
    public void EnemyKill()
    {
        enemy = GameObject.FindGameObjectWithTag(TagName);
    }
    public void KillMove()
    {
        dir = transform.position - enemy.transform.position;

        if (FoundObjects != null)
            transform.position -= dir * speed * Time.deltaTime;
    }
    public void Enemy()
    {
        FoundObjects = GameObject.FindGameObjectsWithTag(TagName);
        shortDis = Vector3.Distance(gameObject.transform.position, enemy/*FoundObjects[0]*/.transform.position); // 첫번째를 기준으로 잡아주기 

        try
        {
            enemy = FoundObjects[0]; // 첫번째를 먼저 
        }
        catch
        {
            Destroy(gameObject);
        }

        foreach (GameObject found in FoundObjects)
        {
            float Distance = Vector3.Distance(gameObject.transform.position, found.transform.position);
            if (Distance < shortDis) // 위에서 잡은 기준으로 거리 재기
            {
                enemy = found;
                shortDis = Distance;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagName) && collision.GetComponent<Health>() != null)
        {
            health = collision.GetComponent<Health>();
            health.Damaged(Damage, health.EnemyHp);

            collision.tag = "Enemy";
            Enemy();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxPos.position, boxSize);
    }
}
