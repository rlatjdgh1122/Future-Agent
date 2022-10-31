using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate float Hit(float damaged);
public class Health : MonoBehaviour
{
    public float Hp;
    Hit Hit;
    
   public  void Damaged(float damaged,Hit hit)
    {
        hit(damaged);
    }
    public float EnemyHp(float damaged)
    {
        Hp -= damaged;
        return Hp;
    }
    public float PlyerHp(float damaged)
    {
        Hp -= damaged;
        return Hp;
    }
}
