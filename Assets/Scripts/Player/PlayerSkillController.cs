using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerSkillController : MonoBehaviour
{
    public UnityEvent[] unityAction = new UnityEvent[4];
    public Image[] blind = new Image[4];

    [Header("스킬 쿨타임 세팅")]
    public List<SettingCoolTime> SettingCoolTimes = new List<SettingCoolTime>();
    [Header("스킬 쿨타임 확인")]
    public List<CoolTime> coolTimes = new List<CoolTime>();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && coolTimes[0].Skill_Can)
        {
            unityAction[0]?.Invoke();
            coolTimes[0].Skill_Can = false;

            blind[0].fillAmount = 1;
            StartCoroutine("blind1");
        }

        if (Input.GetKeyDown(KeyCode.W) && coolTimes[1].Skill_Can)
        {
            unityAction[1]?.Invoke();
            coolTimes[1].Skill_Can = false;

            blind[1].fillAmount = 1;
            StartCoroutine("blind2");
        }

        if (Input.GetKeyDown(KeyCode.E) && coolTimes[2].Skill_Can)
        {
            unityAction[2]?.Invoke();
            coolTimes[2].Skill_Can = false;

            blind[2].fillAmount = 1;
            StartCoroutine("blind3");
        }

        if (Input.GetKeyDown(KeyCode.R) && coolTimes[3].Skill_Can)
        {
            unityAction[3]?.Invoke();
            coolTimes[3].Skill_Can = false;

            blind[3].fillAmount = 1;
            StartCoroutine("blind4");
        }

       
        if (!coolTimes[0].Skill_Can)
        {
            coolTimes[0].Skill_Time += Time.deltaTime;
            if (coolTimes[0].Skill_CoolTime < coolTimes[0].Skill_Time)
            {
                coolTimes[0].Skill_Time = 0;
                coolTimes[0].Skill_Can = true;
            }
        }


        if (!coolTimes[1].Skill_Can)
        {
            coolTimes[1].Skill_Time += Time.deltaTime;
            if (coolTimes[1].Skill_CoolTime < coolTimes[1].Skill_Time)
            {
                coolTimes[1].Skill_Time = 0;
                coolTimes[1].Skill_Can = true;
            }
        }


        if (!coolTimes[2].Skill_Can)
        {
            coolTimes[2].Skill_Time += Time.deltaTime;
            if (coolTimes[2].Skill_CoolTime < coolTimes[2].Skill_Time)
            {
                coolTimes[2].Skill_Time = 0;
                coolTimes[2].Skill_Can = true;
            }
        }

        if (!coolTimes[3].Skill_Can)
        {
            coolTimes[3].Skill_Time += Time.deltaTime;
            if (coolTimes[3].Skill_CoolTime < coolTimes[3].Skill_Time)
            {
                coolTimes[3].Skill_Time = 0;
                coolTimes[3].Skill_Can = true;
            }
        }
    }

    private IEnumerator blind1()
    {
        while (blind[0].fillAmount > 0)
        {
            blind[0].fillAmount -= Time.smoothDeltaTime / coolTimes[0].Skill_CoolTime;
            yield return null;
        }
        yield break;
    }

    private IEnumerator blind2()
    {
        while (blind[1].fillAmount > 0)
        {
            blind[1].fillAmount -= Time.smoothDeltaTime / coolTimes[1].Skill_CoolTime;
            yield return null;
        }
        yield break;
    }
    private IEnumerator blind3()
    {
        while (blind[2].fillAmount > 0)
        {
            blind[2].fillAmount -= Time.smoothDeltaTime / coolTimes[2].Skill_CoolTime;
            yield return null;
        }
        yield break;
    }
    private IEnumerator blind4()
    {
        while (blind[3].fillAmount > 0)
        {
            blind[3].fillAmount -= Time.smoothDeltaTime / coolTimes[3].Skill_CoolTime;
            yield return null;
        }
        yield break;
    }
}
