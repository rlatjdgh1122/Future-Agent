using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StatManager : MonoBehaviour
{
    public stat Setstat;
    public TextMeshProUGUI StatTxt;

    public GameObject StatPanel;
    public int CurrentStat = 0;
    public int Stat;
    private int StatUp = 1;

    public float defaultHp;
    
    [Header("스탯 당 올라갈 수치")]
    public float PlusDamage = 1;
    public float PlusSpeed = 1;
    public float PlusPlayerHp = 20;
    public float MinusCoolTime = 0.01f;
    public float PlusDashSpeed = 10;

    public List<StatSave> StatSaves = new List<StatSave>();
    public Health health;

    private void Start()
    {
        CurrentStat = PlayerPrefs.GetInt("Stat", Stat);
        for (int i = 0; i < StatSaves.Count; i++)
            StatSetting(i);

        Setstat.speed = StatSaves[0].Value * PlusSpeed;
        Setstat.damage = StatSaves[1].Value * PlusDamage;
        health.playerHp = defaultHp + PlusPlayerHp * StatSaves[2].Value;
        PlayerSkillController.Instance.SettingCoolTimes.ForEach(p => p.SetCoolTime -= StatSaves[3].Value * MinusCoolTime);
        Setstat.Dashspeed += StatSaves[4].Value * PlusDashSpeed;
        //PlayerSkillController.Instance.SettingCoolTimes.ForEach(p => p.SetCoolTime = p.SetCoolTime - (StatSaves[3].Value * MinusCoolTime));
    }

    public void Update()
    {
        StatTxt.text = "Stat : " + CurrentStat;
    }
    public void StatSetting(int i)//스탯벨류 세팅
    {
        StatSaves[i].Value = PlayerPrefs.GetInt(StatSaves[i].StatName, 0);
        StatSaves[i].StatSlider.value = StatSaves[i].Value;

    }
    public void Plus(int i)
    {
        if (StatSaves[i].Value != StatSaves[i].StatSlider.maxValue && CurrentStat != 0)
        {
            SoundManager.Instace.EffectPlay(7,0);
            StatSaves[i].Value += StatUp;
            StatSaves[i].TotalStat = (int)StatSaves[i].Value;
            PlayerPrefs.SetInt(StatSaves[i].StatName, StatSaves[i].TotalStat);

            CurrentStat--;
            PlayerPrefs.SetInt("Stat", CurrentStat);

            if (i == 0)
                Setstat.speed += PlusSpeed;
            if (i == 1) //스탯배열의 1번째면
                Setstat.damage += PlusDamage;
            if (i == 2)
            {
                Setstat.playerHp += PlusPlayerHp;
                health.SliderHpSetting();
            }
            if (i == 3)
                PlayerSkillController.Instance.SettingCoolTimes.ForEach(p => p.SetCoolTime -= MinusCoolTime);
            if (i == 4)
                Setstat.Dashspeed += PlusDashSpeed;
            StatSetting(i);

        }
        else Debug.Log("안돼");
    }

    public void Minus(int i)
    {
        if (StatSaves[i].Value != 0)
        {
            SoundManager.Instace.EffectPlay(6,0);

            StatSaves[i].Value -= StatUp;
            StatSaves[i].TotalStat = (int)StatSaves[i].Value;
            PlayerPrefs.SetInt(StatSaves[i].StatName, StatSaves[i].TotalStat);

            CurrentStat++;
            PlayerPrefs.SetInt("Stat", CurrentStat);

            if (i == 0)
                Setstat.speed -= PlusSpeed;
            if (i == 1)
                Setstat.damage -= PlusDamage;
            if (i == 2)
            {
                Setstat.playerHp -= PlusPlayerHp;
                health.SliderHpSetting();
            }
            if (i == 3)
                PlayerSkillController.Instance.SettingCoolTimes.ForEach(p => p.SetCoolTime += MinusCoolTime);
            if (i == 4)
                Setstat.Dashspeed -= PlusDashSpeed;
            StatSetting(i);
        }
        else Debug.Log("안됩니당");
    }
    
    public void Back()
    {
        SoundManager.Instace.EffectPlay(5, 0);

        StatPanel.SetActive(false);
    }
}
