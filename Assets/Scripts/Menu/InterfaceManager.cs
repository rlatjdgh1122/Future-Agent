using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InterfaceManager : MonoBehaviour
{
    public Animator anim;
    public Animator ModeAnim;
    [Header("GameObjects")]
    public GameObject Gameinterface;
    public GameObject Intro;
    [SerializeField] private GameObject Mode;


    [Header("Scripts")]
    [SerializeField] private TextMeshProUGUI Txt;
    [SerializeField] private SkillManager skill;
    [SerializeField] private StatManager stat;

    public void Back()
    {
        Gameinterface.SetActive(false);
        Intro.SetActive(true);
    }
    public void GameStart()
    {
        if (skill.ui_images[3].sprite != null && stat.CurrentStat == 0)
        {
            anim.SetTrigger("IsText");
            ModeAnim.SetTrigger("IsOpen");
            Txt.text = "선택 할 모드를 고르시오";
            Mode.SetActive(true);
            gameObject.SetActive(false);
        }
        if (skill.ui_images[3].sprite == null)
        {
            anim.SetTrigger("IsText");
            Txt.text = "스킬을 더 고르시오";
        }
        if (stat.CurrentStat != 0)
        {
            anim.SetTrigger("IsText");
            Txt.text = "스탯을 더 고르시오";
        }
    }
}
