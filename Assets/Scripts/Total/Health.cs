using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalName;
using System;
using UnityEngine.UI;

public delegate float Hit(float damaged);
public class Health : MonoBehaviour
{
    public static Health Instance;

    public Slider PlayerHpSlider;
    public GameObject hudDamageText;
    public Transform hudPos;

    public PlayerController playerController;
    ParticleSystem bloodParticle;
    SpriteRenderer sr;
    Animator anim;
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
        bloodParticle = GetComponent<ParticleSystem>();
        anim = GetComponent<Animator>();
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
        SoundManager.Instace.EffectPlay(3, 0);
        if (name == Name.Player)
            damaged = 0; //
        enemyHp -= damaged;
        if (enemyHp > 0)
        {
            GameObject enemyHudText = Instantiate(hudDamageText);
            enemyHudText.transform.position = hudPos.position;
            enemyHudText.GetComponent<DamageText>().damage = (int)damaged;
            //���� ���ϸ��̼� 
            ShakeCamera.Instance.Shake(3, 0.2f);
            bloodParticle.Play();
            StartCoroutine("alphablink");
        }
        else if (enemyHp <= 0)
        {
            //���� �ִϸ��̼�
            //������ ����
            SoundManager.Instace.EffectPlay(3, 0);
            ShakeCamera.Instance.Shake(3, 0.2f);

            GameManager.Instance.count++;
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
            GameObject playerHudText = Instantiate(hudDamageText);
            playerHudText.transform.position = hudPos.position;
            playerHudText.GetComponent<DamageText>().damage = (int)damaged;
            //���� ���ϸ��̼� 
            //�и�
            SoundManager.Instace.EffectPlay(3, 0);
            ShakeCamera.Instance.Shake(3, 0.2f);
            bloodParticle.Play();
            StartCoroutine("alphablink");
        }
        else if (playerHp <= 0)
        {
            //���� �ִϸ��̼�
            //������ ����
            Physics2D.IgnoreLayerCollision(7, 8, true);
            SoundManager.Instace.EffectPlay(3, 0);
            ShakeCamera.Instance.Shake(3, 0.2f);

            playerController.enabled = false;
            anim.SetTrigger("Die");
        }
        return playerHp;
    }

    public void PlayerDie()
    {
        ShakeCamera.Instance.ZoomActive = true;
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
}
