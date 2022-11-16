using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBall : MonoBehaviour
{
    public GameObject[] FoundObjects;
    public GameObject enemy;

    public float Damage = 10;
    public float speed;
    public string TagName;
    public float shortDis;

    Health health;
    Vector3 dir;

    public Collider2D[] colliders;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private Transform boxPos;
    [SerializeField] private LayerMask layer;

    GameObject Targets;
    private void Awake()
    {
        boxPos = GameObject.Find("BallPos").transform;
        Check();

    }
    private void OnDisable()
    {
        Targets = GameObject.Find("GameObject");
        if (Targets.transform.childCount != 0) 
        {
            for(int i = 0; i < Targets.transform.childCount; i++)
            {
                
                Targets.transform.GetChild(i).gameObject.SetActive(true);
                Targets.transform.GetChild(i).gameObject.tag = "Enemy";
            }
        }
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
            else Destroy(gameObject);
        }
        EnemyKill();
    }
    public void EnemyKill()
    {
        enemy = GameObject.FindGameObjectWithTag(TagName);
    }
    public void KillMove()
    {

        if (enemy != null)
        {
            dir = transform.position - enemy.transform.position;
            transform.position -= dir * speed * Time.deltaTime;
        }
        else { Destroy(gameObject); Debug.Log("적이 없습니다"); }

    }
    public void Enemy()
    {
        FoundObjects = GameObject.FindGameObjectsWithTag(TagName);
        shortDis = Vector3.Distance(gameObject.transform.position, enemy/*FoundObjects[0]*/.transform.position); // 첫번째를 기준으로 잡아주기 
        foreach (GameObject found in FoundObjects)
        {
            float Distance = Vector3.Distance(gameObject.transform.position, found.transform.position);
            if (Distance < shortDis) // 위에서 잡은 기준으로 거리 재기
            {
                enemy = found;
                shortDis = Distance;
            }
        }

        try
        {
            enemy = FoundObjects[0]; // 첫번째를 먼저
            if (enemy == null) Destroy(gameObject);
        }
        catch { Destroy(gameObject); }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagName))
        {
            health = collision.GetComponent<Health>();
            health.Damaged(Damage, health.EnemyHp);
            collision.gameObject.SetActive(false);
            Enemy();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxPos.position, boxSize);
    }
}
