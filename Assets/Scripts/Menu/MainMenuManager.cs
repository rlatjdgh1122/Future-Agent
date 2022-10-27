using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject SkillPanel;
    [SerializeField] GameObject StatPanel;
    [SerializeField] GameObject MainMenuPanel;
    [SerializeField] GameObject Player_UI;
    public void skillButton()
    {
        SkillPanel.SetActive(true);
    }
    public void StatButton()
    {
        StatPanel.SetActive(true);
    }
    public void GameStart()
    {
        MainMenuPanel.SetActive(false);
        Player_UI.SetActive(true);
    }
}
