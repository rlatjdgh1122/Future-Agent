using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillMethod : MonoBehaviour
{
    PlayerController playerController;


    [SerializeField] GameObject slash;
    [SerializeField] GameObject ball;
    [SerializeField] Transform SlashRotation; 
    [SerializeField] Transform Pos;
    Vector3 dir;

    [Header("CoolTime")]
    public float Slash_CastTime = 10;
    public float Cancel_DashCoolTime = 3;
    #region ȣ���� ��ų �޼���
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    private void Update()
    {
        dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - SlashRotation.position;
        float z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        SlashRotation.rotation = Quaternion.Euler(0, 0, z);
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
        StartCoroutine("CancelDashCoolTime");
    }
    public void Skill4() //��ó ���� ���̴� ��ü�� ����
    {
        GameObject a = Instantiate(ball, transform.position, Quaternion.identity);
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
    public void Slash()
    {
        GameObject Slash = Instantiate(slash,Pos.position,SlashRotation.rotation);
        SlashDestory(Slash);
    }
    public void SlashDestory(GameObject a)
    {
        Destroy(a, 1);
    }
    #region �ڷ�ƾ
    IEnumerator Heavy_Attack()
    {
        playerController.SkillDash = true;
        yield return new WaitForSeconds(Cancel_DashCoolTime);
        playerController.SkillDash = false;
    }

    IEnumerator CancelDashCoolTime()
    {
        playerController.Skil2_HeavyAttack = true;
        yield return new WaitForSeconds(Slash_CastTime);
        playerController.Skil2_HeavyAttack = false;
    }
    #endregion
}
