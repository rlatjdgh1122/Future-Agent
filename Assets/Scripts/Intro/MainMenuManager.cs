using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject SkillPanel;
    [SerializeField] GameObject StatPanel;
    [SerializeField] GameObject MainMenuPanel;
    [SerializeField] GameObject Player_UI;
    [SerializeField] PlayerController Player;
    private void Start()
    {
        Player.enabled = false;
    }
    public void skillButton()
    {
        SoundManager.Instace.EffectPlay(5, 0);

        SkillPanel.SetActive(true);
    }
    public void StatButton()
    {
        SoundManager.Instace.EffectPlay(5, 0);

        StatPanel.SetActive(true);
    }
    public void GameStart()
    {
        SoundManager.Instace.EffectPlay(5, 0);

        MainMenuPanel.SetActive(false);
        Player_UI.SetActive(true);
        Player.enabled = (true);
    }
}
