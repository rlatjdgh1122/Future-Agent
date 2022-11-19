using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedZombie : Zombie
{
    public GameObject RangedAttack;
    public Transform pos;
    Transform Rotate;
    public void Attack()
    {
            GameObject a = Instantiate(RangedAttack, pos.position, Quaternion.identity);
    }
}
