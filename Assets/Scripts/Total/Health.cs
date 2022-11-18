using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalName;
using System;

public delegate float Hit(float damaged);
public class Health : MonoBehaviour
{
    public static Health Instance;
    [SerializeField] new Name name;
    [Header("플레이어일 때")]
    public float playerHp = 0;
    [Header("적일 때")]
    public float enemyHp = 0;
    Hit Hit;

    private void Awake()
    {
        Instance = this;

    }
    #region 체력을 관리해주는 메서드
    public void Damaged(float damaged, Hit hit)
    {
        hit(damaged);
    }
    public float EnemyHp(float damaged)
    {
        if (name == Name.Player)
            damaged = 0; //
        enemyHp -= damaged;
        if (enemyHp > 0)
        {
            //맞음 에니메이션 
            ShakeCamera.Instance.Shake(3, 0.2f);
            Debug.Log("데미지 입음");
        }
        else if (enemyHp <= 0)
        {
            //죽음 애니메이션
            //움직임 멈춤
            ShakeCamera.Instance.Shake(3, 0.2f);
        }
        return enemyHp;
    }
    public float PlyerHp(float damaged)
    {
        if (name == Name.Enemy)
            damaged = 0; //
        playerHp -= damaged;
        if (playerHp > 0)
        {
            //맞음 에니메이션 
            //밀림
            ShakeCamera.Instance.Shake(3, 0.2f);
            Debug.Log("데미지 입음");
        }
        else if (playerHp <= 0)
        {
            //죽음 애니메이션
            //움직임 멈춤
            ShakeCamera.Instance.Shake(3, 0.2f);
            Debug.Log("죽음");
        }
        return playerHp;
    }

    #endregion

    #region 체력 관리 메서드에서 호출되는 메서드
    public void OnDieDestory()
    {
        Destroy(gameObject);
    }
    #endregion
    void Lamda(Action action) //람다 메서드
    {
        action();
    }
}
