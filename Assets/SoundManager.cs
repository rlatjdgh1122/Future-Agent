using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instace;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private AudioSource BG_Source;
    [SerializeField] private AudioSource EF_Source;

    public AudioClip[] cd;
    private void Awake()
    {
        Instace = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Instace.EffectPlay(5, 0);
            if (settingPanel.activeInHierarchy == true)
            {
                settingPanel.SetActive(false);
                Time.timeScale = 1;
            }
            else { settingPanel.SetActive(true); Time.timeScale = 0; }
        }
    }
    public void Cancel_Setting()
    {
        Instace.EffectPlay(5, 0);
        Time.timeScale = 1;
        settingPanel.SetActive(false);
    }
    public void Exit_Setting()
    {
        Application.Quit();
        Time.timeScale = 1;
        settingPanel.SetActive(false);
    }
    public void BG_Volume(float volume)
    {
        BG_Source.volume = volume;
    }
    public void EF_Volume(float volume)
    {
        EF_Source.volume = volume;
    }
    public void EffectPlay(int index, float delay)
    {
        EF_Source.clip = cd[index];
        StartCoroutine(SoundDelay(index, delay));
    }
    private IEnumerator SoundDelay(int index, float delay)
    {
        yield return new WaitForSeconds(delay);
        EF_Source.PlayOneShot(cd[index]);
    }
    public void MoveScene()
    {
        GameObject a = GameObject.Find("Player");
        SkillMethod skillMethod = a.GetComponent<SkillMethod>();
        Destroy(a);
        SceneManager.LoadScene("Intro");
        if (skillMethod.isUpDamage)
            skillMethod.DamageDown();
    }
}

