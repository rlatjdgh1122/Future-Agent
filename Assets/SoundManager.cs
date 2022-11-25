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
            }
            else settingPanel.SetActive(true);
        }
    }
    public void Cancel_Setting()
    {
        Instace.EffectPlay(5, 0);

        settingPanel.SetActive(false);
    }
    public void Exit_Setting()
    {
        Application.Quit();
        settingPanel.SetActive(false);
    }
    public void Intro_Setting()
    {
        Instace.EffectPlay(5, 0);

        settingPanel.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != "Intro")
            SceneManager.LoadScene("Intro");
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
}
