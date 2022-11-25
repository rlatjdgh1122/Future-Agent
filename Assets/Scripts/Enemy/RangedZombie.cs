using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedZombie : Zombie
{
    public GameObject PrefabAttack;
    public Transform PrefabPos;

    private void Start()
    {
        RandomSpeed();
    }
    public void Attack()
    {
        GameObject a = Instantiate(PrefabAttack, PrefabPos.position, Quaternion.identity);
    }
}
