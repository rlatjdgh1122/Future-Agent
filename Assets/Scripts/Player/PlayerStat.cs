using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class PlayerStat : MonoBehaviour
{
    [Header("Stat")]
    public float Speed;
    public float DashSpeed;
    [SerializeField] public float defaultSpeed;


    public float Hp;
    public float DashDamage;

    private float jumpForce = 8;
    public Rigidbody2D rb;
    [HideInInspector]
    public bool isLongJump = false;

    [Header("Dash")]
    [SerializeField] private EdgeCollider2D edgeCollider;
    TrailRenderer trailRenderer;

    private void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();

    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {

        if (isLongJump && rb.velocity.y > 0)
        {
            rb.gravityScale = 1;
            edgeCollider.offset = new Vector2(0, 0.5f);
        }
        else if(rb.velocity.y == 0)
        {
            edgeCollider.offset = new Vector2(0, 0);
        }
        else
        {
            rb.gravityScale = 2.5f;
            edgeCollider.offset = new Vector2(0, 1.5f);
        }


        SetColliderPointsFromTrail(trailRenderer, edgeCollider);
    }
    public void Move(float x)
    {
        rb.velocity = new Vector2(x * defaultSpeed, rb.velocity.y);
    }
    public void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
    private void SetColliderPointsFromTrail(TrailRenderer trailRenderer, EdgeCollider2D edgeCollider)
    {
        List<Vector2> points = new List<Vector2>();
        for (int position = 0; position < trailRenderer.positionCount; position++)
        {
            points.Add(trailRenderer.GetPosition(position));
        }
        edgeCollider.SetPoints(points);
    }
}
