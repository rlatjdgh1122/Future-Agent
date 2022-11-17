using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalName;
using System;

public delegate float Hit(float damaged);
public class Health : MonoBehaviour
{
    [SerializeField] new Name name;
    public float Hp;

    Hit Hit;

    #region 체력을 관리해주는 메서드
    public void Damaged(float damaged, Hit hit)
    {
        hit(damaged);
    }
    public float EnemyHp(float damaged)
    {
        if (name == Name.Player)
            damaged = 0; //
        Hp -= damaged;
        if (Hp > 0)
        {
            //맞음 에니메이션 
            ShakeCamera.Instance.Shake(3, 0.2f);
        }
        else if (Hp <= 0)
        {
            //죽음 애니메이션
            //움직임 멈춤
        }
        return Hp;
    }
    public float PlyerHp(float damaged)
    {
        if (name == Name.Enemy)
            damaged = 0; //
        Hp -= damaged;
        if (Hp > 0)
        {
            //맞음 에니메이션 
            //밀림
            ShakeCamera.Instance.Shake(3, 0.2f);

            Debug.Log("데미지 입음");
        }
        else if (Hp <= 0)
        {
            //죽음 애니메이션
            //움직임 멈춤
            Debug.Log("죽음");
        }
        return Hp;
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
