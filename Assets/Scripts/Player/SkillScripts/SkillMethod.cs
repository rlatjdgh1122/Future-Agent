using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillMethod : MonoBehaviour
{

    PlayerController playerController;
    #region ȣ���� ��ų �޼���
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    public void Skill1() //�⺻ ������ �������� �ٲ�
    {
        StartCoroutine("Slash");
      
    }
    public void Skill2()
    {
        Debug.Log("2");
    }
    public void Skill3()
    {
        Debug.Log("3");
    }
    public void Skill4()
    {
        Debug.Log("4");
    }
    public void Skill5()
    {
        Debug.Log("5");
    }
    public void Skill6()
    {
        Debug.Log("6");
    }
    #endregion
    #region �ڷ�ƾ
    IEnumerator Slash()
    {
        playerController.Skill_SlashAttack = true;
        yield return new WaitForSeconds(5);
        playerController.Skill_SlashAttack = false;
    }
    #endregion
}
