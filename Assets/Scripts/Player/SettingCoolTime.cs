using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class CoolTime
{
    public float Skill_CoolTime;
    public bool Skill_Can = true;
    public float Skill_Time;
}

[System.Serializable]
public class SettingCoolTime
{
    public string SkillName;
    public float SetCoolTime;
}

