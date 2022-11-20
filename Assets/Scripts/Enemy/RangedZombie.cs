using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedZombie : Zombie
{
    public GameObject RangedAttack;
    public Transform pos;
    public void Attack()
    {
            GameObject a = Instantiate(RangedAttack, pos.position, Quaternion.identity);
    }
}
