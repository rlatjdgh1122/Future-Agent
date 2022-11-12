using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillMethod : MonoBehaviour
{
    PlayerController playerController;
    [Header("CoolTime")]
    public float Slash_CastTime = 10;
    #region ȣ���� ��ų �޼���
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    public void Skill1()//������ ����
    {

        PlayerController.anim.SetTrigger("Slash");
    }
    public void Skill2() //������ heavyAttack�� �����
    {
        StartCoroutine("Heavy_Attack");
    }
    public void Skill3() //�뽬 ��Ÿ���� ����� 
    {
        Debug.Log("3");
    }
    public void Skill4() //��ó ���� ���̴� ��ü�� ����
    {
        Debug.Log("4");
    }
    public void Skill5() //��� ���ݷ��� ��µ� ���� ������
    {
        Debug.Log("5");
    }
    public void Skill6() //ü���� Ǯ�Ƿ� ä����
    {
        Debug.Log("6");
    }
    #endregion
    #region �ڷ�ƾ
    IEnumerator Heavy_Attack()
    {
        playerController.Skil2_HeavyAttack = true;
        yield return new WaitForSeconds(Slash_CastTime);
        playerController.Skil2_HeavyAttack = false;
    }
    #endregion
}
