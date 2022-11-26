using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public stat Setstat;
    public Image[] ui_images;
    public Image[] PlayGame_UI;
    public Color PlayerGame_UIColor;

    public List<Item> items = new List<Item>();
    public List<Button> buttons = new List<Button>();
    public List<string> ChoiceScript = new List<string>();

    public GameObject SkillgameObject;
    public Button Choice_button;

    Image choose_Item;
    string Choose_Name;
    bool isChoice;

    [SerializeField] PlayerSkillController PlayerSkillController;
    [SerializeField] SkillMethod skillMethod;

    private void Start()
    {
        Choice_button.interactable = false;
    }
    private void Update()
    {
        if (ui_images[3].sprite != null)
        {
            Choice_button.interactable = true;
            isChoice = false;
        }
        else
        {
            Choice_button.interactable = false;
            isChoice = true;
        }
    }
    public void choose_Skill(int index)
    {
        SoundManager.Instace.EffectPlay(5, 0);

        if (isChoice)
        {
            choose_Item = items[index].Skill_Image;
            Choose_Name = items[index].SkillName;
            ChoiceScript.Add(Choose_Name);

            SetItem(choose_Item);
            buttons[index].interactable = false;
        }
    }
    public void Reset_Skill()
    {
        SoundManager.Instace.EffectPlay(5, 0);

        for (int i = ui_images.Length - 1; i >= 0; i--)
        {
            ui_images[i].sprite = null;
            PlayGame_UI[i].sprite = null;
            PlayGame_UI[i].color = PlayerGame_UIColor;

            ChoiceScript.Clear();
        }
        ResetSkillMethod();
        ResetSkillCoolTime();
        buttons.ForEach(p => p.interactable = true); // ¶÷´Ù½Ä
    }

    public void Choice_Skill()
    {
        SoundManager.Instace.EffectPlay(5, 0);

        //GameObject player = Instantiate(Resources.Load("Player"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        SetSkillMethod();
        SkillgameObject.SetActive(false);

    }
    public void SetSkillMethod()
    {
        try  //try, catch
        {
            for (int i = 0; i < 4; i++)
            {
                {
                    string name = ChoiceScript[i];
                    switch (name)
                    {
                        case "a":
                            PlayerSkillController.unityAction[i].AddListener(skillMethod.Skill1);
                            PlayerSkillController.coolTimes[i].Skill_CoolTime = PlayerSkillController.SettingCoolTimes[0].SetCoolTime;
                            break;
                        case "b":
                            PlayerSkillController.unityAction[i].AddListener(skillMethod.Skill2);
                            PlayerSkillController.coolTimes[i].Skill_CoolTime = PlayerSkillController.SettingCoolTimes[1].SetCoolTime;
                            break;
                        case "c":
                            PlayerSkillController.unityAction[i].AddListener(skillMethod.Skill3);
                            PlayerSkillController.coolTimes[i].Skill_CoolTime = PlayerSkillController.SettingCoolTimes[2].SetCoolTime;
                            break;
                        case "d":
                            PlayerSkillController.unityAction[i].AddListener(skillMethod.Skill4);
                            PlayerSkillController.coolTimes[i].Skill_CoolTime = PlayerSkillController.SettingCoolTimes[3].SetCoolTime;
                            break;
                        case "e":
                            PlayerSkillController.unityAction[i].AddListener(skillMethod.Skill5);
                            PlayerSkillController.coolTimes[i].Skill_CoolTime = PlayerSkillController.SettingCoolTimes[4].SetCoolTime;
                            break;
                        case "f":
                            PlayerSkillController.unityAction[i].AddListener(skillMethod.Skill6);
                            PlayerSkillController.coolTimes[i].Skill_CoolTime = PlayerSkillController.SettingCoolTimes[5].SetCoolTime;
                            break;
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

    }
    public void ResetSkillMethod()
    {
        for (int i = 0; i < 4; i++)
        {
            {
                PlayerSkillController.unityAction[i].RemoveAllListeners();
            }
        }
    }
    public void ResetSkillCoolTime()
    {
        for (int i = 0; i < 4; i++)
        {
            PlayerSkillController.coolTimes[i].Skill_CoolTime = 0;
            PlayerSkillController.coolTimes[i].Skill_Time = 0;
            PlayerSkillController.coolTimes[i].Skill_Can = false;
        }
    }
    public void SetItem(Image choose_sprite)
    {
        for (int i = 0; i < 4; i++)
        {
            if (ui_images[i].sprite == null)
            {
                ui_images[i].sprite = choose_sprite.sprite;

                PlayGame_UI[i].sprite = ui_images[i].sprite;
                Color color = new Color(72, 1, 1, 255);
                PlayGame_UI[i].color = color;
                break;
            }
        }
    }

}
