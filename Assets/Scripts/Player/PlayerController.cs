using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerStat movement;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Awake()
    {
        movement = GetComponent<PlayerStat>();
    }
    private void Update()
    {
        Move();
        Jump();
        Attack();
    }
    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        movement.Move(x);
        if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("Run", true);
        }

        else if (x < 0)
        {
            anim.SetBool("Run", true);
            transform.localScale = new Vector3(-1, 1, 1);

        }

        else
            anim.SetBool("Run", false);
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.Jump();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            movement.isLongJump = true;
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            movement.isLongJump = false;
        }
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            anim.SetTrigger("Attack");
        }
    }
}
