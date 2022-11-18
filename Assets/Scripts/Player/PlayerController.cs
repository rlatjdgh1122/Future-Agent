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

    [SerializeField] private GameObject HeavyAttackArea;

    private bool HeavyAttackDelay = true;
    private float HeavyAttackDelayTime = 0;
    [Header("Skill")]
    public bool Skil2_HeavyAttack = false;
    public bool IsRotationStop = false;


    public float DefaultDashCoolTime = 3;
    public bool SkillDash = false;
    private bool IsCanDash = true;
    private float DashTime = 0;
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

        if (!IsCanDash)
        {
            if (!SkillDash)
            {
                DashTime += Time.deltaTime;
                if (DashTime > DefaultDashCoolTime)
                {
                    DashTime = 0;
                    IsCanDash = true;
                }
            }
            else IsCanDash = true;
        }

        if (!HeavyAttackDelay)
        {
            HeavyAttackDelayTime += Time.deltaTime;
            if(HeavyAttackDelayTime > 1.3f)
            {
                HeavyAttackDelayTime = 0;
                HeavyAttackDelay = true;
            }
        }
    }
    public void Move()
    {
        if (!IsRotationStop)
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
        if (Input.GetMouseButtonDown(1) && IsCanDash)
        {
            StartCoroutine("co_Dash");
            IsCanDash = false;
        }

        if (IsDash)
        {
            movement.defaultSpeed = StatManager.DashSpeedP;
        }
        else
            movement.defaultSpeed = StatManager.SpeedP;

    }
    public void Attack()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (Skil2_HeavyAttack)
            {
                if (HeavyAttackDelay)
                {
                    anim.SetTrigger("HeavyAttack");
                    HeavyAttackDelay = false;
                }
            }
            else
            {
                anim.SetTrigger("Attack");
            }
        }
    }
    #region HeavyAttack 이벤트 함수
    public void Start_HeavyAttack()
    {
        ShakeCamera.Instance.Shake(5, 0.4f);
        HeavyAttackArea.SetActive(true);
    }
    public void End_HeavyAttack()
    {
        HeavyAttackArea.SetActive(false);
    }
    public void ZoomTrue()
    {
        ShakeCamera.Instance.ZoomActive = true;
        movement.isStopMove = true;
        IsRotationStop = true;
    }
    public void ZoomFalse()
    {
        ShakeCamera.Instance.ZoomActive = false;
        movement.isStopMove = false;
        IsRotationStop = false;
    }
    #endregion 
    #region 코루틴
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
