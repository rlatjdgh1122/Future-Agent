using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Enemy;

public class Zombie : MonoBehaviour
{
    public float MinSpeed;
    public float MaxSpeed;
    public float moveSpeed;

    public float AttackDelay = 3;

    public Transform boxpos;
    public Vector2 boxSize;
    public LayerMask layer;

    [SerializeField]
    Collider2D[] collider2Ds;
    Animator anim;
    Transform player;
    Rigidbody2D rigid;

    bool isMove;

    void OnEnable()
    {
        isMove = true;
        StartCoroutine(AttackPos());

        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();

    }
    private void Start()
    {
        RandomSpeed();
    }
    public void RandomSpeed()
    {
        moveSpeed = Random.Range(MinSpeed, MaxSpeed);
    }
    void Update()
    {
        Move();
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.tag == "Player")
            {
                rigid.velocity = Vector2.zero;
            }
        }
    }
    public void Move()
    {
        //Vector2 direction = ;

        if (isMove)
            transform.Translate(rigid.velocity = new Vector3(player.position.x - transform.position.x, 0, 0) * moveSpeed * Time.deltaTime);
        //transform.Translate(new Vector2(player.position.x - transform.position.x, 0) * moveSpeed * Time.deltaTime);

        if (player.transform.position.x < transform.position.x && isMove)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (player.transform.position.x > transform.position.x && isMove)
        {
            transform.localScale = new Vector3(1, 1, 1);
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
                    anim.SetTrigger("Attack");
                    yield return new WaitForSeconds(AttackDelay);
                    isMove = true;

                }
            }
            yield return new WaitForSeconds(0.2f);
        }


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxpos.position, boxSize);
    }

}
