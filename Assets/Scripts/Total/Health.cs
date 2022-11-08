using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalName;
using System;
using DG.Tweening;  

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
            //�и�
            Camera.main.DOShakePosition(0.1f,1f);
            Debug.Log("������ ����");
        }
        else if (Hp <= 0)
        {
            //���� �ִϸ��̼�
            //������ ����
            Debug.Log("����");
            Camera.main.DOShakePosition(0.1f,1f);
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
            Debug.Log("������ ����");
        }
        else if(Hp <= 0)
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
