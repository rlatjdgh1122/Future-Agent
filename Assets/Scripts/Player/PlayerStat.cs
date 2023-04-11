using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class PlayerStat : MonoBehaviour
{
    public float jumpForce = 8;
    [Header("Stat")]
    [SerializeField] public float defaultSpeed;

    public bool isStopMove = false;

    public float DashDamage;

    private Rigidbody2D rb;

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
/*
        if (rb.velocity.y > 0)
        {
            rb.gravityScale = 1;
            edgeCollider.offset = new Vector2(0, 0.5f);
        }
        else if (rb.velocity.y == 0)
        {
            edgeCollider.offset = new Vector2(0, 0);
        }
        //else { rb.gravityScale = 2; }*/



        SetColliderPointsFromTrail(trailRenderer, edgeCollider);
    }
    public void Move(float x)
    {
        if (!isStopMove)
            rb.velocity = new Vector2(x * defaultSpeed, rb.velocity.y);
        else { rb.velocity = new Vector2(0, 0); }
    }
    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
