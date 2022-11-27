using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public stat Setstat;
    public float defaultSpeed = 5;
    public float defaultDashSpeed = 20;

    [SerializeField] private Slider slider;
    public float DefaultDashCoolTime = 3;
    private PlayerStat movement;
    public static Animator anim;

    private bool IsDash;
    private bool below;
    [SerializeField] private LayerMask layer;

    TrailRenderer trailRenderer;
    [SerializeField] private EdgeCollider2D dashCollider;
    [SerializeField] private GameObject HeavyAttackArea;

    [SerializeField] private Transform DashPos;
    [SerializeField] private Vector2 DashSize;

    [SerializeField] private Collider2D[] collider2Ds;
    private bool HeavyAttackDelay = true;
    private float HeavyAttackDelayTime = 0;

    Rigidbody2D rigid;
    [Header("Skill")]
    public bool Skil2_HeavyAttack = false;
    public bool IsRotationStop = false;


    public bool SkillDash = false;
    private bool IsCanDash = true;

    private float DashTime = 0;

    public float _slopeAngle { get; private set; }

    private void Start()
    {
        slider.maxValue = DefaultDashCoolTime;

        trailRenderer = GetComponent<TrailRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine("ee");
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

        RaycastHit2D belowHit = Physics2D.Raycast(transform.position, Vector2.down, 2, layer);
        if (belowHit.collider) below = true; else below = false;

        /*  RaycastHit2D leftHit = Physics2D.Raycast(transform.position, Vector2.left, 1, layer);
          if (leftHit.collider) IsCanDash = false;

          RaycastHit2D rightHit = Physics2D.Raycast(transform.position, Vector2.right, 1, layer);
          if (rightHit.collider) IsCanDash = false;*/



        if (!IsCanDash)
        {
            if (!SkillDash)
            {
                slider.value = 0;

                DashTime += Time.deltaTime;
                slider.value = DashTime;

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
            if (HeavyAttackDelayTime > 1.3f)
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
            if (x == 0)
            {
                rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
            else rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
            //x = -Mathf.Abs(Mathf.Tan(_slopeAngle * Mathf.Deg2Rad) * x);

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
        if (Input.GetKeyDown(KeyCode.Space) && below)
        {
            movement.Jump();
        }
    }

    public void Dash()
    {
        if (Input.GetMouseButtonDown(1) && IsCanDash)
        {
            SoundManager.Instace.EffectPlay(4, 0);
            StartCoroutine("co_Dash");
            IsCanDash = false;
        }

        if (IsDash)
        {
            movement.defaultSpeed = defaultDashSpeed + Setstat.Dashspeed;
            Physics2D.IgnoreLayerCollision(7, 8, true);
        }
        else
        {
            movement.defaultSpeed = defaultSpeed + Setstat.speed;

            Physics2D.IgnoreLayerCollision(7, 8, false);
        }

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
                    SoundManager.Instace.EffectPlay(2, 0);
                }
            }
            else
            {
                anim.SetTrigger("Attack");
            }
        }
    }
    public void AttackSound()
    {
        SoundManager.Instace.EffectPlay(0, 0);
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

    IEnumerator ee()
    {
        while (true)
        {
            collider2Ds = Physics2D.OverlapBoxAll(DashPos.position, DashSize, 0, layer);
            //Physics2D.OverlapBox()
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.tag == "Walk")
                {
                    IsCanDash = false;
                }
            }
            yield return new WaitForSeconds(0.00001f);
        }
    }
    #endregion
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(DashPos.position, DashSize);
    }
}

