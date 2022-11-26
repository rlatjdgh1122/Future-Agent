using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "So?stat")]
public class stat : ScriptableObject
{
    public float playerHp;
    public  float damage; //기본데미지
    public  float speed; //기본 스피드
    public  float Dashspeed; //기본 대시스피드
   public List<float> SetCoolTimes = new List<float>();

}
