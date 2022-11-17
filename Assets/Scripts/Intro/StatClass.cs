using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StatClass : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI StatTxt;
    public GameObject StatPanel;
    public int CurrentStat;
    public int Stat;
    private int StatUp = 1;

    public List<StatSave> StatSaves = new List<StatSave>();
    public delegate void a();
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        CurrentStat = PlayerPrefs.GetInt("Stat", Stat);
        for (int i = 0; i < StatSaves.Count; i++)
            StatSetting(i);
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
            StatSaves[i].Value += StatUp;
            StatSaves[i].TotalStat = (int)StatSaves[i].Value;
            PlayerPrefs.SetInt(StatSaves[i].StatName, StatSaves[i].TotalStat);

            CurrentStat--;
            PlayerPrefs.SetInt("Stat", CurrentStat);

            StatSetting(i);
        }
        else Debug.Log("안돼");
    }

    public void Minus(int i)
    {
        if (StatSaves[i].Value != 0)
        {
            StatSaves[i].Value -= StatUp;
            StatSaves[i].TotalStat = (int)StatSaves[i].Value;
            PlayerPrefs.SetInt(StatSaves[i].StatName, StatSaves[i].TotalStat);

            CurrentStat++;
            PlayerPrefs.SetInt("Stat", CurrentStat);

            StatSetting(i);
        }
        else Debug.Log("안됩니당");
    }
    public void Back()
    {
        StatPanel.SetActive(false);
    }
}
