using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalName;
using System;
using UnityEngine.UI;

public delegate float Hit(float damaged);
public class Health : MonoBehaviour
{
    public Slider PlayerHpSlider;
    public static Health Instance;

    SpriteRenderer sr;
    Color halfA = Color.red;
    Color fullA = new Color(1, 1, 1, 1);

    [SerializeField] new Name name;
    [Header("�÷��̾��� ��")]
    public float playerHp = 0;
    [Header("���� ��")]
    public float enemyHp = 0;
    Hit Hit;

    private void Start()
    {
        Instance = this;
        sr = GetComponent<SpriteRenderer>();
        SliderHpSetting();
    }
    public void SliderHpSetting()
    {
        if (name == Name.Player)
        {
            PlayerHpSlider.maxValue = playerHp;
            PlayerHpSlider.value = playerHp;
        }
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
            StartCoroutine("alphablink");
            Debug.Log("������ ����");
        }
        else if (enemyHp <= 0)
        {
            //���� �ִϸ��̼�
            //������ ����
            ShakeCamera.Instance.Shake(3, 0.2f);
            Destroy(gameObject);
        }
        return enemyHp;
    }
    public float PlyerHp(float damaged)
    {
        if (name == Name.Enemy)
            damaged = 0; //
        playerHp -= damaged;
        PlayerHpSlider.value = playerHp;
        if (playerHp > 0)
        {
            //���� ���ϸ��̼� 
            //�и�
            ShakeCamera.Instance.Shake(3, 0.2f);
            StartCoroutine("alphablink");
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
    private IEnumerator alphablink() //������ ���� ����
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            sr.color = halfA;
            yield return new WaitForSeconds(0.1f);
            sr.color = fullA;
            StopCoroutine("alphablink");

        }
    }
    void Lamda(Action action) //���� �޼���
    {
        action();
    }
}
