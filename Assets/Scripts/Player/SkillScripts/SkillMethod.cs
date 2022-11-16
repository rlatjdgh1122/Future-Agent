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
    #region 호출할 스킬 메서드
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
    public void Skill1()//참격을 날림
    {
        PlayerController.anim.SetTrigger("Slash");
    }
    public void Skill2() //강력한 heavyAttack을 사용함
    {
        StartCoroutine("Heavy_Attack");
    }
    public void Skill3() //대쉬 쿨타임이 사라짐 
    {
        StartCoroutine("CancelDashCoolTime");
    }
    public void Skill4() //근처 적을 죽이는 물체를 날림
    {
        GameObject a = Instantiate(ball, transform.position, Quaternion.identity);
    }
    public void Skill5() //모든 공격력이 상승됨 몸이 빨개짐
    {
        Debug.Log("5");
    }
    public void Skill6() //체력을 풀피로 채워줌
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
    #region 코루틴
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
