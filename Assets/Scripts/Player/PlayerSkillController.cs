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

    [Header("스킬 쿨타임 확인")]
    public float Skill1_CoolTime;
    private bool Skill1_Can = true;
    private float Skill1_Time = 0;

    public float Skill2_CoolTime;
    private bool Skill2_Can = true;
    private float Skill2_Time = 0;

    public float Skill3_CoolTime;
    private bool Skill3_Can = true;
    private float Skill3_Time = 0;

    public float Skill4_CoolTime;
    private bool Skill4_Can = true;
    private float Skill4_Time = 0;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q) && Skill1_Can)
        {
            unityAction[0]?.Invoke();
            Skill1_Can = false;

            blind[0].fillAmount = 1;
            StartCoroutine("blind1");
        }
        if (Input.GetKeyDown(KeyCode.W) && Skill2_Can)
        {
            unityAction[1]?.Invoke();
            Skill2_Can = false;

            blind[1].fillAmount = 1;
            StartCoroutine("blind2");
        }
        if (Input.GetKeyDown(KeyCode.E) && Skill3_Can)
        {
            unityAction[2]?.Invoke();
            Skill3_Can = false;

            blind[2].fillAmount = 1;
            StartCoroutine("blind3");
        }
        if (Input.GetKeyDown(KeyCode.R) && Skill4_Can)
        {
            unityAction[3]?.Invoke();
            Skill4_Can = false;

            blind[3].fillAmount = 1;
            StartCoroutine("blind4");
        }

        if (!Skill1_Can)
        {
            Skill1_Time += Time.deltaTime;
            if (Skill1_CoolTime < Skill1_Time)
            {
                Skill1_Time = 0;
                Skill1_Can = true;
            }
        }

        if (!Skill2_Can)
        {
            Skill2_Time += Time.deltaTime;
            if (Skill2_CoolTime < Skill2_Time)
            {
                Skill2_Time = 0;
                Skill2_Can = true;
            }
        }

        if (!Skill3_Can)
        {
            Skill3_Time += Time.deltaTime;
            if (Skill3_CoolTime < Skill3_Time)
            {
                Skill3_Time = 0;
                Skill3_Can = true;
            }
        }

        if (!Skill4_Can)
        {
            Skill4_Time += Time.deltaTime;
            if (Skill4_CoolTime < Skill4_Time)
            {
                Skill4_Time = 0;

                Skill4_Can = true;
            }
        }
    }
    private IEnumerator blind1()
    {
        while (blind[0].fillAmount > 0)
        {
            blind[0].fillAmount -= Time.smoothDeltaTime / Skill1_CoolTime;
            yield return null;
        }
        yield break;
    }

    private IEnumerator blind2()
    {
        while (blind[1].fillAmount > 0)
        {
            blind[1].fillAmount -= Time.smoothDeltaTime / Skill2_CoolTime;
            yield return null;
        }
        yield break;
    }

    private IEnumerator blind3()
    {
        while (blind[2].fillAmount > 0)
        {
            blind[2].fillAmount -= Time.smoothDeltaTime / Skill2_CoolTime;
            yield return null;
        }
        yield break;
    }

    private IEnumerator blind4()
    {
        while (blind[3].fillAmount > 0)
        {
            blind[3].fillAmount -= Time.smoothDeltaTime / Skill3_CoolTime;
            yield return null;
        }
        yield break;
    }
}
