using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public Image[] ui_images;
    public Image[] PlayGame_UI;

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
        for (int i = ui_images.Length - 1; i >= 0; i--)
        {
            ui_images[i].sprite = null;
            PlayGame_UI[i].sprite = null;

            ChoiceScript.Clear();
        }
        ResetSkillMethod();
        buttons.ForEach(p => p.interactable = true); // ¶÷´Ù½Ä
    }

    public void Choice_Skill()
    {

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
                            break;
                        case "b":
                            PlayerSkillController.unityAction[i].AddListener(skillMethod.Skill2);
                            break;
                        case "c":
                            PlayerSkillController.unityAction[i].AddListener(skillMethod.Skill3);
                            break;
                        case "d":
                            PlayerSkillController.unityAction[i].AddListener(skillMethod.Skill4);
                            break;
                        case "e":
                            PlayerSkillController.unityAction[i].AddListener(skillMethod.Skill5);
                            break;
                        case "f":
                            PlayerSkillController.unityAction[i].AddListener(skillMethod.Skill6);
                            break;
                    }
                }
            }
        }
        catch(Exception e)
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
