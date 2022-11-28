using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillMethod : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] GameObject particle;

    [SerializeField] GameObject slash;
    [SerializeField] GameObject ball;
    [SerializeField] Transform SlashRotation;
    [SerializeField] Transform Pos;
    Vector3 dir;


    [Header("��ȭ�� ����")]
    [SerializeField] AttackSlash attackSlash;
    [SerializeField] SkillBall skillBall;
    [SerializeField] PlayerHeavyAttackArea playerHeavyAttackArea;
    [SerializeField] stat Setstat;
    public float PlusDamage;

    public bool isUpDamage;
    [Header("���� �ð�")]
    public float Slash_CastTime = 10;
    public float AttackUp_CastTime = 5;
    public float Cancel_DashCoolTime = 3;

    Health health;
    #region ȣ���� ��ų �޼���

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        health = GetComponent<Health>();
    }
    private void Update()
    {
        dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - SlashRotation.position;
        float z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        SlashRotation.rotation = Quaternion.Euler(0, 0, z);
    }
    public void Skill1()//������ ����
    {
        SoundManager.Instace.EffectPlay(12, 0);
        PlayerController.anim.SetTrigger("Slash");
    }
    public void Skill2() //������ heavyAttack�� �����
    {
        StartCoroutine("Heavy_Attack");
    }
    public void Skill3() //�뽬 ��Ÿ���� ����� 
    {
        StartCoroutine("CancelDashCastTime");
    }
    public void Skill4() //��ó ���� ���̴� ���� ����
    {
        GameObject a = Instantiate(ball, transform.position, Quaternion.identity);
        SoundManager.Instace.EffectPlay(1, 0);
    }
    public void Skill5() //��� ��ų ���ݷ� ����
    {
        particle.SetActive(true);
        StartCoroutine("AttackDamageUp");
        SoundManager.Instace.EffectPlay(11, 0);
    }
    public void Skill6() //ü���� Ǯ�Ƿ� ä����
    {
        SoundManager.Instace.EffectPlay(8, 0);
        health.playerHp = health.PlayerHpSlider.maxValue;
        health.PlayerHpSlider.value = health.PlayerHpSlider.maxValue;
    }
    #endregion
    public void Slash()
    {
        GameObject Slash = Instantiate(slash, Pos.position, SlashRotation.rotation);
        SlashDestory(Slash);
    }
    public void SlashDestory(GameObject a)
    {
        Destroy(a, 1);
    }

    public void DamageDown()
    {
        attackSlash.Damage -= PlusDamage;
        skillBall.Damage -= PlusDamage;
        Setstat.damage -= PlusDamage;
        playerHeavyAttackArea.HeavyAttackDamage -= PlusDamage;
    }
    #region �ڷ�ƾ
    IEnumerator Heavy_Attack()
    {
        playerController.SkillDash = true;
        yield return new WaitForSeconds(Cancel_DashCoolTime);
        playerController.SkillDash = false;
    }

    IEnumerator CancelDashCastTime()
    {
        playerController.Skil2_HeavyAttack = true;
        yield return new WaitForSeconds(Slash_CastTime);
        playerController.Skil2_HeavyAttack = false;
    }
    IEnumerator AttackDamageUp()
    {
       
        attackSlash.Damage += PlusDamage;
        skillBall.Damage += PlusDamage;
        playerHeavyAttackArea.HeavyAttackDamage += PlusDamage;
        Setstat.damage += PlusDamage;

        isUpDamage = true;
        yield return new WaitForSeconds(AttackUp_CastTime);

        particle.SetActive(false);

        attackSlash.Damage -= PlusDamage;
        skillBall.Damage -= PlusDamage;
        playerHeavyAttackArea.HeavyAttackDamage -= PlusDamage;
        Setstat.damage -= PlusDamage;

        isUpDamage = false;
    }
    #endregion
}
