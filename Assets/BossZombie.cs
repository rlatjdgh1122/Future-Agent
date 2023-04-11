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
    [SerializeField] private GameObject player;

    public GameObject attack1;
    public GameObject attack2;
    bool isMove;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Attack();
    }
    public void Attack()
    {
        isMove = true;
        StartCoroutine(AttackPos());

        // Vector3 dir = player.transform.position - transform.position;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Move();
    }
    public void Move()
    {
        float distance = Vector2.Distance(new Vector2(player.transform.position.x, 0), new Vector2(transform.position.x, 0));
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
        SoundManager.Instace.EffectPlay(9, 0);

        ShakeCamera.Instance.Shake(15, 0.2f);
        attack1.SetActive(true);
    }
    public void End_Attack1()
    {
        attack1.SetActive(false);
    }
    public void Start_DownAttack()
    {
        SoundManager.Instace.EffectPlay(10, 0);
        ShakeCamera.Instance.Shake(30, 0.2f);
        attack2.SetActive(true);
    }
    public void End_DownAttack()
    {
        attack2.SetActive(false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxpos.position, boxSize);
    }

}
