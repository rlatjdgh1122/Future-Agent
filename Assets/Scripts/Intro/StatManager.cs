using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI StatTxt;
    public GameObject StatPanel;
    public int CurrentStat;
    public int Stat;
    private int StatUp = 1;

    [Header("SpeedStat")]
    [SerializeField] private Slider Speed_Stat;
    private int SpeedCurrentValue;
    private int SpeedTotalStat;

    [Header("DamageStat")]
    [SerializeField] private Slider Damage_Stat;
    private int DamageCurrentValue;
    private int DamageTotalStat;

    [Header("SkillCoolTimeStat")]
    [SerializeField] private Slider SkillCoolTime_Stat;
    private int SkillCoolTimeValue;
    private int SkillCoolTimeTotalStat;

    [Header("CreticalPercentageStat")]
    [SerializeField] private Slider CreticalPrecentage_Stat;
    private int CreticalPrecentageValue;
    private int CreticalPrecentageTotalStat;

    [Header("CreticalDamageStat")]
    [SerializeField] private Slider CreticalDamage_Stat;
    private int CreticalDamageValue;
    private int CreticalDamageTotalStat;
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        CurrentStat = PlayerPrefs.GetInt("Stat", Stat);

        
    }

    private void Update()
    {
        SpeedCurrentValue = PlayerPrefs.GetInt("Speed", 0);
        DamageCurrentValue = PlayerPrefs.GetInt("Damage", 0);
        CreticalPrecentageValue = PlayerPrefs.GetInt("CreticalPercentage", 0);
        CreticalDamageValue = PlayerPrefs.GetInt("CreticalDamage", 0);
        SkillCoolTimeValue = PlayerPrefs.GetInt("SkillCoolTime", 0);

        Speed_Stat.value = SpeedCurrentValue;
        Damage_Stat.value = DamageCurrentValue;
        CreticalPrecentage_Stat.value = CreticalPrecentageValue;
        CreticalDamage_Stat.value = CreticalDamageValue;
        SkillCoolTime_Stat.value = SkillCoolTimeValue;

        StatTxt.text = "Stat : " + CurrentStat;
    }
    public void UpSpeed()
    {
        if (Speed_Stat.value != Speed_Stat.maxValue && CurrentStat != 0)
        {
            Speed_Stat.value += StatUp;

            SpeedTotalStat = (int)Speed_Stat.value;
            PlayerPrefs.SetInt("Speed", SpeedTotalStat);

            CurrentStat--;
            PlayerPrefs.SetInt("Stat", CurrentStat);
        }
        else
            Debug.Log("¾ÈµÅ");
    }


    public void UpDamage()
    {
        if (Damage_Stat.value != Damage_Stat.maxValue && CurrentStat != 0)
        {
            Damage_Stat.value += StatUp;

            DamageTotalStat = (int)Damage_Stat.value;
            PlayerPrefs.SetInt("Damage", DamageTotalStat);

            CurrentStat--;
            PlayerPrefs.SetInt("Stat", CurrentStat);
        }
        else
            Debug.Log("¾ÈµÅ");

    }
    public void UpSkillCoolTime()
    {
        if (SkillCoolTime_Stat.value != SkillCoolTime_Stat.maxValue && CurrentStat != 0)
        {
            SkillCoolTime_Stat.value += StatUp;

            SkillCoolTimeTotalStat = (int)SkillCoolTime_Stat.value;
            PlayerPrefs.SetInt("SkillCoolTime", SkillCoolTimeTotalStat);

            CurrentStat--;
            PlayerPrefs.SetInt("Stat", CurrentStat);
        }
        else
            Debug.Log("¾ÈµÅ");
    }
    public void UpCreticalPercentage()
    {
        if (CreticalPrecentage_Stat.value != CreticalPrecentage_Stat.maxValue && CurrentStat != 0)
        {
            CreticalPrecentage_Stat.value += StatUp;

            CreticalPrecentageTotalStat = (int)CreticalPrecentage_Stat.value;
            PlayerPrefs.SetInt("CreticalPercentage", CreticalPrecentageTotalStat);

            CurrentStat--;
            PlayerPrefs.SetInt("Stat", CurrentStat);
        }
        else
            Debug.Log("¾ÈµÅ");

    }
    public void UpCreticalDamage()
    {
        if (CreticalDamage_Stat.value != CreticalDamage_Stat.maxValue && CurrentStat != 0)
        {
            CreticalDamage_Stat.value += StatUp;

            CreticalDamageTotalStat = (int)CreticalDamage_Stat.value;
            PlayerPrefs.SetInt("CreticalDamage", CreticalDamageTotalStat);

            CurrentStat--;
            PlayerPrefs.SetInt("Stat", CurrentStat);
        }
        else
            Debug.Log("¾ÈµÅ");
    }
    public void DownSpeed()
    {
        if (Speed_Stat.value != Speed_Stat.minValue && CurrentStat != 0 || CurrentStat == 0)
        {
            Speed_Stat.value -= StatUp;

            SpeedTotalStat = (int)Speed_Stat.value;
            PlayerPrefs.SetInt("Speed", SpeedTotalStat);

            CurrentStat++;
            PlayerPrefs.SetInt("Stat", CurrentStat);
        }
    }

    public void DownDamage()
    {
        if (Damage_Stat.value != Damage_Stat.minValue && CurrentStat != 0 || CurrentStat == 0)
        {
            Damage_Stat.value -= StatUp;

            DamageTotalStat = (int)Speed_Stat.value;
            PlayerPrefs.SetInt("Damage", DamageTotalStat);

            CurrentStat++;
            PlayerPrefs.SetInt("Stat", CurrentStat);
        }
    }
    public void DownSkillCoolTime()
    {
        if (SkillCoolTime_Stat.value != SkillCoolTime_Stat.minValue && CurrentStat != 0 || CurrentStat == 0)
        {
            SkillCoolTime_Stat.value -= StatUp;

            SkillCoolTimeTotalStat = (int)SkillCoolTime_Stat.value;
            PlayerPrefs.SetInt("SkillCoolTime", SkillCoolTimeTotalStat);

            CurrentStat++;
            PlayerPrefs.SetInt("Stat", CurrentStat);
        }
    }

    public void DownCreticalDamage()
    {
        if (CreticalDamage_Stat.value != CreticalDamage_Stat.minValue && CurrentStat != 0 || CurrentStat == 0)
        {
            CreticalDamage_Stat.value -= StatUp;

            CreticalDamageTotalStat = (int)CreticalDamage_Stat.value;
            PlayerPrefs.SetInt("CreticalDamage", CreticalDamageTotalStat);

            CurrentStat++;
            PlayerPrefs.SetInt("Stat", CurrentStat);
        }
    }
    public void DownCreticalPrecentage()
    {
        if (CreticalPrecentage_Stat.value != CreticalPrecentage_Stat.minValue && CurrentStat != 0 || CurrentStat == 0)
        {
            CreticalPrecentage_Stat.value -= StatUp;

            CreticalPrecentageTotalStat = (int)CreticalPrecentage_Stat.value;
            PlayerPrefs.SetInt("CreticalPercentage", CreticalPrecentageTotalStat);

            CurrentStat++;
            PlayerPrefs.SetInt("Stat", CurrentStat);
        }
    }

    public void Back()
    {
        StatPanel.SetActive(false);
    }
}
