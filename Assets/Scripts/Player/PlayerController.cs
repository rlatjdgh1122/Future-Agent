using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerStat movement;
    public static Animator anim;

    private bool IsDash;
    private bool below;
    [SerializeField] private LayerMask layer;

    TrailRenderer trailRenderer;
    [SerializeField] private EdgeCollider2D dashCollider;
    [SerializeField] private ShakeCamera SettingCamera;

    [Header("Skill")]
    public bool Skil2_HeavyAttack = false;
    private void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
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
        Dash();
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
        RaycastHit2D belowHit = Physics2D.Raycast(transform.position, Vector2.down, 2, layer);
        if (belowHit.collider) below = true; else below = false;


        if (Input.GetKeyDown(KeyCode.Space) && below)
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

    public void Dash()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine("co_Dash");
        }

        if (IsDash)
        {
            movement.defaultSpeed = movement.DashSpeed;
        }
        else
            movement.defaultSpeed = movement.Speed;

    }
    public void Attack()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (Skil2_HeavyAttack)
            {
                anim.SetTrigger("HeavyAttack");
            }
            else
                anim.SetTrigger("Attack");
        }
    }
    public void ZoomTrue()
    {
        SettingCamera.ZoomActive = true;
    }
    public void ZoomFalse()
    {
        SettingCamera.ZoomActive = false;
    }
    #region ÄÚ·çÆ¾
    IEnumerator co_Dash()
    {
        IsDash = true;
        trailRenderer.enabled = true;

        dashCollider.enabled = true;
        yield return new WaitForSeconds(0.1f);

        IsDash = false;
        trailRenderer.enabled = false;

        dashCollider.enabled = false;
    }
    #endregion
}
