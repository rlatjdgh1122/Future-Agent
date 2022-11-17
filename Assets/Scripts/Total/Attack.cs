using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalName;
   

public class Attack : StatClass
{
    [SerializeField]  GameObject AttackArea;

    #region 공격을 처리하는 콜라이더를 껏다 켯다하는 메서드
    public void EventStartAttack()
    {
        AttackArea.SetActive(true);
    }
    public void EventEndAttack()
    {
        AttackArea.SetActive(false);
    }
    #endregion
}
