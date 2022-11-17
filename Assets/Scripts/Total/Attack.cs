using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalName;
   

public class Attack : StatClass
{
    [SerializeField]  GameObject AttackArea;

    #region ������ ó���ϴ� �ݶ��̴��� ���� �ִ��ϴ� �޼���
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
