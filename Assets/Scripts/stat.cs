using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "So?stat")]
public class stat : ScriptableObject
{
    public float playerHp;
    public  float damage; //�⺻������
    public  float speed; //�⺻ ���ǵ�
    public  float Dashspeed; //�⺻ ��ý��ǵ�
   public List<float> SetCoolTimes = new List<float>();

}
