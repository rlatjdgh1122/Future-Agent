using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Enemy;

public class BossZombie : MonoBehaviour, IEnemyInterface
{
    public float moveSpeed;

    public float AttackDelay = 3;
    public float effectiveRange;

    public Transform boxpos;
    public Vector2 boxSize;
    public LayerMask layer;

    [SerializeField]
    Collider2D[] collider2Ds;
    Animator anim;
    Transform player;

    public GameObject attack1;
    public GameObject attack2;
    bool isMove;
    void Start()
    {
        isMove = true;
        StartCoroutine(AttackPos());

        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Move();
    }
    public void Move()
    {
        float distance = Vector2.Distance(new Vector2(player.position.x, 0), new Vector2(transform.position.x, 0));
        if (isMove && distance > effectiveRange)
            transform.Translate(new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime);

        if (player.transform.position.x < transform.position.x && isMove)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (player.transform.position.x > transform.position.x && isMove)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    public IEnumerator AttackPos()
    {
        while (true)
        {
            collider2Ds = Physics2D.OverlapBoxAll(boxpos.position, boxSize, 0, layer);
            //Physics2D.OverlapBox()
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.tag == "Player")
                {
                    isMove = false;
                    int randomAttack = Random.Range(0, 2);

                    if (randomAttack == 0)
                        anim.SetTrigger("Attack1");

                    else anim.SetTrigger("Attack2");

                    yield return new WaitForSeconds(AttackDelay);
                    isMove = true;
                }
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
    public void Start_Attack1()
    {
        attack1.SetActive(true);
    }
    public void Start_Attack2()
    {
        attack2.SetActive(true);
    }
    public void End_Attack1()
    {
        attack1.SetActive(false);
    }
    public void End_Attack2()
    {
        attack2.SetActive(false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxpos.position, boxSize);
    }

}
