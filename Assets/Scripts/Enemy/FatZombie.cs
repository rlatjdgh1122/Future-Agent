using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatZombie : Zombie
{
    public GameObject FatAttack;
    public Transform pos;
    public void Attack()
    {
        GameObject a = Instantiate(FatAttack, pos.position, Quaternion.identity);
    }
}
