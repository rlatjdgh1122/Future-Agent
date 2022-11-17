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

    #region ü���� �������ִ� �޼���
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
            //���� ���ϸ��̼� 
            ShakeCamera.Instance.Shake(3, 0.2f);
        }
        else if (Hp <= 0)
        {
            //���� �ִϸ��̼�
            //������ ����
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
            //���� ���ϸ��̼� 
            //�и�
            ShakeCamera.Instance.Shake(3, 0.2f);

            Debug.Log("������ ����");
        }
        else if (Hp <= 0)
        {
            //���� �ִϸ��̼�
            //������ ����
            Debug.Log("����");
        }
        return Hp;
    }

    #endregion

    #region ü�� ���� �޼��忡�� ȣ��Ǵ� �޼���
    public void OnDieDestory()
    {
        Destroy(gameObject);
    }
    #endregion
    void Lamda(Action action) //���� �޼���
    {
        action();
    }
}
