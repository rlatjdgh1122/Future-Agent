using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceModeManager : MonoBehaviour
{
    [SerializeField] private GameObject Mode;
    [SerializeField] private GameObject Interface;
    [SerializeField] private Animator anim;

    public void CloseModePanel()
    {
        anim.SetTrigger("IsClose");
    }
}
