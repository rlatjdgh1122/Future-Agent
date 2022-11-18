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
    [Header("�÷��̾��� ��")]
    public float playerHp = 0;
    [Header("���� ��")]
    public float enemyHp = 0;
    Hit Hit;

    private void Awake()
    {
        Instance = this;

    }
    #region ü���� �������ִ� �޼���
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
            //���� ���ϸ��̼� 
            ShakeCamera.Instance.Shake(3, 0.2f);
            Debug.Log("������ ����");
        }
        else if (enemyHp <= 0)
        {
            //���� �ִϸ��̼�
            //������ ����
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
            //���� ���ϸ��̼� 
            //�и�
            ShakeCamera.Instance.Shake(3, 0.2f);
            Debug.Log("������ ����");
        }
        else if (playerHp <= 0)
        {
            //���� �ִϸ��̼�
            //������ ����
            ShakeCamera.Instance.Shake(3, 0.2f);
            Debug.Log("����");
        }
        return playerHp;
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
