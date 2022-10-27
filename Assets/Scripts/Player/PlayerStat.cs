using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [Header("Stat")]
    public int Speed; //¸¸·¦ ½Ã ´õ »¡¶óÁü
    public float Hp; // ¸¸·¦ ½Ã Ã¼·ÂÀ» Ã¤¿öÁÜ
    public float damage; // ¸¸·¦½Ã 

    private float jumpForce = 8;
    private Rigidbody2D rb;
    [HideInInspector]
    public bool isLongJump = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (isLongJump && rb.velocity.y > 0)
        {
            rb.gravityScale = 1;
        }
        else
            rb.gravityScale = 2.5f;
    }
    public void Move(float x)
    {
        rb.velocity = new Vector2(x * Speed, rb.velocity.y);
    }
    public void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
}
